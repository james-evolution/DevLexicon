using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DevLexicon.Data;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

// Add database context configured to use SQL Server.
builder.Services.AddDbContext<DevLexiconContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevLexiconContext") ?? throw new InvalidOperationException("Connection string 'DevLexiconContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Enable Swagger/OpenAPI for minimal APIs
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS: allow development client apps to call the API (adjust origins for production)
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCors", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(_ => true) // permissive for development; restrict in production
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Enable CORS before authorization for API endpoints
app.UseCors("DefaultCors");

app.UseAuthorization();

// Enable Swagger middleware and UI
app.UseSwagger();
app.UseSwaggerUI();

app.MapStaticAssets();

// Define the default route for controllers.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Minimal API endpoint: fetch all tech terms
app.MapGet("/api/techterms", async (DevLexiconContext db) =>
{
    return await db.TechTerm.AsNoTracking().ToListAsync();
});

// Expose Scalar UI for testing (reads OpenAPI from Swashbuckle)
app.MapScalarApiReference(options =>
{
    options.Title = "DevLexicon API";
    options.OpenApiRoutePattern = "/swagger/v1/swagger.json";
});


app.Run();