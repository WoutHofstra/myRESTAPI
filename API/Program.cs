using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using myRESTAPI.API.Config;

var builder = WebApplication.CreateBuilder(args);
var allowedHosts = builder.Configuration["AllowedHosts"];
Console.WriteLine($"Allowed hosts: {allowedHosts}");

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<Cors>(builder.Configuration.GetSection("Cors"));
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));

var app = builder.Build();

app.Run();