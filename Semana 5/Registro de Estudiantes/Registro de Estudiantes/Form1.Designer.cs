namespace Registro_de_Estudiantes
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnForm2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnForm3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnForm4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnForm2,
            this.btnForm3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnForm2
            // 
            this.btnForm2.Name = "btnForm2";
            this.btnForm2.Size = new System.Drawing.Size(128, 20);
            this.btnForm2.Text = "Registrar Estudiantes";
            this.btnForm2.Click += new System.EventHandler(this.btnForm2_Click);
            // 
            // btnForm3
            // 
            this.btnForm3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnForm4});
            this.btnForm3.Name = "btnForm3";
            this.btnForm3.Size = new System.Drawing.Size(114, 20);
            this.btnForm3.Text = "Visualizar Registro";
            this.btnForm3.Click += new System.EventHandler(this.btnForm3_Click);
            // 
            // btnForm4
            // 
            this.btnForm4.Name = "btnForm4";
            this.btnForm4.Size = new System.Drawing.Size(180, 22);
            this.btnForm4.Text = "Promedio";
            this.btnForm4.Click += new System.EventHandler(this.btnForm4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(848, 497);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnForm2;
        private System.Windows.Forms.ToolStripMenuItem btnForm3;
        private System.Windows.Forms.ToolStripMenuItem btnForm4;
    }
}

