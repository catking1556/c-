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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double cislo_1 = double.Parse(numericUpDown1.Value.ToString());
            double cislo_2 = (double)numericUpDown2.Value;
            label2.Text = (cislo_1 + cislo_2).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double cislo_1 = double.Parse(numericUpDown1.Value.ToString());
            double cislo_2 = (double)numericUpDown2.Value;
            label2.Text = (cislo_1 - cislo_2).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double cislo_1 = double.Parse(numericUpDown1.Value.ToString());
            double cislo_2 = (double)numericUpDown2.Value;
            label2.Text = (cislo_1 / cislo_2).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double cislo_1 = double.Parse(numericUpDown1.Value.ToString());
            double cislo_2 = (double)numericUpDown2.Value;
            label2.Text = (cislo_1 * cislo_2).ToString();
        }
    }
}
