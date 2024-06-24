using UpVote.Repositories;
using UpVote.Repositories.Base;
using UpVote.Services.Base;
using UpVote.Services;
using UpVote.Middlewares;
using Microsoft.EntityFrameworkCore;
using UpVote.Data;
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

builder.Services.AddTransient<IDiscussionRepository, DiscussionEFRepository>();
builder.Services.AddScoped<IDiscussionService, DiscussionService>();
builder.Services.AddTransient<ISectionRepository, SectionEFRepository>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddTransient<ILoggingRepository, LoggingEFRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserEFRepository>();
builder.Services.AddScoped<IUserDiscussionService, UserDiscussionService>();
builder.Services.AddTransient<IUserDiscussionRepository, UserDiscussionEFRepository>();
builder.Services.AddScoped<IDiscussionSectionService, DiscussionSectionService>();
builder.Services.AddTransient<IDiscussionSectionRepository, DiscussionSectionEFRepository>();
builder.Services.AddTransient<LoggingMiddleware>();

builder.Services.AddDbContext<UpVoteDbContext>(dbContextOptionsBuilder => {
    var connectionString = "Server=localhost;Database=UpVoteDb;Trusted_Connection=True;TrustServerCertificate=True;";
    dbContextOptionsBuilder.UseSqlServer(connectionString);
});

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

var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<UpVoteDbContext>();
await dbContext.Database.MigrateAsync();
await dbContext.Database.EnsureCreatedAsync();

app.Run();
