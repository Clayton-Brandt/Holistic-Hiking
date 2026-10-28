<<<<<<< Updated upstream
=======
using DotNetEnv;
using Holistic_Hiking.Services;

>>>>>>> Stashed changes
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
<<<<<<< Updated upstream

var app = builder.Build();
=======
>>>>>>> Stashed changes

builder.Services.AddScoped<NpsService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
