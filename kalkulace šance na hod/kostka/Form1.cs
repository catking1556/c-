using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace kostka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            nahoda = new Random();
        }
        Random nahoda;
        int pocet_1 = 0;
        int pocet_2 = 0;
        int pocet_3 = 0;
        int pocet_4 = 0;
        int pocet_5 = 0;
        int pocet_6 = 0;

        private void graf()
        { chart1.Series["pocet_hodnot"].Points.Clear();
                chart1.Series["pocet_hodnot"].Points.AddXY("poc_1", pocet_1);
            chart1.Series["pocet_hodnot"].Points.AddXY("poc_2", pocet_2);
            chart1.Series["pocet_hodnot"].Points.AddXY("poc_3", pocet_3);
            chart1.Series["pocet_hodnot"].Points.AddXY("poc_4", pocet_4);
            chart1.Series["pocet_hodnot"].Points.AddXY("poc_5", pocet_5);
            chart1.Series["pocet_hodnot"].Points.AddXY("poc_6", pocet_6);
            chart1.Update();
        }
               private void button1_Click(object sender, EventArgs e)
        {
            int cas = int.Parse(textBox2.Text);
            int hody = int.Parse(textBox1.Text);
            for (int i = 1; i <= hody; i++) {
                listBox1.Items.Clear();
                int cislo = nahoda.Next(1, 7);
                switch (cislo) {
                    case 1:
                        pocet_1 += 1;
                        pictureBox1.Image = Image.FromFile(@"1.jpg");
                        pictureBox1.Refresh();
                        Thread.Sleep(cas);
                        break;
                    case 2:
                        pocet_2 += 1;
                        pictureBox1.Image = Image.FromFile(@"2.jpg");
                        pictureBox1.Refresh();
                        Thread.Sleep(cas);
                        break;
                    case 3:
                        pocet_3 += 1;
                        pictureBox1.Image = Image.FromFile(@"3.jpg");
                        pictureBox1.Refresh();
                        Thread.Sleep(cas);
                        break;
                    case 4:
                        pocet_4 += 1;
                        pictureBox1.Image = Image.FromFile(@"4.jpg");
                        pictureBox1.Refresh();
                        Thread.Sleep(cas);
                        break;
                    case 5:
                        pocet_5 += 1;
                        pictureBox1.Image = Image.FromFile(@"5.jpg");
                        pictureBox1.Refresh();
                        Thread.Sleep(cas);
                        break;
                    case 6:
                        pocet_6 += 1;
                        pictureBox1.Image = Image.FromFile(@"6.jpg");
                        pictureBox1.Refresh();
                        Thread.Sleep(cas);
                        break;
                }
                listBox1.Items.Add("počet jedniček:" + pocet_1.ToString());
                listBox1.Items.Add("počet dvojek:" + pocet_2.ToString());
                listBox1.Items.Add("počet trojek:" + pocet_3.ToString());
                listBox1.Items.Add("počet čtyřek:" + pocet_4.ToString());
                listBox1.Items.Add("počet pětek:" + pocet_5.ToString());
                listBox1.Items.Add("počet šestek:" + pocet_6.ToString());
                listBox1.Items.Add("celkem hodů:" + i.ToString());
                listBox1.Refresh();
                graf();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pocet_1 = 0;
            pocet_2 = 0;
            pocet_3 = 0;
            pocet_4 = 0;
            pocet_5 = 0;
            pocet_6 = 0;
            listBox1.Items.Clear();
            listBox1.Items.Add("počet jedniček:" + pocet_1.ToString());
            listBox1.Items.Add("počet dvojek:" + pocet_2.ToString());
            listBox1.Items.Add("počet trojek:" + pocet_3.ToString());
            listBox1.Items.Add("počet čtyřek:" + pocet_4.ToString());
            listBox1.Items.Add("počet pětek:" + pocet_5.ToString());
            listBox1.Items.Add("počet šestek:" + pocet_6.ToString());
            graf();
        }
    }
}
