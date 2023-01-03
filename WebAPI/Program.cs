using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.AutoFac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 
 builder.Services.AddControllers();
 //builder.Services.AddSingleton<IProductService, ProductManager>(); // IoC Container
// üstte yazdýðýmýz: Eðer IproductService kullanýlmasý gerekiyorsa, arka tarafta ProductManager newle diyoruz.
// yalnýz içerisinde data tutmuyorsak singleton'u kullanacaðýz.
//builder.Services.AddSingleton<IProductDal, EFProductDal>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()); // .net'e kendi IOc yapýsýný(IproductService verince productMnaager oluþtur diyorduk) kullanma, autofac yapýsýný kullan.
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutoFacBusinessModule());
});
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
