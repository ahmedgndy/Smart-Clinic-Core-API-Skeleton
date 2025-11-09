using Microsoft.EntityFrameworkCore;
using Smart_Clinic_Core_APi.Infrastructur;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();

//  Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ClinicDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Enable Swagger only in development (optional)
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartClinic API v1");
        c.RoutePrefix = string.Empty; // makes Swagger open at root URL
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();



app.Run();
