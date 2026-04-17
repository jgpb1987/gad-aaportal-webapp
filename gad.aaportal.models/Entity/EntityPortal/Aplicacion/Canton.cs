namespace gad.aaportal.models.Entity.Aplicacion
{
    public class Canton
    {
        public int Id { get; set; }
        public string Provincia { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public bool Seleccionado { get; set; }
    }
}
