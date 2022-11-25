namespace AdministracionEmpleadosApi.Entities
{
    public class Empleado
    {
        public int Id { get; set; }
        public byte[] Foto { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public double Salario { get; set; }
        public bool Estatus { get; set; }
        public DateTime FechaContratacion { get; set; }
        public List<Beneficiario> Beneficiarios { get; set; }
    }
}
