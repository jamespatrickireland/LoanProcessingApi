using LoanProcessingApi.Data;
using LoanProcessingApi.Services;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;
using Azure.Monitor.OpenTelemetry.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
QuestPDF.Settings.License = LicenseType.Evaluation;
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }));

var appInsightsConnectionString =
    builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"];

var openTelemetry = builder.Services.AddOpenTelemetry();

if (!string.IsNullOrWhiteSpace(appInsightsConnectionString))
{
    openTelemetry.UseAzureMonitor();
}

builder.Services.AddSingleton<LoanDecisionService>();
builder.Services.AddSingleton<ApprovalLetterService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
