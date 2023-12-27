using System.Net;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
// Repositoryde constracçır burayı çalıştırmaktadır ve bağlantı kurmaktadır.
//sql bağlantı komutu appsettings.json dosyasında tanımlanmaktadır. ve program csde çağrılmaktadır.
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"), b => b.MigrationsAssembly("StoreApp"));
});

builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<ICategoryRepository,CategorRepository>();
//Yukarıda kayıt işlemleri yapıldı IoC çözümleyebilmesi için Repo için


builder.Services.AddScoped<IServiceManager,ServiceManager>();
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
//Yukarıda kayıt işlemleri yapıldı IoC çözümleyebilmesi için Service için

var app = builder.Build();

app.UseStaticFiles();
//yukarıda static doya tutmak için kulanılır 
//wwwroot dosyası bu metod olmadan kullnaılmaz
//içindekileri statik olarak ulaşmak için yaptık
app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>{
    endpoints.MapAreaControllerRoute(
    name:"Admin,",
    areaName:"Admin",
    pattern:"Admin/{controller=Dashboard}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name:"default",
pattern:"{controller=Home}/{action=Index}/{id?}");
}  );

// app.MapControllerRoute(name:"default",
// pattern:"{controller=Home}/{action=Index}/{id?}");

//ikinci endpoinmt olduğu için route değiştirildi yukarıdaki gibi
//yönlendirme yapılmışyıtr.



app.Run();
