using Microsoft.EntityFrameworkCore;
using MyVaccineWebApi.Configurations;
using MyVaccineWebApi.Literals;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Repositories.Contracts;
using MyVaccineWebApi.Repositories.Implements;
using MyVaccineWebApi.Services.Contract;
using MyVaccineWebApi.Services.Implements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Set up database configuration
builder.Services.SetDatabaseConfiguration();

// Set up authentication configuration
builder.Services.SetMyVaccineAuthConfiguration();

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IDependentRepository, DependentRepository>();
builder.Services.AddScoped<IVaccineCategoryRepository, VaccineCategoryRepository>();
builder.Services.AddScoped<IVaccineRepository, VaccineRepository>();
builder.Services.AddScoped<IAllergyRepository, AllergyRepository>();
builder.Services.AddScoped<IFamilyGroupRepository, FamilyGroupRepository>();
builder.Services.AddScoped<IVaccineRecordRepository, VaccineRecordRepository>();
// Register services
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IDependentService, DependentService>();
builder.Services.AddScoped<IVaccineCategoryService, VaccineCategoryService>();
builder.Services.AddScoped<IVaccineService, VaccineService>();
builder.Services.AddScoped<IAllergyService, AllergyService>();
builder.Services.AddScoped<IFamilyGroupService, FamilyGroupService>();
builder.Services.AddScoped<IVaccineRecordService, VaccineRecordService>();

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
