using Microsoft.EntityFrameworkCore;
using RazorPageExampleWithEntityFramework.Entity;
using RazorPageExampleWithEntityFramework.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//registration 
builder.Services.AddDbContext<ProductContextDb>(options =>
{
    //"EmployeeContext" is the name of ConnectionStrings
    //declared in the appsetting.json and it should be given the same name
    //otherwise an issue is raised
    // options.UseSqlServer(builder.Configuration.GetConnectionString("ProductContext"));
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductContext"));
});
//this registers the applications
builder.Services.AddTransient<IProductRepository, ProductRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
