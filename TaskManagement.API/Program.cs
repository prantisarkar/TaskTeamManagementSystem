using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using TaskManagement.API.CustomMiddleware;
using TaskManagement.Application.Handlers;
using TaskManagement.Application.Validators;
using TaskManagement.DAL;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ==================== Configure Serilog ====================
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// ==================== Add Services to Container ====================

// Add Controllers
builder.Services.AddControllers();

// FluentValidation (Updated Approach)
builder.Services.AddValidatorsFromAssemblyContaining<UserCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TeamValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TaskInfoValidator>();

// Database Configuration
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    )
);

// Authentication Configuration
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "TaskManagementAPI",
        ValidAudience = "TaskManagementAPI",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecretKey12345"))
    };
});

// ==================== Swagger Configuration ====================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Task Management API",
        Version = "v1",
        Description = "API documentation for Task Management System"
    });

    // JWT Authentication Configuration for Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// MediatR (CQRS) Configuration
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(UserCommandHandler).Assembly));

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Ensure logs directory exists
var logsPath = Path.Combine(Directory.GetCurrentDirectory(), "logs");
if (!Directory.Exists(logsPath))
{
    Directory.CreateDirectory(logsPath);
}

var app = builder.Build();

// ==================== Middleware Configuration ====================

// Use Static Files (e.g., for serving logs)
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(logsPath),
    RequestPath = "/logs"
});

app.UseHttpsRedirection();

// CORS Middleware
app.UseCors("AllowAll");

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// Global Exception Handling Middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Swagger Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Management API v1");
        options.RoutePrefix = string.Empty; // Swagger at the root URL
    });
}

// Database Migration
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
    dbContext.Database.Migrate();
}

// Map Controllers
app.MapControllers();

app.Run();
