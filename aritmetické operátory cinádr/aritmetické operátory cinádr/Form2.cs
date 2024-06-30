using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aritmetické_operátory_cinádr
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(textBox1.Text);
                double b = double.Parse(textBox2.Text);
                double c = double.Parse(textBox3.Text);
                textBox4.Text = "objem: " + (a * b * c).ToString();
            }
            catch  { MessageBox.Show("jejda chyba"); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(textBox1.Text);
                double b = double.Parse(textBox2.Text);
                double c = double.Parse(textBox3.Text);
                textBox4.Text = "povrch: " + (2*(a * b * c)).ToString();
            }
            catch { MessageBox.Show("jejda chyba"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double v = double.Parse(textBox7.Text);
               
                double r = double.Parse(textBox5.Text);
                textBox8.Text = "objem: " + ((1.0/3.0)* Math.PI * r *r*v).ToString();
            }
            catch { MessageBox.Show("jejda chyba"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
              
                double s = double.Parse(textBox6.Text);
                double r = double.Parse(textBox5.Text);
                              textBox8.Text = "povrch: " + (Math.PI * r * (r + s)).ToString();
            }
            catch { MessageBox.Show("jejda chyba"); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                double r = double.Parse(textBox12.Text);
              
                textBox9.Text = "objem: " + (4.0/3.0*Math.PI * r *r*r).ToString();
            }
            catch { MessageBox.Show("jejda chyba"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                double r = double.Parse(textBox12.Text);

                textBox9.Text = "povrch: " + (4.0 * Math.PI * r * r ).ToString();
            }
            catch { MessageBox.Show("jejda chyba"); }
        }
    }

}
