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
var containerBuilder = new ContainerBuilder();

containerBuilder.RegisterType<LectorService>().As<ILectorService>().InstancePerLifetimeScope();
containerBuilder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>().InstancePerLifetimeScope();

containerBuilder.RegisterAssemblyTypes(typeof(Program).Assembly)
    .Where(t => t.Name.EndsWith("Profile"))
    .As<Profile>();


containerBuilder.Register(c =>
{
    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    return optionsBuilder.Options;
}).As<DbContextOptions<ApplicationDbContext>>().InstancePerLifetimeScope();

containerBuilder.Populate(builder.Services);

var container = containerBuilder.Build();

var serviceProvider = new AutofacServiceProvider(container);


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
