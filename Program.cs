using Cinestar.Datos;
using Cinestar.database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<daoCinestar>();
builder.Services.AddScoped(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    return new ConexionBD(configuration, "CadenaSQLAzure");
});

//Configurar el URL de la aplicación para que consuma el api
builder.Services.AddHttpClient("CinestarAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7207/");
});

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

//Con el controlador principal MVC
/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cinestar}/{action=Inicio}/{id?}")
    .WithStaticAssets();
*/

//Con el controlador para consumir el API
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CinestarConsApi}/{action=Inicio}/{id?}")
    .WithStaticAssets();


app.Run();
