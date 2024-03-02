using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    internal class Asignatura
    {
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public List<Nota> Notas { get; set; }

        public Asignatura(string nombre, int creditos)
        {
            Nombre = nombre;
            Creditos = creditos;
            Notas = new List<Nota>();
        }

        public void AgregarNota(string nombre, double valor, double porcentaje)
        {
            Notas.Add(new Nota(nombre, valor, porcentaje));
        }

        public double CalcularPromedioAcumulado()
        {
            double totalPonderado = 0;
            double totalPorcentaje = 0;

            foreach (var nota in Notas)
            {
                totalPonderado += nota.Valor * (nota.Porcentaje / 100);
                totalPorcentaje += nota.Porcentaje;
            }

            return totalPonderado / (totalPorcentaje / 100);
        }

        public double CalcularPromedioMinimo(double notaDeseada)
        {
            double notaActual = CalcularPromedioAcumulado();
            double porcentajeRestante = 100 - Notas.Sum(n => n.Porcentaje);
            return (notaDeseada - (notaActual * (Notas.Sum(n => n.Porcentaje) / 100))) / (porcentajeRestante / 100);
        }
    }
}
