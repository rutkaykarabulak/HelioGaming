using HelioGaming.Api.IServices;
using HelioGaming.Api.Services;
using HelioGaming.Models.EntityModels;
using HelioGaming.Utils;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// inject postgre
builder.Services.AddDbContext<EFDataContext>(o =>
o.UseNpgsql(builder.Configuration.GetConnectionString(Constants.PostgreConnectionString))
);

// For unit test purposes
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
	