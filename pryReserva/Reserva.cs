using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryReserva
{
    public class Reserva
    {
        public string Obra { get; set; }
        public Local Local { get; set; }
        public int CantidadAsientos { get; set; }

        public Reserva(string obra, Local local, int cantidadAsientos)
        {
            Obra = obra;
            Local = local;
            CantidadAsientos = cantidadAsientos;
        }
    }
}
