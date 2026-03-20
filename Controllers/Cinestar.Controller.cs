using Cinestar.Datos;
using Microsoft.AspNetCore.Mvc;
using Cinestar.database;
using Microsoft.Extensions.Configuration;

namespace Cinestar.Controllers
{
    public class CinestarController : Controller
    {
        private readonly daoCinestar _daoCinestar;

        public CinestarController(daoCinestar daoCinestar)
        {
            _daoCinestar = daoCinestar;
        }

        //GET: Inicio
        public IActionResult Inicio()
        {
            return View();
        }
        //GET: VerCines
        public IActionResult verCines()
        {
            return View(_daoCinestar.getVerCines() );
        }

        //GET: verCine (Requiere ID)
        public IActionResult verCine(int id)
        {
            ViewBag.Cine = _daoCinestar.getCine(id);
            ViewBag.lstCineTarifas = _daoCinestar.getCineTarifas(id);
            ViewBag.lstCinePeliculas = _daoCinestar.getCinePeliculas(id);
            return View(_daoCinestar.getCine(id));
        }

        //GET: verPeliculas (id)
        public ActionResult verPeliculas(int id)
        {
            return View(_daoCinestar.getVerPeliculas(id));
        }

        //GET: verPelicula (idPelicula)
        public ActionResult verPelicula(int id)
        {
            ViewBag.Pelicula = _daoCinestar.getVerPelicula(id);
            return View();
        }
    }
}
