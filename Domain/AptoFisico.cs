using System;

namespace ClubDeportivo
{
    public class AptoFisico
    {
        public int IdApto { get; set; }
        public int IdSocio { get; set; }
        public int IdMedico { get; set; }
        public DateTime Fecha { get; set; }
        public bool Aprobado { get; set; }

        public override string ToString()
        {
            string estado = Aprobado ? "Aprobado ✅" : "No Aprobado ❌";
            return $"Apto #{IdApto} | Socio: {IdSocio} | Médico: {IdMedico} | {Fecha.ToShortDateString()} | {estado}";
        }
    }
}
