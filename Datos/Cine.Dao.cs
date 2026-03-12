using Cinestar.database;
using Cinestar.Models;
using Microsoft.Extensions.Configuration;

namespace Cinestar.Datos
{
    public class daoCine
    {
        private readonly clsBD clsBD;

        //Constructor para inicializar la clase clsBD con la configuración de la cadena de conexión
        public daoCine(IConfiguration configuration)
        {
            clsBD = new clsBD(configuration, "CadenaSQLLocal");
        }

        //Metodo para obtener un cine en especifico
        internal Cine getCine(int idCine)
        {
            clsBD.Setencia($"exec sp_getCine {idCine}");

            Cine cine = new Cine();
            cine.setRegistro(clsBD.getRegistro());

            return cine;
        }

        //Metodo para obtener la lista de cines
        internal List<Cine> getVerCines()
        {
            clsBD.Setencia("exec sp_getCines");
            return new Cine().getList(clsBD.getRegistros());
        }

        //Metodo para obtener las tarifas de un cine
        internal dynamic getCineTarifas(int idCine)
        {
            clsBD.Setencia($"exec sp_getCineTarifas {idCine}");
            return new CineTarifa().getList(clsBD.getRegistros());
        }

        //Metodo para obtener las peliculas de un cine
        internal dynamic getCinePeliculas(int idCine)
        {
            clsBD.Setencia($"exec sp_getCinePeliculas {idCine}");
            return new CinePelicula().getList(clsBD.getRegistros());
        }
    }
}
