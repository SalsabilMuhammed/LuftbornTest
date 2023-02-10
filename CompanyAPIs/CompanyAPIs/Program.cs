using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfiles());
});
IMapper autoMapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(autoMapper);
builder.Services.AddControllers();
builder.Services.AddDbContext<DataBaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnStr"));

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});
builder.Services.AddCors(c =>
{
    c.AddDefaultPolicy(policy =>
        policy
                .AllowAnyOrigin() // allow any origin
                .AllowAnyMethod()
                .AllowAnyHeader());
});
var app = builder.Build();
using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    if (!serviceScope.ServiceProvider.GetService<DataBaseContext>().AllMigrationsApplied())
    {
        serviceScope.ServiceProvider.GetService<DataBaseContext>().Database.Migrate();
    }
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    DataSeeding.Initialize(services);
}
app.UseCors();
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
