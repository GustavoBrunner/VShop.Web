using Microsoft.EntityFrameworkCore;
using VShopWeb.Products.Infra;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString(nameof(ApiDbContext));

builder.Services.AddDbContext<ApiDbContext>( options => 
    options.UseMySql(connectionString, 
    ServerVersion.AutoDetect(connectionString)));

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
