using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    internal class Asignatura
    {
        public string Nombre { get; private set; }
        public List<(double calificacion, double porcentaje)> Calificaciones { get; private set; }

        public Asignatura()
        {
            Calificaciones = new List<(double, double)>();
        }

        public void AgregarCalificacion(double calificacion, double porcentaje)
        {
            Calificaciones.Add((calificacion, porcentaje));
            Console.WriteLine("Calificación agregada correctamente.");
        }

        public double CalcularPromedioAcumulado()
        {
            double sumaProductos = 0;
            double sumaPorcentajes = 0;

            foreach (var calificacion in Calificaciones)
            {
                sumaProductos += calificacion.calificacion * calificacion.porcentaje;
                sumaPorcentajes += calificacion.porcentaje;
            }

            if (sumaPorcentajes == 0)
            {
                Console.WriteLine("No se pueden calcular promedio, no hay notas ingresadas.");
                return 0;
            }

            return sumaProductos / sumaPorcentajes;
        }

        public double CalcularPromedioMinimo(double notaDeseada)
        {
            double sumaPorcentajes = 0;
            foreach (var calificacion in Calificaciones)
            {
                sumaPorcentajes += calificacion.porcentaje;
            }

            double porcentajeRestante = 100 - sumaPorcentajes;
            if (porcentajeRestante <= 0)
            {
                Console.WriteLine("No se puede calcular el promedio mínimo, se han ingresado el 100% de las notas.");
                return 0;
            }

            double sumaProductos = notaDeseada * porcentajeRestante;
            foreach (var calificacion in Calificaciones)
            {
                sumaProductos -= calificacion.calificacion * calificacion.porcentaje;
            }

            return sumaProductos / porcentajeRestante;
        }

        public void IngresarDatosAsignatura()
        {
            Console.Write("Ingrese el nombre de la asignatura: ");
            Nombre = Console.ReadLine();

            Console.Write("Ingrese la cantidad de notas: ");
            int cantidadNotas = Convert.ToInt32(Console.ReadLine());

            double porcentajeTotal = 0;
            for (int i = 0; i < cantidadNotas; i++)
            {
                Console.Write($"Ingrese el porcentaje de la nota {i + 1}: ");
                double porcentaje = Convert.ToDouble(Console.ReadLine());

                while (porcentajeTotal + porcentaje > 100)
                {
                    Console.WriteLine("Error: La suma de los porcentajes no puede superar el 100%.");
                    Console.Write($"Ingrese un porcentaje válido para la nota {i + 1}: ");
                    porcentaje = Convert.ToDouble(Console.ReadLine());
                }
                porcentajeTotal += porcentaje;

                Console.Write($"Ingrese la calificación de la nota {i + 1}: ");
                double calificacion = Convert.ToDouble(Console.ReadLine());

                AgregarCalificacion(calificacion, porcentaje);
            }
        }
    }
}
