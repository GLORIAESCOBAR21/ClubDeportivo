namespace ClubDeportivo
{
    public class Medico
    {
        public int IdMedico { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }

        public override string ToString()
        {
            return $"{IdMedico} - {Nombre} ({Especialidad})";
        }
    }
}
