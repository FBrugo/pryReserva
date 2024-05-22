using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryReserva
{
    public class Local
    {
        public string Nombre { get; set; }
        public int Filas { get; set; }
        public int AsientosPorFila { get; set; }

        public Local(string nombre, int filas, int asientosPorFila)
        {
            Nombre = nombre;
            Filas = filas;
            AsientosPorFila = asientosPorFila;
        }

        public int AsientosTotales()
        {
            return Filas * AsientosPorFila;
        }
    }
}
