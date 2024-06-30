using System;
using System.Windows.Forms;
using System.IO;

namespace GeneratorHesla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random ran = new Random();
        char malap()
        {
            string malp = "abcdefghijklmnopqrstuvwxyz";
            return malp[ran.Next(0, malp.Length)];
        }

        char velkap()
        {
            string velp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return velp[ran.Next(0, velp.Length)];
        }

        char cisla()
        {
            string cis = "0123456789";
            return cis[ran.Next(0, cis.Length)];
        }

        char specZnk()
        {
            string spec = "!?#%()*+,-_/<=>{}[]";
            return spec[ran.Next(0, spec.Length)];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int malac = int.Parse(textBox1.Text);
                int velkac = int.Parse(textBox2.Text);
                int cislac = int.Parse(textBox3.Text);
                int specialc = int.Parse(textBox4.Text);
                int mala_aktualne = 0, velka_aktualne = 0, cisla_aktualne = 0, speczAktualne = 0;
                string heslo = "";
                while (heslo.Length<malac+velkac+cislac+specialc)
                {
                    int cislo = ran.Next(1, 5);
                    if (cislo == 1)
                    {
                        if(mala_aktualne < malac)
                        {
                            heslo += malap();
                            mala_aktualne++;
                        }
                    }
                    if (cislo == 2)
                    {
                        if(velka_aktualne < velkac)
                        {
                            heslo += velkap();
                            velka_aktualne++;
                        }
                    }
                    if (cislo == 3)
                    {
                        if(cisla_aktualne < cislac)
                        {
                            heslo += cisla();
                            cisla_aktualne++;
                        }
                    }
                    if (cislo == 4)
                    {
                        if(speczAktualne < specialc)
                        {
                            heslo += specZnk();
                            speczAktualne++;
                        }
                    }
                }
                textBox5.Text = heslo;
            }
            catch { MessageBox.Show("Máš tam někde chybu!"); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
