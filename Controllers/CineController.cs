using Cinestar.Datos;
using Microsoft.AspNetCore.Mvc;
using Cinestar.database;
using Microsoft.Extensions.Configuration;

namespace Cinestar.Controllers
{
    public class CineController : Controller
    {
        private readonly daoCine daoCine;

        public CineController(IConfiguration configuration)
        {
            daoCine = new daoCine(configuration);
        }

        //GET: Inicio
        public IActionResult Inicio()
        {
            return View();
        }
        //GET: VerCines
        public IActionResult verCines()
        {
            return View(daoCine.getVerCines() );
        }

        //GET: verCine (Requiere ID)
        public IActionResult verCine(int id)
        {
            ViewBag.Cine = daoCine.getCine(id);
            ViewBag.lstCineTarifas = daoCine.getCineTarifas(id);
            ViewBag.lstCinePeliculas = daoCine.getCinePeliculas(id);
            return View(daoCine.getCine(id));
        }
    }
}
