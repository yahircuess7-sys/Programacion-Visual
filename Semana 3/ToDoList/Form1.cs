using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{

    public partial class Form1 : Form
    {
        public class Tarea
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public DateTime Fecha { get; set; }
            public string Lugar { get; set; }
            public string Estado { get; set; }
        }
        List<Tarea> listaTareas = new List<Tarea>();
        public Form1()
        {

            InitializeComponent();

            cmbBuscar.Items.Clear();
            cmbBuscar.Items.AddRange(new object[] { "Por codigo", "Por Estado", "Por Rango de Fecha" });
            cmbBuscar.SelectedIndex = 0;



            // Se ocultan los cositos dtp
            if (this.Controls.Contains(dtpDesde)) dtpDesde.Visible = false;
            if (this.Controls.Contains(dtpHasta)) dtpHasta.Visible = false;
            if (this.Controls.Contains(cbpros)) dtpHasta.Visible = false;




        }
        // para el refresh
        private void ActualizarGrid()
        {
            dgvTareas.DataSource = null;
            dgvTareas.DataSource = listaTareas;
        }
        // para el agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Debe ingresar un código.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar una descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLugar.Text))
            {
                MessageBox.Show("Debe ingresar un lugar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLugar.Focus();
                return;
            }

            if (cmbEstado.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbEstado.Focus();
                return;
            }

            // Si todos los campos están llenos, proceder con la agregación
            Tarea nueva = new Tarea()
            {
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Fecha = dtpFecha.Value,
                Lugar = txtLugar.Text,
                Estado = cmbEstado.SelectedItem.ToString()
            };

            listaTareas.Add(nueva);
            ActualizarGrid();
            MessageBox.Show("Tarea agregada correctamente.");
            LimpiarDatos();
        }
        private void LimpiarDatos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtLugar.Clear();

            dtpFecha.Value = DateTime.Now;
            cmbEstado.SelectedIndex = -1;
            txtCodigo.Focus();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTareas.SelectedRows.Count > 0)
            {
                int index = dgvTareas.SelectedRows[0].Index;
                listaTareas[index].Codigo = txtCodigo.Text;
                listaTareas[index].Nombre = txtNombre.Text;
                listaTareas[index].Descripcion = txtDescripcion.Text;
                listaTareas[index].Fecha = dtpFecha.Value;
                listaTareas[index].Lugar = txtLugar.Text;
                listaTareas[index].Estado = cmbEstado.SelectedItem.ToString();

                ActualizarGrid();
                MessageBox.Show("Tarea editada correctamente.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTareas.SelectedRows.Count > 0)
            {
                int index = dgvTareas.SelectedRows[0].Index;
                listaTareas.RemoveAt(index);
                ActualizarGrid();
                MessageBox.Show("Tarea eliminada correctamente.");
            }
        }

        private void cmbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cmbBuscar.SelectedItem?.ToString();

            bool esRango = opcion == "Por Rango de Fecha";

            // ++ controles para los txt y el date del rango
            if (this.Controls.Contains(txtBuscar)) txtBuscar.Visible = !esRango;
            if (this.Controls.Contains(dtpDesde)) dtpDesde.Visible = esRango;
            if (this.Controls.Contains(dtpHasta)) dtpHasta.Visible = esRango;
            if (this.Controls.Contains(cbpros)) cbpros.Visible = opcion == "Por Estado";
            if (opcion== "Por Estado")
            {
             txtBuscar.Visible = false;
            }
        }
        //vacio pq lo modifiqué sin querer (perdón)
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {



        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbBuscar.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un tipo de búsqueda.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string opcion = cmbBuscar.SelectedItem.ToString();

            // Por si acaso, si la lista esta vacia...
            if (listaTareas == null || listaTareas.Count == 0)
            {
                MessageBox.Show("No hay tareas para buscar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<Tarea> resultados = new List<Tarea>();

            switch (opcion)
            {
                case "Por codigo":
                    string textoCodigo = (txtBuscar.Text ?? "").Trim();
                    if (string.IsNullOrEmpty(textoCodigo))
                    {
                        MessageBox.Show("Ingrese el código a buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Búsqueda que contenga el texto, case-insensitive, funcion principal
                    resultados = listaTareas
                        .Where(t => !string.IsNullOrEmpty(t.Codigo) &&
                                    t.Codigo.IndexOf(textoCodigo, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();
                    break;
                case "Por Estado":
                    txtBuscar.Visible = false;

                    string estadoSeleccionado = (cbpros.SelectedItem?.ToString() ?? "").Trim();

                    if (string.IsNullOrEmpty(estadoSeleccionado))
                    {
                        MessageBox.Show("Seleccione un estado en la lista desplegable.",
                                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    resultados = listaTareas
                        .Where(t => !string.IsNullOrEmpty(t.Estado) &&
                                    t.Estado.Equals(estadoSeleccionado, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;


                case "Por Rango de Fecha":
                    // leer las fechas de los datetimepickers
                    DateTime desde = dtpDesde.Value.Date;
                    DateTime hasta = dtpHasta.Value.Date;

                    if (desde > hasta)
                    {
                        MessageBox.Show("La fecha 'Desde' no puede ser mayor que 'Hasta'.", "Error en fechas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    resultados = listaTareas
                        .Where(t => t.Fecha.Date >= desde && t.Fecha.Date <= hasta)
                        .ToList();
                    break;

                default:
                    resultados = listaTareas.ToList(); // fallback 
                    break;
            }

            // Mostrar resultados en el grid
            dgvTareas.DataSource = null;
            dgvTareas.DataSource = resultados; 
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ActualizarGrid();
            if (this.Controls.Contains(txtBuscar)) txtBuscar.Text = "";
            cmbBuscar.SelectedIndex = 0;
        }

        private void dgvTareas_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvTareas.CurrentRow != null && dgvTareas.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgvTareas.CurrentRow;

                txtCodigo.Text = fila.Cells[0].Value?.ToString() ?? "";
                txtNombre.Text = fila.Cells[1].Value?.ToString() ?? "";
                txtDescripcion.Text = fila.Cells[2].Value?.ToString() ?? "";

                // Manejar la fecha de forma segura
                if (fila.Cells[3].Value != null && DateTime.TryParse(fila.Cells[3].Value.ToString(), out DateTime fecha))
                {
                    dtpFecha.Value = fecha;
                }
                 
                txtLugar.Text = fila.Cells[4].Value?.ToString() ?? "";

                string estado = fila.Cells[5].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(estado) && cmbEstado.Items.Contains(estado))
                {
                    cmbEstado.SelectedItem = estado;
                }
                else
                {
                    cmbEstado.SelectedIndex = -1;
                }
            }
        }

        private void dgvTareas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // para evitar encabezado
            {
                DataGridViewRow fila = dgvTareas.Rows[e.RowIndex];

                txtCodigo.Text = fila.Cells[0].Value?.ToString() ?? "";
                txtNombre.Text = fila.Cells[1].Value?.ToString() ?? "";
                txtDescripcion.Text = fila.Cells[2].Value?.ToString() ?? "";

                if (fila.Cells[3].Value != null && DateTime.TryParse(fila.Cells[3].Value.ToString(), out DateTime fecha))
                {
                    dtpFecha.Value = fecha;
                }

                txtLugar.Text = fila.Cells[4].Value?.ToString() ?? "";

                string estado = fila.Cells[5].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(estado) && cmbEstado.Items.Contains(estado))
                {
                    cmbEstado.SelectedItem = estado;
                }
                else
                {
                    cmbEstado.SelectedIndex = -1;
                }
            }
        }
    }
}
