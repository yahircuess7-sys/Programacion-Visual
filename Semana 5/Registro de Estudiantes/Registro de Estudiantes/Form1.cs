using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro_de_Estudiantes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AbrirUnico(Form frmNuevo)
        {
            // Cierra cualquier hijo abierto
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            // IMPORTANTE: indicar que el nuevo form será hijo de este (Form1)
            frmNuevo.MdiParent = this;
            frmNuevo.WindowState = FormWindowState.Maximized; // opcional
            frmNuevo.Show();
        }

        private void btnForm2_Click(object sender, EventArgs e)
        {
            AbrirUnico(new Form2()); // desde Form1
        }

        private void btnForm3_Click(object sender, EventArgs e)
        {
            AbrirUnico(new Form3()); // desde Form1
        }

        private void btnForm4_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is Form4) { 
                    frm.Activate();
                    return;
                }
            }
            Form4 f4 = new Form4();
            f4.MdiParent = this;
            f4.Show();
        }
    }
}
