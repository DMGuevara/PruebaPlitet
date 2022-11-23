namespace RestDemo.Models
{
    public class EmpleadoInfo
    {
        public int empleado_id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public decimal sueldo { get; set; }
    }
}
