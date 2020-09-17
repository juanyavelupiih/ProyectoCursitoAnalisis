using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Recupereme_señor
{
    public partial class Form1 : Form
    {
        /*Atributos (variables globales)*/
        // Crear una lista para almacenar los encabezados
        List<string> encabezado = new List<string>();
        // Crear una lista para almacenar los años
        List<string> pais = new List<string>();
        // Lista para guardar todos los datos
        List<string[]> data = new List<string[]>();

        // string[] arch = {"0"};

        public void datos()
        {
            /* // Variables locales
			List<string> tmp = new List<string>();
			
			int maximo = int.MinValue;
			int minimo = int.MaxValue;
			long total = 0;
			double promedio = 0.0;
			
			int i = comboBox1.SelectedIndex + 1;
			int j = comboBox2.SelectedIndex;
			
			// Obtener todos los datos de la selección
			foreach(string[] r in data)
			{
				// Añadir los valores a la lista temporal
				tmp.Add(r[i]);
				
				// Obtener la suma de todos los valores
				total += Convert.ToInt32(r[i]);
				
				// Obtener máximo de la lista
				if( Convert.ToInt32(r[i]) > maximo )
					maximo = Convert.ToInt32(r[i]);
				// Obtener el mínimo de la lista
				if( Convert.ToInt32(r[i]) < minimo )
					minimo = Convert.ToInt32(r[i]);
				
			}
			
			// Obtenemos el promedio
			promedio = (double)total / (double)tmp.Count;
			
			if(comboBox2.SelectedIndex != -1)
				textBox2.Text = tmp[j];
			
			textBox2.Text = promedio.ToString();
			
			*/

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rdn = new Random();

            // Limpiar los puntos de los datos
            chart1.Series["Datos1"].Points.Clear();


            // Cambiar el texto de la leyenda
            chart1.Series["Datos1"].LegendText = "Puntos Aleatorios 1";


            chart1.Series["Datos1"].IsValueShownAsLabel = true;


            // Añadir elementos a la gráfica
            for (int i = 0; i < 10; i++)
            {
                chart1.Series["Datos1"].Points.AddXY(rdn.Next(0, 10), rdn.Next(0, 10));

            }

            chart1.Series["Datos1"].ChartType = SeriesChartType.BoxPlot;
            chart1.Series["Datos1"].Color = Color.Red;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Añadir un título a la gráfica
            chart1.Titles.Add("Grafica Recuperame");
            // Modificar el fondo del título
            chart1.Titles[0].BackColor = Color.Coral;

            // Dar formato a la leyenda
            chart1.Legends.Add("Leyenda1");
            chart1.Legends[0].BackColor = Color.BlueViolet;
            chart1.Legends[0].BorderColor = Color.GreenYellow;
            chart1.Legends[0].BorderWidth = 4;

            // Textos en los ejes
            chart1.ChartAreas[0].Axes[0].Title = "Eje x";
            chart1.ChartAreas[0].Axes[1].Title = "Eje y";

            // Variables locales
            int j = 0;      // Contador de líneas

            // Lectura del archivo CSV
            using (var lector = new StreamReader("owid-covid-data.csv"))
            {
                // Hasta el fin del archivo
                while (!lector.EndOfStream)
                {
                    // Leer línea por línea ('\n')
                    var linia = lector.ReadLine();

                    // Encabezado
                    if (j == 0)
                    {
                        // Recorrer elemento a elemento y añadir a una lista
                        foreach (string en in linia.Split(','))
                            encabezado.Add(en);
                    }
                    else
                    {
                        // Añadir los elementos de la tabla
                        data.Add(linia.Split(','));
                        // Se añaden los paises
                        pais.Add(linia.Split(',')[2]);
                    }
                    // contador de líneas leídas
                    j++;
                }

                /* Leídos los datos, comenzar a llenar los espacios de la GUI */
                encabezado.RemoveRange(0, 1); encabezado.RemoveRange(0, 3);
                foreach (string en in encabezado)
                    comboBox2.Items.Add(en);
                comboBox2.Text = comboBox2.Items[0].ToString();

                // Colocar los paises
                foreach (string p in pais)
                    comboBox1.Items.Add(p);
                comboBox1.Text = comboBox1.Items[2].ToString();


            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //datos();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //datos();
        }
    }
}
