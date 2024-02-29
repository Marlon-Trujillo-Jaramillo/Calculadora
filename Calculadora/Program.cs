using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Asignatura matematicas = new Asignatura();
                matematicas.IngresarDatosAsignatura();

                // Calcular promedio acumulado de las calificaciones
                double promedioAcumulado = matematicas.CalcularPromedioAcumulado();
                Console.WriteLine($"El promedio acumulado de {matematicas.Nombre} es: {promedioAcumulado}");

                // Calcular promedio mínimo para alcanzar una nota deseada
                Console.Write("Ingrese la nota deseada: ");
                double notaDeseada = Convert.ToDouble(Console.ReadLine());
                double promedioMinimo = matematicas.CalcularPromedioMinimo(notaDeseada);
                Console.WriteLine($"El promedio mínimo necesario para obtener una nota de {notaDeseada} en {matematicas.Nombre} es: {promedioMinimo}");              
            }
            catch 
            { 
                Console.WriteLine("Verifique su informacion"); 
            }
            
        }
    }
}
