using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_1_visual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        int intentos = 3;
        private void button1_Click(object sender, EventArgs e)
        {

            string us, cl;
            us = ustext.Text;
            cl = cntext.Text;

            do
            {
                intentos--;

                if (us == "admin" && cl == "admin123")
                {
                    MessageBox.Show("Ha ingresado " + us);
                    return; // Se detiene porque ya inició sesión correctamente
                }
                else
                {
                    if (intentos > 0)
                    {
                        MessageBox.Show("Datos incorrectos, intentos restantes: " + intentos);
                        return; // Se detiene para permitir otro intento
                    }
                    else
                    {
                        MessageBox.Show("Se acabaron los intentos, el programa se cerrará.");
                        Close(); // Cierra la aplicación
                    }
                }
            } while (intentos > 0);


        }
        int contador = 0;
        private void btclicks_Click(object sender, EventArgs e)
        {
 
            contador ++;
            btclicks.Text = "dale ya llevas " + contador + " clicks";

        }

        private void btsalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dale ya fue mucho, adios!");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double dato;
            bool numero = double.TryParse(txttenmp.Text, out dato);
            if (!numero)
            {
                MessageBox.Show("Por favor, ingrese un número válido.");
                return; // Detiene la ejecución si no es un número válido
            }
            string opcion = comboBox.SelectedItem?.ToString();

            if (opcion == "Fahrenheit a Celsius")
            {
                double resultado = (dato - 32) * 5 / 9;
                txtresultado.Text = resultado.ToString("F2") + " °C";
            }
            else if (opcion == "Celsius a Fahrenheit")
            {
                double resultado = (dato * 9 / 5) + 32;
                txtresultado.Text =  resultado.ToString("F2") + " °F";
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una opción válida.");
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btverificar_Click(object sender, EventArgs e)
        {
            double peso, altura;  

            bool pesoValido = double.TryParse(txtpeso.Text, out peso);
            bool alturaValida = double.TryParse(txtaltura.Text, out altura);

            double resultado;
            resultado= peso / (altura * altura);
            txtres.Text = resultado.ToString("F2");

            if (resultado < 18.5)
            {
                MessageBox.Show("Usted tiene bajo peso");
            }
            else if (resultado >= 18.5 && resultado < 24.9)
            {
                MessageBox.Show( "Usted tiene un peso normal");
            }
            else if (resultado >= 25 && resultado < 29.9)
            {
                MessageBox.Show("Usted tiene sobrepeso");
            }
            else if(resultado>=30 && resultado >= 34.9)
            {
                MessageBox.Show("Usted tiene obesidad grado 1");
            }
            else if (resultado >= 35 && resultado < 39.9)
            {
                MessageBox.Show("Usted tiene obesidad grado 2");
            }
            else if (resultado >= 40) { 
                MessageBox.Show("Usted tiene obesidad grado 3");
            }
           
        }
    }
}
