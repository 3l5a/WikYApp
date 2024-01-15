using Business;
using Business.Contracts;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contexts;
using Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WikYContext>(o =>
{
    o.UseSqlServer(connectionString:@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=WikYDB;Integrated Security=True");
});
builder.Services.AddTransient<IArticleRepository, ArticleRepository>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<IArticleBusiness, ArticleBusiness>();
builder.Services.AddTransient<ICommentBusiness, CommentBusiness>();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
