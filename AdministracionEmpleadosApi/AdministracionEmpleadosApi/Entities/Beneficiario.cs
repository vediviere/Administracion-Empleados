namespace AdministracionEmpleadosApi.Entities
{
    public class Beneficiario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Parentesco { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public Empleado Empleado { get; set; }
        public int EmpleadoId { get; set; }
    }
}
