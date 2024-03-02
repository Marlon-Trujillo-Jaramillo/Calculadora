using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    internal class Program
    {
        public static List<Asignatura> asignaturas = new List<Asignatura>();
        static void Main(string[] args)
        {

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("1. Agregar nueva asignatura");
                Console.WriteLine("2. Agregar notas a una asignatura");
                Console.WriteLine("3. Calcular promedio acumulado de una asignatura");
                Console.WriteLine("4. Calcular promedio mínimo necesario para alcanzar una nota deseada en una asignatura");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarAsignatura();
                        break;
                    case "2":
                        AgregarNotas();
                        break;
                    case "3":
                        CalcularPromedioAcumulado();
                        break;
                    case "4":
                        CalcularPromedioMinimo();
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
        }
        public static void AgregarAsignatura()
        {
            Console.WriteLine("\nAgregar nueva asignatura:");
            Console.Write("Nombre de la asignatura: ");
            string nombre = Console.ReadLine();
            Console.Write("Número de créditos: ");
            int creditos = int.Parse(Console.ReadLine());

            asignaturas.Add(new Asignatura(nombre, creditos));

            Console.WriteLine("Asignatura agregada correctamente.\n");
        }

        public static void AgregarNotas()
        {
            Console.WriteLine("\nAgregar notas a una asignatura:");
            ListarAsignaturas();

            Console.Write("Seleccione la asignatura: ");
            int indiceAsignatura = int.Parse(Console.ReadLine()) - 1;

            if (indiceAsignatura < 0 || indiceAsignatura >= asignaturas.Count)
            {
                Console.WriteLine("Índice de asignatura no válido.");
                return;
            }

            Console.Write("Nombre de la nota: ");
            string nombreNota = Console.ReadLine();
            Console.Write("Valor de la nota: ");
            double valorNota = double.Parse(Console.ReadLine());
            Console.Write("Porcentaje de la nota (0-100): ");
            double porcentajeNota = double.Parse(Console.ReadLine());

            asignaturas[indiceAsignatura].AgregarNota(nombreNota, valorNota, porcentajeNota);

            Console.WriteLine("Nota agregada correctamente a la asignatura.\n");
        }

        public static void CalcularPromedioAcumulado()
        {
            Console.WriteLine("\nCalcular promedio acumulado de una asignatura:");
            ListarAsignaturas();

            Console.Write("Seleccione la asignatura: ");
            int indiceAsignatura = int.Parse(Console.ReadLine()) - 1;

            if (indiceAsignatura < 0 || indiceAsignatura >= asignaturas.Count)
            {
                Console.WriteLine("Índice de asignatura no válido.");
                return;
            }

            double promedio = asignaturas[indiceAsignatura].CalcularPromedioAcumulado();
            Console.WriteLine($"El promedio acumulado de la asignatura {asignaturas[indiceAsignatura].Nombre} es: {promedio:F2}\n");
        }

        public static void CalcularPromedioMinimo()
        {
            Console.WriteLine("\nCalcular promedio mínimo necesario para alcanzar una nota deseada en una asignatura:");
            ListarAsignaturas();

            Console.Write("Seleccione la asignatura: ");
            int indiceAsignatura = int.Parse(Console.ReadLine()) - 1;

            if (indiceAsignatura < 0 || indiceAsignatura >= asignaturas.Count)
            {
                Console.WriteLine("Índice de asignatura no válido.");
                return;
            }

            Console.Write("Ingrese la nota deseada: ");
            double notaDeseada = double.Parse(Console.ReadLine());

            double promedioMinimo = asignaturas[indiceAsignatura].CalcularPromedioMinimo(notaDeseada);
            Console.WriteLine($"El promedio mínimo necesario para alcanzar una nota de {notaDeseada} en la asignatura {asignaturas[indiceAsignatura].Nombre} es: {promedioMinimo:F2}\n");
        }

        public static void ListarAsignaturas()
        {
            Console.WriteLine("\nListado de asignaturas:");
            for (int i = 0; i < asignaturas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {asignaturas[i].Nombre}");
            }
        }

    }
}
