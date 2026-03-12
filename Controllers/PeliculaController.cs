using Microsoft.AspNetCore.Mvc;
using Cinestar.database; // Asegúrate de importar el namespace de clsBD
using Microsoft.Extensions.Configuration;
using Cinestar.Datos;

namespace Cinestar.Controllers
{
    public class PeliculaController : Controller
    {
        daoPelicula daoPelicula = new daoPelicula();
        private readonly IConfiguration _config;

        //Inyectamos IConfiguration a través del constructor
        public PeliculaController(IConfiguration config)
        {
            _config = config;
        }
        //GET: verPeliculas (id)
        public ActionResult verPeliculas(int id)
        {
            return View();
        }

        //GET: verPelicula (idPelicula)
        public ActionResult verPelicula(int idPelicula)
        {
            return View();
        }
    }
}
