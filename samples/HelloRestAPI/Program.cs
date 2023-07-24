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

app.MapGet("/orange", () => Results.Json(fruitController.GetOrange()));
app.MapPost("/apple", () => Results.Json(fruitController.GetApple()));
app.MapGet("/pear", () => Results.Json(fruitController.GetPear()));
app.MapGet("/fruits", () => Results.Json(fruitController.GetFruits()));

// parameter example
app.MapGet("/fruits/{fruitName}", (string fruitName) =>
{
    foreach (var f in fruitController.GetFruits())
    {
        if (f.Name.Equals(fruitName))
        {
            return Results.Json(f);
        }
    }
    
    return Results.NotFound($"No fruit with name '{fruitName}' was found."); 
});

app.Run();