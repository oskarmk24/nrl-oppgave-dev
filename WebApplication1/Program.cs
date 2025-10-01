using MySqlConnector;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Legger til st�tte for MVC (controllers + views)
builder.Services.AddControllersWithViews();

// Henter connection string fra appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Oppretter en databaseforbindelse med connection pooling
builder.Services.AddSingleton(sp => new MySqlDataSourceBuilder(connectionString).Build());

// Registrerer v�rt repository slik at det kan brukes i controllers
builder.Services.AddScoped<ReportsRepository>();

var app = builder.Build();

// Konfigurerer hvordan appen skal h�ndtere HTTP-foresp�rsler
if (!app.Environment.IsDevelopment())
{
    // Viser en feilsiden hvis noe g�r galt (i produksjon)
    app.UseExceptionHandler("/Home/Error");

    // Legger p� sikkerhetsheader for HTTPS
    app.UseHsts();
}

// Tvinger HTTPS i stedet for HTTP
app.UseHttpsRedirection();

// Setter opp routing (hvilke URL-er som g�r til hvilke controllers)
app.UseRouting();

// Sjekker tilgang/autorisasjon (ikke brukt mye her, men klart for senere)
app.UseAuthorization();

// Gj�r det mulig � bruke statiske filer (CSS, JS, bilder)
app.MapStaticAssets();

// Standard route: kj�rer HomeController -> Index som startside
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Starter applikasjonen
app.Run();

