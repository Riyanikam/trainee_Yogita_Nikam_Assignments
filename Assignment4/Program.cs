using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Hosting;
using VisitorSecuritySys.CosmosDB;
using VisitorSecuritySys.Interface;
using VisitorSecuritySys.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICosmosDBService, CosmosDBService>();

// Register the services that were missing
builder.Services.AddScoped<IVisitorService, VisitorService>();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IOfficeService, OfficeService>();

builder.Services.AddSingleton(s =>
{
    // Retrieve the values for cosmosEndPoint and primaryKey from your configuration
    var cosmosEndPoint = "YOUR_COSMOS_ENDPOINT";
    var primaryKey = "YOUR_PRIMARY_KEY";
    return new CosmosClient(cosmosEndPoint, primaryKey);
});

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
