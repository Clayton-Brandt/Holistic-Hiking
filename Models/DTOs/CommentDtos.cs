namespace Holistic_Hiking.Models.DTOs;

public class CreateCommentDto
{
    public int TrailId { get; set; }
    public string Text { get; set; } = string.Empty;
}

public class UpdateCommentDto
{
    public int CommentId { get; set; }
    public string Text { get; set; } = string.Empty;
}