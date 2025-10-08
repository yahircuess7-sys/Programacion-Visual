using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro_de_Estudiantes
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public class Estudiante
        {
            public string Carnet { get; set; }
            public string Nombre { get; set; }
            public List<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
        }

        public class Asignatura
        {
            public string Nombre { get; set; }
            public double Nota { get; set; }
        }

        // Lista global para guardar varios estudiantes
        public static class DatosCompartidos
        {
            public static List<Estudiante> ListaEstudiantes { get; set; } = new List<Estudiante>();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            dgvAsignaturas.Columns.Add("ColAsignatura", "Asignatura");
            dgvAsignaturas.Columns.Add("ColNota", "Nota Final");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //lo presione por error
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            Estudiante estudiante = new Estudiante
            {
                Carnet = txtCarnet.Text,
                Nombre = txtNombre.Text
            };

            foreach (DataGridViewRow fila in dgvAsignaturas.Rows)
            {
                if (fila.Cells[0].Value != null && fila.Cells[1].Value != null)
                {
                    estudiante.Asignaturas.Add(new Asignatura
                    {
                        Nombre = fila.Cells[0].Value.ToString(),
                        Nota = Convert.ToDouble(fila.Cells[1].Value)
                    });
                }
            }

            DatosCompartidos.ListaEstudiantes.Add(estudiante);
            MessageBox.Show("Estudiante agregado con éxito ✅");
            this.Close();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            //lo presione por error 
        }
    }
}
