using Microsoft.Data.SqlClient;
namespace Cinestar.database
{
    public class Conexion
    {
        //Cadena de conexion
        private string cadenaSQL = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            //Inicializar la cadena de conexion
            cadenaSQL = builder.GetSection("ConnectionStrings").Value ?? string.Empty;
        }

        //Metodo para obtener la cadena de conexion
        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}
