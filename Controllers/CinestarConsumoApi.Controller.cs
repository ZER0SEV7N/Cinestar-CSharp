using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Cinestar.Models;

namespace Cinestar.Controllers
{
    //Controlador para consumir el WebApi de cinestar
    //Este controlador es aparte del controlador principal.
    public class CinestarConsApi : Controller
    {
        //Inyectar el HttpClient
        private readonly HttpClient _httpClient;

        //Constructor inicializando el HttpClient
        public CinestarConsApi(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("CinestarAPI");
        }

        //Inicio
        //Ruta: localhost:puerto/CinestarConsApi/Inicio
        public IActionResult Inicio()
        {
            return View("~/Views/CinestarConsApi/Inicio.cshtml");
        }

        //Get: Cinestar/nuestrosCines
        public async Task<IActionResult> nuestrosCines()
        {
            var res = await _httpClient.GetAsync("api/cinestarapi/nuestrosCines");
            //Si la respuesta es exitosa, deserializar el JSON a una lista y pasarle la vista
            if (res.IsSuccessStatusCode)
            {
                var json = await res.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var cines = JsonSerializer.Deserialize<List<Cine>>(json, opciones);

                return View("~/Views/CinestarConsApi/nuestrosCines.cshtml", cines);
            }
            //Si no es exitosa, pasarle una lista vacía a la vista
            return View(new List<Cine>());
        }

        //Get: Cinestar/verCine/{id}
        public async Task<IActionResult> verCine(int id)
        {
            //Opciones para deserializar
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            //Inicializar las vistas
            ViewBag.lstCineTarifas = new List<CineTarifa>();
            ViewBag.lstCinePeliculas = new List<CinePelicula>();

            //Recuperar el cine por su id
            var resCine = await _httpClient.GetAsync($"api/cinestarapi/nuestrosCines/{id}");
            Cine cine = resCine.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<Cine>(await resCine.Content.ReadAsStringAsync(), opciones) : new Cine();

            //Recuperar las tarifas del cine por su id
            var resTarifas = await _httpClient.GetAsync($"api/cinestarapi/tarifas/{id}");
            if (resTarifas.IsSuccessStatusCode)
                ViewBag.lstCineTarifas = JsonSerializer.Deserialize<List<CineTarifa>>(await resTarifas.Content.ReadAsStringAsync(), opciones);

            //Recuperar las peliculas del cine por su id
            var resPeliculas = await _httpClient.GetAsync($"api/cinestarapi/cartelera/{id}");
            if (resPeliculas.IsSuccessStatusCode)
                ViewBag.lstCinePeliculas = JsonSerializer.Deserialize<List<CinePelicula>>(await resPeliculas.Content.ReadAsStringAsync(), opciones);

            ViewBag.cine = cine;

            return View("~/Views/CinestarConsApi/verCine.cshtml", cine);
        }

        //Get: Cinestar/cartelera/{id}
        public async Task<IActionResult> cartelera(int id)
        {
            var res = await _httpClient.GetAsync($"api/cinestarapi/cartelera/{id}");

            if (res.IsSuccessStatusCode)
            {
                var json = await res.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var peliculas = JsonSerializer.Deserialize<List<Pelicula>>(json, opciones);
                return View("~/Views/CinestarConsApi/cartelera.cshtml", peliculas);
            }
            return View(new List<Pelicula>());
        }

        //Get: Cinestar/verPelicula/{id}
        public async Task<IActionResult> verPelicula(int id)
        {
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resPelicula = await _httpClient.GetAsync($"api/cinestarapi/cartelera/pelicula/{id}");

            //Si la respuesta es exitosa, deserializar el JSON a un objeto Pelicula y pasarle la vista
            if (resPelicula.IsSuccessStatusCode)
            {
                var json = await resPelicula.Content.ReadAsStringAsync();
                var pelicula = JsonSerializer.Deserialize<Pelicula>(json, opciones);

                ViewBag.Pelicula = pelicula;
                return View("~/Views/CinestarConsApi/verPelicula.cshtml");
            }

            //Si no es exitosa, pasarle un objeto Pelicula vacío a la vista
            ViewBag.Pelicula = new Pelicula();
            return View("~/Views/CinestarConsApi/verPelicula.cshtml");
        }
    }
}
