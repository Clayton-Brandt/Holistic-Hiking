// The following section was assisted by AI as I am still new to JavaScript at the moment. - Luke
(() => {
  const section = document.getElementById(`comments`);
  if (!section) return;

  const trailId = Number(section.dataset.trailId);
  const currentUserId = section.dataset.currentUserId || null;
  const list = document.getElementById(`comment-list`);
  const status = document.getElementById(`comments-status`);
  const count = document.getElementById(`comment-count`);
  const form = document.getElementById(`comment-form`);

  function formatDate(value) {
    const date = new Date(value.endsWith(`Z`) ? value : value + `Z`);
    return date.toLocaleDateString(undefined, {
      year: `numeric`,
      month: `short`,
      day: `numeric`,
    });
  }

  async function request(url, method = `GET`, body = null) {
    const res = await fetch(url, {
      method,
      headers: body ? { "Content-Type": "application/json" } : undefined,
      body: body ? JSON.stringify(body) : undefined,
    });

    if (res.redirected)
      throw new Error(`Your session has expired. Please log in again.`);
    if (!res.ok) {
      const data = await res.json().catch(() => null);
      throw new Error(
        data?.error ??
          `Something went wrong. Please try again in a few minutes.`,
      );
    }

    const isJson = res.headers
      .get(`content-type`)
      ?.includes(`application/json`);
    return isJson ? res.json() : null;
  }

  function updateCommentCount() {
    const total = list.children.length;
    count.textContent = total ? `(${total})` : ``;
    status.hidden = total > 0;
    status.textContent = `No comments yet. You could change that!`;
  }

  function renderComment(comment) {
    const item = document.createElement(`li`);
    item.className = `comment`;

    const header = document.createElement(`div`);
    header.className = `d-flex flex-wrap align-items-baseline gap-2 mb-1`;

    const author = document.createElement(`a`);
    author.href = `/Users/Profile?id=${encodeURIComponent(comment.userId)}`;
    author.className = `fw-semibold`;
    const fullName = [comment.firstName, comment.lastName].filter(Boolean).join(` `);
    author.textContent = fullName || `Unknown User`;

    const date = document.createElement(`small`);
    date.className = `text-body-secondary`;
    date.textContent =
      formatDate(comment.createdAt) + (comment.updatedAt ? ` (edited)` : ``);

    header.append(author, date);

    const text = document.createElement(`p`);
    text.className = `comment-text mb-2`;
    text.textContent = comment.text;

    item.append(header, text);

    /* Technically the user could change the currentUserId and gain access to these buttons 
           BUT the server should ultimately deny them even if they can click the buttons.
           Ultimately it's a risk I am willing to take.*/
    if (currentUserId && comment.userId === currentUserId) {
      item.append(renderOwnerActions(item, comment));
    }
    return item;
  }

  function renderOwnerActions(item, comment) {
    const actions = document.createElement(`div`);
    actions.className = `comment-actions d-flex gap-3`;

    const editButton = document.createElement(`button`);
    editButton.type = `button`;
    editButton.className = `btn btn-link btn-sm p-0`;
    editButton.textContent = `Edit`;
    editButton.addEventListener(`click`, () => startEdit(item, comment));

    const deleteButton = document.createElement(`button`);
    deleteButton.className = `btn btn-link btn-sm p-0 text-danger`;
    deleteButton.textContent = `Delete`;
    deleteButton.addEventListener(`click`, () => deleteComment(item, comment));

    actions.append(editButton, deleteButton);
    return actions;
  }

  function startEdit(item, comment) {
    const editor = document.createElement(`div`);
    editor.innerHTML = `
        <textarea class="form-control mb-2" rows="3" maxlength="2000" aria-label="Edit comment"></textarea>
            <p class="text-danger small mb-2" role="alert"></p>
            <div class="d-flex gap-2">
                <button type="button" class="btn btn-primary btn-sm">Save</button>
                <button type="button" class="btn btn-link btn-sm">Cancel</button>
            </div>
        `;

    const textarea = editor.querySelector(`textarea`);
    const error = editor.querySelector(`[role="alert"]`);
    const [saveButton, cancelButton] = editor.querySelectorAll(`button`);
    textarea.value = comment.text;

    item.querySelector(`.comment-text`).replaceWith(editor);
    item.querySelector(`.comment-actions`).hidden = true;
    textarea.focus();

    cancelButton.addEventListener(`click`, () =>
      item.replaceWith(renderComment(comment)),
    );

    saveButton.addEventListener(`click`, async () => {
      const newText = textarea.value.trim();
      if (!newText) {
        error.textContent = `Comment cannot be empty.`;
        return;
      }

      saveButton.disabled = true;
      try {
        await request(`/Comments/Update`, `PUT`, {
          commentId: comment.commentId,
          text: newText,
        });
        comment.text = newText;
        comment.updatedAt = new Date().toISOString();
        item.replaceWith(renderComment(comment));
      } catch (err) {
        error.textContent = err.message;
        saveButton.disabled = false;
      }
    });
  }

  async function deleteComment(item, comment) {
    if (!confirm(`Delete this comment? This cannot be undone.`)) return;

    try {
      await request(`/Comments/Delete/${comment.commentId}`, `DELETE`);
      item.remove();
      updateCommentCount();
    } catch (err) {
      alert(err.message);
    }
  }

  async function loadComments() {
    try {
      const comments = await request(`/Comments/ForTrail?trailId=${trailId}`);
      list.replaceChildren(...comments.map(renderComment));
      updateCommentCount();
    } catch {
      status.textContent = `Comments could not be loaded`;
    }
  }

  form?.addEventListener(`submit`, async (e) => {
    e.preventDefault();
    const textarea = form.querySelector(`textarea`);
    const error = document.getElementById(`comment-error`);
    const submitButton = form.querySelector(`button[type="submit"]`);
    const text = textarea.value.trim();

    error.textContent = ``;
    if (!text) {
      error.textContent = `Comment cannot be empty.`;
      return;
    }

    submitButton.disabled = true;
    try {
      const comment = await request(`/Comments/Create`, `POST`, {
        trailId,
        text,
      });
      list.prepend(renderComment(comment));
      textarea.value = ``;
      updateCommentCount();
    } catch (err) {
      error.textContent = err.message;
    } finally {
      submitButton.disabled = false;
    }
  });

  loadComments();
})();

// Favorites system.
(() => {
  const form = document.getElementById(`favorite-form`);
  if (!form) return;

  const button = form.querySelector(`button`);
  const status = document.getElementById(`favorite-status`);
  let saved = form.dataset.saved === `true`;

  function render() {
    form.action = saved ? form.dataset.removeUrl : form.dataset.saveUrl;
    button.className = `btn ${saved ? `btn-outline-danger` : `btn-primary`}`;
    button.innerHTML = saved
      ? `<i class="bi bi-bookmark-x" aria-hidden="true"></i> Remove from Favorites`
      : `<i class="bi bi-bookmark" aria-hidden="true"></i> Save to Favorites`;
  }

  form.addEventListener(`submit`, async (e) => {
    e.preventDefault();
    button.disabled = true;

    try {
      const res = await fetch(form.action, { method: `POST`, body: new FormData(form) });

      if (!res.ok || !res.url.includes(`/Users/Dashboard`)) throw new Error();

      saved = !saved;
      render();
      status.textContent = saved ? `Saved to your favorites.` : `Removed from your favorites.`;
    }
    catch {
      status.textContent = `Something went wrong. Please try again in a few minutes.`;
    }
    finally {
      button.disabled = false;
    }
  });
})();