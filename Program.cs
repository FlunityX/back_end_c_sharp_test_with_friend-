using Microsoft.EntityFrameworkCore;
using back_end_c_sharp_test_with_friend_.Entities;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbAa8167Nguyenmanh1203Context>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));
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

// Add custom code to check database connection
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var dbContext = serviceProvider.GetRequiredService<DbAa8167Nguyenmanh1203Context>();
        dbContext.Database.EnsureCreated();
        Console.WriteLine("Database connection successful.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Failed to connect to the database: " + ex.Message);
    }
}

app.Run();