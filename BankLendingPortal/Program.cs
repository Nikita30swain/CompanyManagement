
using BankLendingPortal.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DefaultContext>(opt =>
{
    opt.UseSqlServer();
    //opt.EnableSensitiveDataLogging();
    opt.EnableServiceProviderCaching();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
/*
var conStr = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DefaultContext>(opt =>
{
    opt.UseSqlServer(conStr, config =>
    {
        config.EnableRetryOnFailure();
    });
    opt.EnableDetailedErrors();
    opt.EnableSensitiveDataLogging();
});
*/


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
