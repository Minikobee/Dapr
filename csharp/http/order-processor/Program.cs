using System.Text.Json;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapPost("/orders", (Order order) =>
{
    Console.WriteLine("Order received : " + order);

    // Create a response object
    var response = new OrderResponse { Message = "Order received successfully" };

    // Return the response as JSON
    return new JsonResult(response);
});




await app.RunAsync();

public record Order(int orderId);

public record OrderResponse
{
    public string Message { get; init; }
}