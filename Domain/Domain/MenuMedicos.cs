using System;
using System.Collections.Generic;

namespace ClubDeportivo
{
    public class MenuMedicos
    {
        private readonly List<Medico> medicos = new();
        private readonly List<AptoFisico> aptos = new();

        public void MostrarMenu()
        {
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE MÉDICOS ===");
                Console.WriteLine("1) Alta Médico");
                Console.WriteLine("2) Listar Médicos");
                Console.WriteLine("3) Registrar Apto Físico de Socio");
                Console.WriteLine("4) Listar Aptos Físicos");
                Console.WriteLine("0) Volver");
                Console.Write("\nSeleccione una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AltaMedico();
                        break;
                    case "2":
                        ListarMedicos();
                        break;
                    case "3":
                        RegistrarAptoFisico();
                        break;
                    case "4":
                        ListarAptosFisicos();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        Pause();
                        break;
                }

            } while (opcion != "0");
        }

        private void AltaMedico()
        {
            Console.Write("\nID del médico: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";
            Console.Write("Especialidad: ");
            string especialidad = Console.ReadLine() ?? "";

            var medico = new Medico { IdMedico = id, Nombre = nombre, Especialidad = especialidad };
            medicos.Add(medico);

            Console.WriteLine("\n✅ Médico registrado correctamente.");
            Pause();
        }

        private void ListarMedicos()
        {
            Console.WriteLine("\n--- LISTA DE MÉDICOS ---");
            if (medicos.Count == 0)
            {
                Console.WriteLine("No hay médicos registrados.");
            }
            else
            {
                medicos.ForEach(m => Console.WriteLine(m));
            }
            Pause();
        }

        private void RegistrarAptoFisico()
        {
            if (medicos.Count == 0)
            {
                Console.WriteLine("⚠️ No hay médicos registrados.");
                Pause();
                return;
            }

            Console.Write("\nID del socio: ");
            int idSocio = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("ID del médico: ");
            int idMedico = int.Parse(Console.ReadLine() ?? "0");

            var medico = medicos.Find(m => m.IdMedico == idMedico);
            if (medico == null)
            {
                Console.WriteLine("⚠️ No existe un médico con ese ID.");
                Pause();
                return;
            }

            Console.Write("¿Apto físico aprobado? (s/n): ");
            string aprobado = Console.ReadLine()?.ToLower() ?? "n";

            var apto = new AptoFisico
            {
                IdApto = aptos.Count + 1,
                IdSocio = idSocio,
                IdMedico = idMedico,
                Fecha = DateTime.Now,
                Aprobado = aprobado == "s"
            };

            aptos.Add(apto);
            Console.WriteLine("\n✅ Apto físico registrado correctamente.");
            Pause();
        }

        private void ListarAptosFisicos()
        {
            Console.WriteLine("\n--- APTOS FÍSICOS REGISTRADOS ---");
            if (aptos.Count == 0)
            {
                Console.WriteLine("No hay aptos físicos cargados.");
            }
            else
            {
                aptos.ForEach(a => Console.WriteLine(a));
            }
            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
