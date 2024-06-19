using UpVote.Repositories;
using UpVote.Models;
using UpVote.Repositories.Base;
using UpVote.Services.Base;
using UpVote.Services;
using UpVote.Middlewares;
using Upvote.Options;
using UpVote.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var msSqlConnectionSection = builder.Configuration
    .GetSection("Connections")
    .GetSection("MsSqlDb");

builder.Services.Configure<MsSqlConnectionOptions>(msSqlConnectionSection);

var loggingSettings = builder.Configuration.GetSection("MiddlewareSettings");
builder.Services.Configure<LoggingSettings>(loggingSettings);

builder.Services.AddTransient<IDiscussionRepository, DiscussionJsonRepository>();
builder.Services.AddScoped<IDiscussionService, DiscussionService>();
builder.Services.AddTransient<ISectionRepository, SectionDapperRepository>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddTransient<ILoggingRepository, LoggingDapperRepository>();
builder.Services.AddTransient<LoggingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseMiddleware<LoggingMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
