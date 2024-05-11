using FoodieFlow.Pgm.Config;
using FoodieFlow.Pgm.Core;
using FoodieFlow.Pgm.Core.Entities.Request;
using FoodieFlow.Pgm.Core.Interfaces.Service;
using FoodieFlow.Pgm.Infra;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterDependencies(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/healthcheck", (ILogger<Program> _logger) =>
{
    _logger.LogInformation("Exemplo de endpoint sem autenticação/autorização");

    return Results.Ok();
});

app.MapPost("/processarPagamento", async (
    [FromServices] IProcessamentoPagamentoService processamentoPagamento,
    [FromBody]RequestPagamento request) =>
{
    try
    {
        var pagamento = await processamentoPagamento.ProcessarPagamentoAsync(request);
        return Results.Ok(pagamento);
    }
    catch (Exception ex)
    {
        // Log the error
        return Results.Problem("Internal server error", statusCode: 500);
    }
});

app.Run();


