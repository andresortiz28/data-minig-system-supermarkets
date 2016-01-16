
using Apriori.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apriori.View
{
    public partial class Form1 : Form
    {
        private Executable ex;
        private bool loaded;

        public Form1()
        {
            InitializeComponent();
            this.loaded = false;
            this.button1.Enabled = false;
        }

        private void aprioriMessage(object sender, string message)
        {
            richTextBox1.AppendText(message);
            this.Refresh();
        }

        private void Ejecutar_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.Refresh();
            //Soporte minimo seleccionado por el usuario
            double minsup = Convert.ToDouble(MinsupValue.Value/100);

            //Confianza seleccionada por el usuario
            double confidence = Convert.ToDouble(ConfidenceValue.Value / 100);

            //Fecha iniciada por defecto en 9999,1,1 AA/MM/DD
            DateTime date = new DateTime(9998,1,1);

            ArrayList meses = new ArrayList();

            //Si la primera opcion (Fecha) es seleccionada, date contiene ahora la fecha dada por el usuario
            if (radioButton1.Checked)
                date = Date.Value;

            //Sino, se agregan a un arrayList los meses seleccionados por el usuario
            else
            {
                if (checkEnero.Checked)
                    meses.Add(1);

                if (checkFebrero.Checked)
                    meses.Add(2);

                if (checkMarzo.Checked)
                    meses.Add(3);

                if (checkAbril.Checked)
                    meses.Add(4);

                if (checkMayo.Checked)
                    meses.Add(5);

                if (checkJunio.Checked)
                    meses.Add(6);
            }

            //Tienda inicializada en -1 , si el usuario escogio ver los datos de todas las tiendas el valor continua en -1, de lo contrario
            //Toma el valor de la tienda seleccionada
            int store = -1;
            if (!Stores.Text.Equals("All") && !Stores.Text.Equals(""))
                store = Convert.ToInt32(Stores.Text);

            //El richtextbox que muestra toda la informacion queda en blanco
            richTextBox1.Clear();

            //Inicializacion
            ex = new Executable();

            //Asignacion delegate
            ex.Message += new ExecutableDelegate(aprioriMessage);

            //Aplica los parametros al ejecutable
            ex.setParameters(minsup, confidence, date, meses, store);

            //Ejecuta algoritmo
            ex.executeAlgorithm();
            MessageBox.Show("The process is complete", "Apriori Algorithm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.loaded = true;
            this.button1.Enabled = true;
            this.Refresh();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (Date.Enabled == true)
                Date.Enabled = false;
            else
                Date.Enabled = true;
                
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (Months.Enabled == true)
                Months.Enabled = false;
            else
                Months.Enabled = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.loaded)
                ex.printAllLk();
        }

        private void Stores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkEnero_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MinsupValue_ValueChanged(object sender, EventArgs e)
        {

        }


    }
}
