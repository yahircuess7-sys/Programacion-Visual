using System;

namespace Threads1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.backgroundWorkerQuickSort = new System.ComponentModel.BackgroundWorker();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.progressBurbuja = new System.Windows.Forms.ProgressBar();
            this.progressQuickSort = new System.Windows.Forms.ProgressBar();
            this.lblBurbuja = new System.Windows.Forms.Label();
            this.lblQuickSort = new System.Windows.Forms.Label();
            this.chartResultados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblMerge = new System.Windows.Forms.Label();
            this.lblSelection = new System.Windows.Forms.Label();
            this.progressMerge = new System.Windows.Forms.ProgressBar();
            this.progressSelection = new System.Windows.Forms.ProgressBar();
            this.btnDetener = new System.Windows.Forms.Button();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnGuardarResultados = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorkerQuickSort
            // 
            this.backgroundWorkerQuickSort.WorkerReportsProgress = true;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(270, 186);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(91, 29);
            this.btnGenerar.TabIndex = 0;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12.2F, System.Drawing.FontStyle.Bold);
            this.btnIniciar.Location = new System.Drawing.Point(268, 219);
            this.btnIniciar.Margin = new System.Windows.Forms.Padding(2);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(92, 30);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBurbuja
            // 
            this.progressBurbuja.Location = new System.Drawing.Point(33, 93);
            this.progressBurbuja.Margin = new System.Windows.Forms.Padding(2);
            this.progressBurbuja.Name = "progressBurbuja";
            this.progressBurbuja.Size = new System.Drawing.Size(177, 27);
            this.progressBurbuja.TabIndex = 2;
            // 
            // progressQuickSort
            // 
            this.progressQuickSort.Location = new System.Drawing.Point(33, 290);
            this.progressQuickSort.Margin = new System.Windows.Forms.Padding(2);
            this.progressQuickSort.Name = "progressQuickSort";
            this.progressQuickSort.Size = new System.Drawing.Size(170, 27);
            this.progressQuickSort.TabIndex = 3;
            // 
            // lblBurbuja
            // 
            this.lblBurbuja.AutoSize = true;
            this.lblBurbuja.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBurbuja.Location = new System.Drawing.Point(48, 41);
            this.lblBurbuja.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBurbuja.Name = "lblBurbuja";
            this.lblBurbuja.Size = new System.Drawing.Size(98, 21);
            this.lblBurbuja.TabIndex = 4;
            this.lblBurbuja.Text = "Burbuja 0%";
            // 
            // lblQuickSort
            // 
            this.lblQuickSort.AutoSize = true;
            this.lblQuickSort.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuickSort.Location = new System.Drawing.Point(48, 239);
            this.lblQuickSort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuickSort.Name = "lblQuickSort";
            this.lblQuickSort.Size = new System.Drawing.Size(114, 21);
            this.lblQuickSort.TabIndex = 5;
            this.lblQuickSort.Text = "QuickSort 0%";
            this.lblQuickSort.Click += new System.EventHandler(this.lblQuickSort_Click);
            // 
            // chartResultados
            // 
            chartArea1.Name = "ChartArea1";
            this.chartResultados.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartResultados.Legends.Add(legend1);
            this.chartResultados.Location = new System.Drawing.Point(494, 48);
            this.chartResultados.Margin = new System.Windows.Forms.Padding(2);
            this.chartResultados.Name = "chartResultados";
            this.chartResultados.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartResultados.Series.Add(series1);
            this.chartResultados.Size = new System.Drawing.Size(341, 323);
            this.chartResultados.TabIndex = 6;
            this.chartResultados.Text = "chart1";
            // 
            // lblMerge
            // 
            this.lblMerge.AutoSize = true;
            this.lblMerge.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMerge.Location = new System.Drawing.Point(48, 145);
            this.lblMerge.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMerge.Name = "lblMerge";
            this.lblMerge.Size = new System.Drawing.Size(85, 21);
            this.lblMerge.TabIndex = 7;
            this.lblMerge.Text = "Merge 0%";
            // 
            // lblSelection
            // 
            this.lblSelection.AutoSize = true;
            this.lblSelection.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelection.Location = new System.Drawing.Point(52, 339);
            this.lblSelection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(110, 21);
            this.lblSelection.TabIndex = 8;
            this.lblSelection.Text = "Selection 0%";
            // 
            // progressMerge
            // 
            this.progressMerge.Location = new System.Drawing.Point(33, 186);
            this.progressMerge.Margin = new System.Windows.Forms.Padding(2);
            this.progressMerge.Name = "progressMerge";
            this.progressMerge.Size = new System.Drawing.Size(177, 27);
            this.progressMerge.TabIndex = 9;
            // 
            // progressSelection
            // 
            this.progressSelection.Location = new System.Drawing.Point(33, 383);
            this.progressSelection.Margin = new System.Windows.Forms.Padding(2);
            this.progressSelection.Name = "progressSelection";
            this.progressSelection.Size = new System.Drawing.Size(170, 27);
            this.progressSelection.TabIndex = 10;
            // 
            // btnDetener
            // 
            this.btnDetener.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetener.Location = new System.Drawing.Point(269, 314);
            this.btnDetener.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(91, 29);
            this.btnDetener.TabIndex = 11;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = true;
            // 
            // numericCantidad
            // 
            this.numericCantidad.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericCantidad.Location = new System.Drawing.Point(270, 145);
            this.numericCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.numericCantidad.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericCantidad.Name = "numericCantidad";
            this.numericCantidad.Size = new System.Drawing.Size(90, 33);
            this.numericCantidad.TabIndex = 12;
            // 
            // btnGuardarResultados
            // 
            this.btnGuardarResultados.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarResultados.Location = new System.Drawing.Point(268, 281);
            this.btnGuardarResultados.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarResultados.Name = "btnGuardarResultados";
            this.btnGuardarResultados.Size = new System.Drawing.Size(91, 29);
            this.btnGuardarResultados.TabIndex = 13;
            this.btnGuardarResultados.Text = "Guardar";
            this.btnGuardarResultados.UseVisualStyleBackColor = true;
            this.btnGuardarResultados.Click += new System.EventHandler(this.btnGuardarResultados_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(248, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 223);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(860, 481);
            this.Controls.Add(this.btnGuardarResultados);
            this.Controls.Add(this.numericCantidad);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.progressSelection);
            this.Controls.Add(this.progressMerge);
            this.Controls.Add(this.lblSelection);
            this.Controls.Add(this.lblMerge);
            this.Controls.Add(this.chartResultados);
            this.Controls.Add(this.lblQuickSort);
            this.Controls.Add(this.lblBurbuja);
            this.Controls.Add(this.progressQuickSort);
            this.Controls.Add(this.progressBurbuja);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "S";
            ((System.ComponentModel.ISupportInitialize)(this.chartResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lblQuickSort_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorkerQuickSort;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.ProgressBar progressBurbuja;
        private System.Windows.Forms.ProgressBar progressQuickSort;
        private System.Windows.Forms.Label lblBurbuja;
        private System.Windows.Forms.Label lblQuickSort;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResultados;
        private System.Windows.Forms.Label lblMerge;
        private System.Windows.Forms.Label lblSelection;
        private System.Windows.Forms.ProgressBar progressMerge;
        private System.Windows.Forms.ProgressBar progressSelection;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.NumericUpDown numericCantidad;
        private System.Windows.Forms.Button btnGuardarResultados;
        private System.Windows.Forms.Button button1;
    }
}

