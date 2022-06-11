using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Movie.Core.Mapping;
using Movie.Core.Repository;
using Movie.Core.Repository.Interface;
using Movie.Core.Request;
using Movie.Core.Services;
using Movie.Core.Services.Interface;
using Movie.Core.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services DI
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IValidator<MovieRequest>, MovieValidator>();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MOVIEDB01")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

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
