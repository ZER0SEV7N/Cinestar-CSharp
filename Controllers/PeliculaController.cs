using Microsoft.AspNetCore.Mvc;
using Cinestar.Datos;

namespace Cinestar.Controllers
{
    public class PeliculaController : Controller
    {
        private readonly daoPelicula daoPelicula;

        public PeliculaController(IConfiguration config)
        {
            daoPelicula = new daoPelicula(config);
        }
        //GET: verPeliculas (id)
        public ActionResult verPeliculas(int id)
        {
            return View(daoPelicula.getVerPeliculas(id));
        }

        //GET: verPelicula (idPelicula)
        public ActionResult verPelicula(int id)
        {
            ViewBag.Pelicula = daoPelicula.getVerPelicula(id);
            return View();
        }
    }
}
