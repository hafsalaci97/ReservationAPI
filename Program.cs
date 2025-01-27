using Microsoft.EntityFrameworkCore;
using ReservationAPI.Data;  // Make sure this matches your project's namespace
using ReservationAPI.Models; // If your Reservation model is in a different folder, adjust the namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register EF Core with MySQL database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ReservationContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add CORS service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // Allow any origin (you can restrict this to specific domains later)
              .AllowAnyMethod()   // Allow any HTTP method (GET, POST, etc.)
              .AllowAnyHeader();  // Allow any headers
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable CORS for the app (apply the policy)
app.UseCors("AllowAll"); // <-- Add this line to allow cross-origin requests

// Serve static files from wwwroot folder
app.UseStaticFiles(); // <-- This line is already here

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Disable HTTPS redirection for local development (if needed)
if (app.Environment.IsDevelopment())
{
    // Remove or comment out this line to avoid issues with HTTPS redirection in development
    // app.UseHttpsRedirection(); 
}

app.UseAuthorization();

app.MapControllers();

app.Run();
