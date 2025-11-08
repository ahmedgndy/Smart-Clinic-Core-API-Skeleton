var builder = WebApplication.CreateBuilder(args);
// ✅ Add Swagger services


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
