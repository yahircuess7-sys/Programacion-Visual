using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Registro_de_Estudiantes.Form2;

namespace Registro_de_Estudiantes
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Configurar DataGridView vacío al iniciar
            dgvEstudiantes.Columns.Clear();
            dgvEstudiantes.Columns.Add("ColCarnet", "Carnet");
            dgvEstudiantes.Columns.Add("ColNombre", "Nombre");
            dgvEstudiantes.Columns.Add("ColAsignatura", "Asignatura");
            dgvEstudiantes.Columns.Add("ColNota", "Nota");

            dgvEstudiantes.Rows.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string carnet = txtBuscarCarnet.Text.Trim();

            if (string.IsNullOrEmpty(carnet))
            {
                MessageBox.Show("Por favor, ingrese un carnet.");
                return;
            }

            var estudiante = DatosCompartidos.ListaEstudiantes
                .FirstOrDefault(est => est.Carnet == carnet);

            // Limpiar tabla antes de mostrar resultados
            dgvEstudiantes.Rows.Clear();

            if (estudiante != null)
            {
                // Mostrar todas las asignaturas con su nota en la misma tabla
                foreach (var asig in estudiante.Asignaturas)
                {
                    dgvEstudiantes.Rows.Add(estudiante.Carnet, estudiante.Nombre, asig.Nombre, asig.Nota);
                }
            }
            else
            {
                MessageBox.Show("No se encontró estudiante con ese carnet.");
            }
        }
    }
}
