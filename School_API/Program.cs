using Microsoft.EntityFrameworkCore;
using School_API.Data;
using School_API.Services;

var builder = WebApplication.CreateBuilder(args);
//task1
// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program).Assembly);
services.AddScoped<ILectorService, LectorService>();
services.AddScoped<IApplicationDbContext, ApplicationDbContext>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
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
