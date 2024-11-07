using BareInternationalTest.BL;
using BareInternationalTest.DL;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped(sp => new Connection(connectionString));

// Register repositories
builder.Services.AddScoped<DictionaryRepository>();

// Register services
builder.Services.AddScoped<DictionaryService>();


//for logging
/*builder.Logging.ClearProviders();  // Remove the default providers
builder.Logging.SetMinimumLevel(LogLevel.Trace);  // Optional: Set the minimum logging level*/
builder.Host.UseNLog();  // Integrates NLog with the ASP.NET Core pipeline


var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dictionary}/{action=Index}");


app.MapControllers();


app.Run();
