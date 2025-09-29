using MySqlConnector;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Henter connection string fra �appsettings.json� filen
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Oppretter en instans av MySqlConnection
//builder.Services.AddSingleton(new MySqlConnection(connectionString));

//Replace raw connection with pooled datasource
builder.Services.AddSingleton(sp => new MySqlDataSourceBuilder(connectionString).Build());

//Register your Dapper repository
builder.Services.AddScoped<ReportsRepository>();

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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
