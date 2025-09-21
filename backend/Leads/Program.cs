using AutoMapper;
using LeadsAPI.Data;
using LeadsAPI.Mappings;
using LeadsAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<LeadsDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


builder.Services.AddScoped<IEmailService, FileEmailService>();


builder.Services.AddCors(o => o.AddPolicy("AllowFrontend", policy =>
{
    policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
}));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();
app.Run();
