using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using School_API.Data;
using School_API.Services;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

/*
 builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ILectorService, LectorService>();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 */
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

var containerBuilder = new ContainerBuilder();
containerBuilder.RegisterModule(new DependencyModule());
containerBuilder.Populate(builder.Services);
var container = containerBuilder.Build();

// Create the AutofacServiceProvider and configure it with ASP.NET Core.
var serviceProvider = new AutofacServiceProvider(container);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*var containerBuilder = new ContainerBuilder();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new DependencyModule());
    });*/


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
