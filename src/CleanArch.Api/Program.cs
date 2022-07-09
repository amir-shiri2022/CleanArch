using CleanArch.Application;
using CleanArch.Infrastructure;
using CleanArch.Shared;
using CleanArch.Shared.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddShared();
builder.Services.AddApplications();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseShared();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
