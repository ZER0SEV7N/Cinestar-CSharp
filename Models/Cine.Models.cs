namespace Cinestar.Models
{
    //Modelo de Cine
    public class Cine
    {
        //Id del cine
        public int id { get; set; }

        //Razon Social
        public string RazonSocial { get; set; }

        //Salas
        public int Salas { get; set; }

        //idDistrito
        public int idDistrito { get; set; }

        //Direccion
        public string Direccion { get; set; }

        //Telefonos
        public string Telefonos { get; set; }

        public bool Valido { get; set; }

        public string Detalle { get; set; }

        public Cine() { }
         
        public Cine(string[] aRegistro)
        {
            setRegistro(aRegistro);
        }

        internal void setRegistro(string[] aRegistro)
        {
            Valido = aRegistro != null;
            if (!Valido) return;
            id = int.Parse(aRegistro[0]);
            RazonSocial = aRegistro[1];
            Salas = int.Parse(aRegistro[2]);
            idDistrito = int.Parse(aRegistro[3]);
            Direccion = aRegistro[4];
            Telefonos = aRegistro[5];
            Detalle = aRegistro[6];
        }

        internal List<Cine> getList(string[][] mRegistros)
        {
            if (mRegistros == null) return null;

            List<Cine> lstCine = new List<Cine>();
            foreach (string[] aRegistro in mRegistros)
            {
                lstCine.Add(new Cine(aRegistro));
            }
            return lstCine;
        }
    }
}
