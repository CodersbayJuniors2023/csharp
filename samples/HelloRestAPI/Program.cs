using System.Text.Json;
using HelloRestAPI.controller;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// set up open api
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo{Title = "Fruit API", Version = "v1"});
});

var fruitController = new FruitController();

// set up app for using swagger
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(option =>
{
    option.SwaggerEndpoint("/swagger/v1/swagger.json", "Fruit API v1");
    option.RoutePrefix = string.Empty;
});

// app.MapGet("/", () => "Hello World!");

// use middleware to set content type for avoiding code duplication
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Type", "application/json; charset=utf-8");
    await next.Invoke();
});

app.MapGet("/orange", () => JsonSerializer.Serialize(fruitController.GetOrange()));
app.MapPost("/apple", () => JsonSerializer.Serialize(fruitController.GetApple()));
app.MapGet("/pear", () => JsonSerializer.Serialize(fruitController.GetPear()));
app.MapGet("/fruits", () => JsonSerializer.Serialize(fruitController.GetFruits()));

/* set application context in method
app.MapGet("/orange", (HttpContext httpContext) =>
{
    httpContext.Response.Headers.Add("Content-Type", "application/json; charset=utf-8");
    return JsonSerializer.Serialize(fruitController.GetOrange());
});
*/

app.Run();