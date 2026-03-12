using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinestar.Controllers
{
    public class PeliculaController : Controller
    {
        // GET: verPeliculas (id)
        public ActionResult verPeliculas(int id)
        {
            return View();
        }

        // GET: verPelicula (idPelicula)
        public ActionResult verPelicula(int idPelicula)
        {
            return View();
        }
    }
}
