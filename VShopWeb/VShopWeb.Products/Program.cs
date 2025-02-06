using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VShopWeb.Products.Infra;
using VShopWeb.Products.Repository;
using VShopWeb.Products.Repository.Contracts;
using VShopWeb.Products.Services;
using VShopWeb.Products.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

AddScopedServices(builder.Services);

string connectionString = builder.Configuration.GetConnectionString(nameof(ApiDbContext));

builder.Services.AddDbContext<ApiDbContext>( options => 
    options.UseMySql(connectionString, 
        ServerVersion.AutoDetect(connectionString))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void AddScopedServices(IServiceCollection services)
{
    services.AddScoped<IProductRepository, ProductRepository>();
    services.AddScoped<ICategoryRepository, CategoryRepository>();
    services.AddScoped<IProductService, ProductService>();
}
