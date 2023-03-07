namespace WebApiCasas.Entidades
{
    public class Casa
    {
        public int ID { get; set; }
        public int largo { get; set; }
        public int ancho { get; set; }
        public int numeroCasa { get; set; }
        public string calle { get; set; }
        public int pisos { get; set; }
        public List<Habitante> habitantes { get; set; }
     }
}
