using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TravelWebAPI.Data;
using TravelWebAPI.Models;
using TravelWebAPI.Models.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Dependency for appsettings.json
ConfigurationManager configuration = builder.Configuration;

//Registering Database
builder.Services.AddDbContext<AppDataContext>(
        opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<IAttractionRepository, AttractionRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IItineraryRepository, ItineraryRepository>();


//Registering AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option=>option.AddDefaultPolicy(builder=>builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

AppDbIntializer.Seed(app);

app.Run();
