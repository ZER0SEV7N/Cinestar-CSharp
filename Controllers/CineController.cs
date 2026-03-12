using Microsoft.AspNetCore.Mvc;

namespace Cinestar.Controllers
{
    public class CineController : Controller
    {
        //GET: Inicio
        public IActionResult Inicio()
        {
            return View();
        }
        //GET: VerCines
        public IActionResult verCines()
        {
            return View();
        }
        //GET: verCine (Requiere ID)
        public IActionResult verCine(int idCine)
        {
            return View();
        }
    }
}
