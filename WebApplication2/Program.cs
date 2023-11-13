using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(Options =>
{
    Options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefualtConnection")
        );
});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


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

app.UseEndpoints(endpoints =>
{
    //endpoints.MapControllerRoute(
    //    name: "testpage",
    //    pattern: "{controller=Home}/{action=Htmlpage}"
    //    );
    endpoints.MapControllerRoute(
        name : "Next" ,
        pattern : "{controller=Next}/{action=Index}/{id?}"
      
        );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
});

//app.MapControllerRoute(
   // name: "default",            // setting the defualt route if none is set to home controller and action is index ,
   // pattern: "{controller=Home}/{action=Index}/{id?}" );     // index is the name of the page

app.Run();
