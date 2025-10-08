using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static Registro_de_Estudiantes.Form2;

namespace Registro_de_Estudiantes
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // 1. Limpiar configuración previa del Chart
            chartPromedios.Series.Clear();
            chartPromedios.ChartAreas.Clear();

            // 2. Crear área
            ChartArea area = new ChartArea("Area1");
            chartPromedios.ChartAreas.Add(area);

            // 3. Crear serie
            Series serie = new Series("Promedios");
            serie.ChartType = SeriesChartType.Column; // Column = barras verticales
            serie.IsValueShownAsLabel = true;         // Mostrar promedio encima de la barra
            serie.LabelFormat = "0.00";               // Mostrar siempre 2 decimales
            chartPromedios.Series.Add(serie);

            // 4. Aquí va tu código para calcular los promedios 
            var listaPromedios = DatosCompartidos.ListaEstudiantes
                .Select(est => new
                {
                    est.Nombre,
                    Promedio = est.Asignaturas.Count > 0
                        ? Math.Round(est.Asignaturas.Average(a => a.Nota), 2) 
                        : 0
                })
                .OrderByDescending(x => x.Promedio)
                .ToList();

            // 5. Agregar al gráfico los resultados
            foreach (var est in listaPromedios)
            {
                serie.Points.AddXY($"{est.Nombre}", est.Promedio);
            }
        }


    }
}