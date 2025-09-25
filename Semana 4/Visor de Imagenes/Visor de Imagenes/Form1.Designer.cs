namespace Visor_de_Imagenes
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
            this.msVisor = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escalaDeGrisesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tamañoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centradaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajustarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbImagen = new System.Windows.Forms.Label();
            this.cbImagenAc = new System.Windows.Forms.ComboBox();
            this.gbSize = new System.Windows.Forms.GroupBox();
            this.rbZoom = new System.Windows.Forms.RadioButton();
            this.rbAjust = new System.Windows.Forms.RadioButton();
            this.rbCentral = new System.Windows.Forms.RadioButton();
            this.stVisor = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btFirst = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.btForward = new System.Windows.Forms.Button();
            this.btLast = new System.Windows.Forms.Button();
            this.cbNormal = new System.Windows.Forms.CheckBox();
            this.cbEscalaGris = new System.Windows.Forms.CheckBox();
            this.gbVision = new System.Windows.Forms.GroupBox();
            this.pbVisorImage = new System.Windows.Forms.PictureBox();
            this.msVisor.SuspendLayout();
            this.gbSize.SuspendLayout();
            this.stVisor.SuspendLayout();
            this.gbVision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisorImage)).BeginInit();
            this.SuspendLayout();
            // 
            // msVisor
            // 
            this.msVisor.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msVisor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.visionToolStripMenuItem,
            this.tamañoToolStripMenuItem});
            this.msVisor.Location = new System.Drawing.Point(0, 0);
            this.msVisor.Name = "msVisor";
            this.msVisor.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.msVisor.Size = new System.Drawing.Size(1004, 24);
            this.msVisor.TabIndex = 1;
            this.msVisor.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // visionToolStripMenuItem
            // 
            this.visionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.escalaDeGrisesToolStripMenuItem});
            this.visionToolStripMenuItem.Name = "visionToolStripMenuItem";
            this.visionToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.visionToolStripMenuItem.Text = "Vision";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click_1);
            // 
            // escalaDeGrisesToolStripMenuItem
            // 
            this.escalaDeGrisesToolStripMenuItem.Name = "escalaDeGrisesToolStripMenuItem";
            this.escalaDeGrisesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.escalaDeGrisesToolStripMenuItem.Text = "Escala de Grises";
            this.escalaDeGrisesToolStripMenuItem.Click += new System.EventHandler(this.escalaDeGrisesToolStripMenuItem_Click_1);
            // 
            // tamañoToolStripMenuItem
            // 
            this.tamañoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.centradaToolStripMenuItem,
            this.ajustarToolStripMenuItem,
            this.zoomToolStripMenuItem});
            this.tamañoToolStripMenuItem.Name = "tamañoToolStripMenuItem";
            this.tamañoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.tamañoToolStripMenuItem.Text = "Tamaño";
            // 
            // centradaToolStripMenuItem
            // 
            this.centradaToolStripMenuItem.Name = "centradaToolStripMenuItem";
            this.centradaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.centradaToolStripMenuItem.Text = "Zoom";
            this.centradaToolStripMenuItem.Click += new System.EventHandler(this.centradaToolStripMenuItem_Click_1);
            // 
            // ajustarToolStripMenuItem
            // 
            this.ajustarToolStripMenuItem.Name = "ajustarToolStripMenuItem";
            this.ajustarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ajustarToolStripMenuItem.Text = "Centrada";
            this.ajustarToolStripMenuItem.Click += new System.EventHandler(this.ajustarToolStripMenuItem_Click_1);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zoomToolStripMenuItem.Text = "Ajustada";
            this.zoomToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click_1);
            // 
            // lbImagen
            // 
            this.lbImagen.AutoSize = true;
            this.lbImagen.Location = new System.Drawing.Point(837, 197);
            this.lbImagen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbImagen.Name = "lbImagen";
            this.lbImagen.Size = new System.Drawing.Size(75, 13);
            this.lbImagen.TabIndex = 4;
            this.lbImagen.Text = "Imagen Actual";
            // 
            // cbImagenAc
            // 
            this.cbImagenAc.FormattingEnabled = true;
            this.cbImagenAc.Items.AddRange(new object[] {
            "Imagen1",
            "Imagen2",
            "Imagen3"});
            this.cbImagenAc.Location = new System.Drawing.Point(831, 224);
            this.cbImagenAc.Margin = new System.Windows.Forms.Padding(2);
            this.cbImagenAc.Name = "cbImagenAc";
            this.cbImagenAc.Size = new System.Drawing.Size(92, 21);
            this.cbImagenAc.TabIndex = 5;
            this.cbImagenAc.SelectedIndexChanged += new System.EventHandler(this.cbImagenAc_SelectedIndexChanged_1);
            // 
            // gbSize
            // 
            this.gbSize.Controls.Add(this.rbZoom);
            this.gbSize.Controls.Add(this.rbAjust);
            this.gbSize.Controls.Add(this.rbCentral);
            this.gbSize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSize.Location = new System.Drawing.Point(792, 315);
            this.gbSize.Margin = new System.Windows.Forms.Padding(2);
            this.gbSize.Name = "gbSize";
            this.gbSize.Padding = new System.Windows.Forms.Padding(2);
            this.gbSize.Size = new System.Drawing.Size(192, 151);
            this.gbSize.TabIndex = 6;
            this.gbSize.TabStop = false;
            this.gbSize.Text = "Tamaño";
            // 
            // rbZoom
            // 
            this.rbZoom.AutoSize = true;
            this.rbZoom.Location = new System.Drawing.Point(4, 94);
            this.rbZoom.Margin = new System.Windows.Forms.Padding(2);
            this.rbZoom.Name = "rbZoom";
            this.rbZoom.Size = new System.Drawing.Size(77, 25);
            this.rbZoom.TabIndex = 2;
            this.rbZoom.TabStop = true;
            this.rbZoom.Text = "Ajustar";
            this.rbZoom.UseVisualStyleBackColor = true;
            this.rbZoom.CheckedChanged += new System.EventHandler(this.rbZoom_CheckedChanged_1);
            // 
            // rbAjust
            // 
            this.rbAjust.AutoSize = true;
            this.rbAjust.Location = new System.Drawing.Point(4, 65);
            this.rbAjust.Margin = new System.Windows.Forms.Padding(2);
            this.rbAjust.Name = "rbAjust";
            this.rbAjust.Size = new System.Drawing.Size(80, 25);
            this.rbAjust.TabIndex = 1;
            this.rbAjust.TabStop = true;
            this.rbAjust.Text = "Centrar";
            this.rbAjust.UseVisualStyleBackColor = true;
            this.rbAjust.CheckedChanged += new System.EventHandler(this.rbAjust_CheckedChanged_1);
            // 
            // rbCentral
            // 
            this.rbCentral.AutoSize = true;
            this.rbCentral.Location = new System.Drawing.Point(4, 36);
            this.rbCentral.Margin = new System.Windows.Forms.Padding(2);
            this.rbCentral.Name = "rbCentral";
            this.rbCentral.Size = new System.Drawing.Size(69, 25);
            this.rbCentral.TabIndex = 0;
            this.rbCentral.TabStop = true;
            this.rbCentral.Text = "Zoom";
            this.rbCentral.UseVisualStyleBackColor = true;
            this.rbCentral.CheckedChanged += new System.EventHandler(this.rbCentral_CheckedChanged_1);
            // 
            // stVisor
            // 
            this.stVisor.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stVisor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.stVisor.Location = new System.Drawing.Point(0, 611);
            this.stVisor.Name = "stVisor";
            this.stVisor.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.stVisor.Size = new System.Drawing.Size(1004, 22);
            this.stVisor.TabIndex = 7;
            this.stVisor.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // btFirst
            // 
            this.btFirst.Location = new System.Drawing.Point(142, 545);
            this.btFirst.Margin = new System.Windows.Forms.Padding(2);
            this.btFirst.Name = "btFirst";
            this.btFirst.Size = new System.Drawing.Size(134, 33);
            this.btFirst.TabIndex = 8;
            this.btFirst.Text = "1era Imagen";
            this.btFirst.UseVisualStyleBackColor = true;
            this.btFirst.Click += new System.EventHandler(this.btFirst_Click_1);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(418, 545);
            this.btBack.Margin = new System.Windows.Forms.Padding(2);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(134, 33);
            this.btBack.TabIndex = 9;
            this.btBack.Text = "Atrás";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click_1);
            // 
            // btForward
            // 
            this.btForward.Location = new System.Drawing.Point(280, 545);
            this.btForward.Margin = new System.Windows.Forms.Padding(2);
            this.btForward.Name = "btForward";
            this.btForward.Size = new System.Drawing.Size(134, 33);
            this.btForward.TabIndex = 10;
            this.btForward.Text = "Adelante";
            this.btForward.UseVisualStyleBackColor = true;
            this.btForward.Click += new System.EventHandler(this.btForward_Click_1);
            // 
            // btLast
            // 
            this.btLast.Location = new System.Drawing.Point(556, 545);
            this.btLast.Margin = new System.Windows.Forms.Padding(2);
            this.btLast.Name = "btLast";
            this.btLast.Size = new System.Drawing.Size(134, 33);
            this.btLast.TabIndex = 11;
            this.btLast.Text = "Ultima Imagen";
            this.btLast.UseVisualStyleBackColor = true;
            this.btLast.Click += new System.EventHandler(this.btLast_Click_1);
            // 
            // cbNormal
            // 
            this.cbNormal.AutoSize = true;
            this.cbNormal.Location = new System.Drawing.Point(105, 46);
            this.cbNormal.Margin = new System.Windows.Forms.Padding(2);
            this.cbNormal.Name = "cbNormal";
            this.cbNormal.Size = new System.Drawing.Size(82, 25);
            this.cbNormal.TabIndex = 0;
            this.cbNormal.Text = "Normal";
            this.cbNormal.UseVisualStyleBackColor = true;
            this.cbNormal.CheckedChanged += new System.EventHandler(this.cbNormal_CheckedChanged_1);
            // 
            // cbEscalaGris
            // 
            this.cbEscalaGris.AutoSize = true;
            this.cbEscalaGris.Location = new System.Drawing.Point(427, 46);
            this.cbEscalaGris.Margin = new System.Windows.Forms.Padding(2);
            this.cbEscalaGris.Name = "cbEscalaGris";
            this.cbEscalaGris.Size = new System.Drawing.Size(139, 25);
            this.cbEscalaGris.TabIndex = 1;
            this.cbEscalaGris.Text = "Escala de Grises";
            this.cbEscalaGris.UseVisualStyleBackColor = true;
            this.cbEscalaGris.CheckedChanged += new System.EventHandler(this.cbEscalaGris_CheckedChanged_1);
            // 
            // gbVision
            // 
            this.gbVision.Controls.Add(this.cbEscalaGris);
            this.gbVision.Controls.Add(this.cbNormal);
            this.gbVision.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbVision.Location = new System.Drawing.Point(112, 84);
            this.gbVision.Margin = new System.Windows.Forms.Padding(2);
            this.gbVision.Name = "gbVision";
            this.gbVision.Padding = new System.Windows.Forms.Padding(2);
            this.gbVision.Size = new System.Drawing.Size(617, 81);
            this.gbVision.TabIndex = 0;
            this.gbVision.TabStop = false;
            this.gbVision.Text = "Vision";
            this.gbVision.Enter += new System.EventHandler(this.gbVision_Enter);
            // 
            // pbVisorImage
            // 
            this.pbVisorImage.Location = new System.Drawing.Point(45, 185);
            this.pbVisorImage.Margin = new System.Windows.Forms.Padding(2);
            this.pbVisorImage.Name = "pbVisorImage";
            this.pbVisorImage.Size = new System.Drawing.Size(727, 346);
            this.pbVisorImage.TabIndex = 3;
            this.pbVisorImage.TabStop = false;
            this.pbVisorImage.Click += new System.EventHandler(this.pbVisorImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(1004, 633);
            this.Controls.Add(this.btLast);
            this.Controls.Add(this.btForward);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btFirst);
            this.Controls.Add(this.stVisor);
            this.Controls.Add(this.gbSize);
            this.Controls.Add(this.cbImagenAc);
            this.Controls.Add(this.lbImagen);
            this.Controls.Add(this.pbVisorImage);
            this.Controls.Add(this.gbVision);
            this.Controls.Add(this.msVisor);
            this.MainMenuStrip = this.msVisor;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.msVisor.ResumeLayout(false);
            this.msVisor.PerformLayout();
            this.gbSize.ResumeLayout(false);
            this.gbSize.PerformLayout();
            this.stVisor.ResumeLayout(false);
            this.stVisor.PerformLayout();
            this.gbVision.ResumeLayout(false);
            this.gbVision.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisorImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip msVisor;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tamañoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbVisorImage;
        private System.Windows.Forms.Label lbImagen;
        private System.Windows.Forms.ComboBox cbImagenAc;
        private System.Windows.Forms.GroupBox gbSize;
        private System.Windows.Forms.RadioButton rbZoom;
        private System.Windows.Forms.RadioButton rbAjust;
        private System.Windows.Forms.RadioButton rbCentral;
        private System.Windows.Forms.StatusStrip stVisor;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btFirst;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btForward;
        private System.Windows.Forms.Button btLast;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escalaDeGrisesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centradaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajustarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbNormal;
        private System.Windows.Forms.CheckBox cbEscalaGris;
        private System.Windows.Forms.GroupBox gbVision;
    }
}

