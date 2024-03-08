using Microsoft.EntityFrameworkCore;
using RoutesManagementSystem.API.DbContexts;
using RoutesManagementSystem.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RoutesManagerDbContext>(
    DbContextOptions => DbContextOptions.UseSqlServer(
        builder.Configuration["ConnectionStrings:RoutesManagerDBConnectionString"]));

builder.Services.AddScoped<ILastMileRoutesRepository, LastMileRoutesRepository>();
builder.Services.AddScoped<IRouteTypeRepository, RouteTypeRepository>();
builder.Services.AddScoped<IMiddleMileRouteRepository, MiddleMileRouteRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
