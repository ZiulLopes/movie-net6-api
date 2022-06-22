using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Movie.Core.Config;
using Movie.Core.Mapping;
using Movie.Core.Repository;
using Movie.Core.Repository.Interface;
using Movie.Core.Request;
using Movie.Core.Services;
using Movie.Core.Services.Interface;
using Movie.Core.Validator;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services DI
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieSQLRepository, MovieSQLRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IValidator<MovieRequest>, MovieValidator>();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var jwtConfig = new JwtBearerTokenSettings();
builder.Configuration.Bind("JwtBearerTokenSettings", jwtConfig);

builder.Services.AddSingleton(jwtConfig);

builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MOVIEDB01")));

builder.Services.AddAuthorization();
//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = new AuthorizationPolicyBuilder()
//        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
//        .RequireAuthenticatedUser()
//        .Build();
//    options.AddPolicy("EmployeePolic", p => 
//        p.RequireAuthenticatedUser().RequireClaim("EmployeePolic"));
//});
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtBearerTokenSettings:SecretKey"])),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JwtBearerTokenSettings:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtBearerTokenSettings:Audience"],
        //ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
