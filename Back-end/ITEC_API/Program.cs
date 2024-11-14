using ITEC_API.Database;
using ITEC_API.IRepositories;
using ITEC_API.IServices;
using ITEC_API.Repositories;
using ITEC_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("ITEC-FrontEnd", policy =>
    {
        policy.WithOrigins("http://localhost:4200")  // The origin of your Angular app
              .AllowAnyHeader()                   // Allow any header
              .AllowAnyMethod();                   // Allow any HTTP method (GET, POST, etc.)
    });
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ITECDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ITECConnection")));

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseRepo, CourseRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ITEC-FrontEnd"); // Ensure this matches the CORS policy name


app.UseAuthorization();

app.MapControllers();

app.Run();
