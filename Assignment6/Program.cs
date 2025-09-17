using Assignmentfifth.CosmosDB;
using Assignmentfifth.Interface;
using Assignmentfifth.Services;
using static Assignmentfifth.Interface.IEmployeeAdditonalDetail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeBasicDetails, EmployeeBasicDetailService>();
builder.Services.AddScoped<IEmployeeAdditionalDetails, EmployeeAdditonalDetailService>();
builder.Services.AddScoped<ICosmosDBService, CosmosDBService>();


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

// Hello

