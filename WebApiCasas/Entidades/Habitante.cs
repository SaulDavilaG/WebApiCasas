namespace WebApiCasas.Entidades
{
    public class Habitante
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string CURP { get; set; }
        public string INE { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set;}
        public int CasaID { get; set;}
        public Casa Casa { get; set; }
    }
}
