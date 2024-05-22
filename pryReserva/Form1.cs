using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace pryReserva
{
    public partial class Form1 : Form
    {
        Local quenaken = new Local("Quenaken", 4, 5);
        Local onas = new Local("Onas", 10, 4);
        Local tobas = new Local("Tobas", 4, 3);

        // Diccionario para mapear los locales con sus CheckBoxes correspondientes
        Dictionary<Local, List<CheckBox>> dictLocalCheckBoxes = new Dictionary<Local, List<CheckBox>>();

        // Lista para almacenar las reservas
        List<Reserva> reservas = new List<Reserva>();

        public Form1()
        {
            InitializeComponent();
            // Inicializa el diccionario
            InicializarDiccionario();
        }

        private void InicializarDiccionario()
        {
            // Agrega los locales al diccionario con una lista vacía de CheckBoxes
            dictLocalCheckBoxes.Add(quenaken, new List<CheckBox>());
            dictLocalCheckBoxes.Add(onas, new List<CheckBox>());
            dictLocalCheckBoxes.Add(tobas, new List<CheckBox>());

            // Agrega los CheckBox a las listas correspondientes
            AgregarCheckBoxes(quenaken);
            AgregarCheckBoxes(onas);
            AgregarCheckBoxes(tobas);
        }

        private void AgregarCheckBoxes(Local local)
        {
            // Agrega los CheckBox al diccionario
            for (int i = 1; i <= local.Filas * local.AsientosPorFila; i++)
            {
                CheckBox checkBox = (CheckBox)this.Controls.Find("checkBox" + i, true)[0];
                dictLocalCheckBoxes[local].Add(checkBox);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MostrarAsientos(quenaken);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            MostrarAsientos(onas);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            MostrarAsientos(tobas);
        }

        private void MostrarAsientos(Local local)
        {
            // Verifica los CheckBox según el local seleccionado
            foreach (CheckBox checkBox in dictLocalCheckBoxes[local])
            {
                // Habilita o deshabilita el CheckBox según el local seleccionado
                checkBox.Enabled = (local == quenaken && radioButton1.Checked) || (local == onas && radioButton2.Checked) || (local == tobas && radioButton3.Checked);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Guarda las reservas y muestra un mensaje de confirmación
            GuardarReservas();
        }

        private void GuardarReservas()
        {
            // Agrega las reservas a la lista
            foreach (var localCheckBoxes in dictLocalCheckBoxes)
            {
                foreach (CheckBox checkBox in localCheckBoxes.Value)
                {
                    if (checkBox.Checked)
                    {
                        string[] nombreAsiento = checkBox.Text.Split(' ');
                        Reserva reserva = new Reserva(localCheckBoxes.Key.Nombre, int.Parse(nombreAsiento[1]), int.Parse(nombreAsiento[3]));
                        reservas.Add(reserva);
                        checkBox.Enabled = false; // Deshabilita el CheckBox
                        checkBox.ForeColor = System.Drawing.Color.Gray; // Cambia el color del CheckBox a gris
                    }
                }
            }

            // Muestra un mensaje de confirmación
            MessageBox.Show("Reservas guardadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Clase Local
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
        }

        // Clase Reserva
        public class Reserva
        {
            public string Local { get; set; }
            public int Fila { get; set; }
            public int Asiento { get; set; }

            public Reserva(string local, int fila, int asiento)
            {
                Local = local;
                Fila = fila;
                Asiento = asiento;
            }
        }
    }
}
