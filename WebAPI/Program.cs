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
// �stte yazd���m�z: E�er IproductService kullan�lmas� gerekiyorsa, arka tarafta ProductManager newle diyoruz.
// yaln�z i�erisinde data tutmuyorsak singleton'u kullanaca��z.
//builder.Services.AddSingleton<IProductDal, EFProductDal>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()); // .net'e kendi IOc yap�s�n�(IproductService verince productMnaager olu�tur diyorduk) kullanma, autofac yap�s�n� kullan.
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
