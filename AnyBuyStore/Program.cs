
using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Commands.AddProductCategory;
using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Queries.GetAllProductCategories;
using AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetAllProducts;
using AnyBuyStore.Data.Data;
using AnyBuyStore.Data.Models;
//using AnyBuyStore.Middleware;
using API.Middleware;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging((hostingContext,logging) =>
{
    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    logging.AddConsole();
    logging.AddDebug();
    logging.AddEventSourceLogger();
    logging.AddNLog();
});


//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<DatabaseContext>(options =>
//{
//    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
//});

builder.Services.AddDbContext<DatabaseContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));

builder.Services.AddIdentity<User, IdentityRole<int>>()
               .AddEntityFrameworkStores<DatabaseContext>()
               .AddDefaultTokenProviders();

//builder.Services.AddTransient<ExceptionHandlingMiddleware>();

// Add services to the container.
builder.Services.AddMediatR(
    typeof(GetAllProductsRequest).Assembly,
    typeof(GetAllProductCetgoriesRequest).Assembly,
    typeof(AddProductCategoryCommand).Assembly);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//custom middleware for exception handling in asp net core request pipeline
//app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseMiddleware<ExceptionMiddleware>();


//app.UseExceptionHandler("/error");
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseAuthorization();


app.MapControllers();

app.Run();
