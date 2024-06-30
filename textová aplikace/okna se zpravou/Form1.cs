using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace okna_se_zpravou
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void uloz()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter ulozeni = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF32);
                ulozeni.WriteLine(richTextBox1.Text);
                ulozeni.Close(); 

            } }

        private void novýCtrNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chceš uložit změny ?", "upozornění", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                uloz();
                richTextBox1.Text = null;
            }
            else
                richTextBox1.Text = null;
        }
        void kopirovat()
        {
            richTextBox1.Copy();
        }
        void vlozit()
        {
            richTextBox1.Paste();
        }
        void vyberall() 
        {
            richTextBox1.SelectAll();
        }
        void barva()
        {
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                    richTextBox1.ForeColor = colorDialog1.Color;
            }
        }
        void fontTyp ()
        {if (fontDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = fontDialog1.Font;
        }
        void otevri()
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                StreamReader otevri = new StreamReader(openFileDialog1.FileName);
                richTextBox1.Text = otevri.ReadToEnd();
                otevri.Close();
            }
        }
        void vlevo()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }
        void vpravo()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
        void stred()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }
        private void otevřítToolStripMenuItem_Click(object sender, EventArgs e)
        {
            otevri();
        }
        void pribliz() { float zoom = richTextBox1.ZoomFactor;
            zoom = zoom + 1;
            richTextBox1.ZoomFactor = zoom;
        }
        void oddal() {
           
                float zoom = richTextBox1.ZoomFactor;
            if (zoom > 1) { 
                zoom = zoom - 1;
                richTextBox1.ZoomFactor = zoom;
            }
        }
        void vyjmi() { richTextBox1.Cut(); }
        private void uložitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chceš uložit změny ?", "upozornění", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                uloz();
                richTextBox1.Text = null;
            }
            else
                richTextBox1.Text = null;
        }

        private void ukončitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chceš uložit změny ?", "upozornění", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                uloz();
                this.Close();
            }
            else
                this.Close();
        }
      
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Chceš skončit ?", "upozornění", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        private void vyjmoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vyjmi();
        }

        private void kopírovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kopirovat();
        }

        private void vložitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vlozit();
        }

        private void vybratVšeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vyberall();
        }

        private void typToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontTyp();
        }

        private void barvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            barva();
        }

        private void vlevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vlevo();
        }

        private void vpravoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vpravo();
        }

        private void naStředToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stred();
        }

        private void přiblížitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pribliz();
        }

        private void oddálitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oddal();
        }

        private void novýToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chceš uložit změny ?", "upozornění", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                uloz();
                richTextBox1.Text = null;
            }
            else
                richTextBox1.Text = null;
        }

        private void otevřítToolStripButton_Click(object sender, EventArgs e)
        {
            otevri();
        }

        private void uložitToolStripButton_Click(object sender, EventArgs e)
        {
            uloz();
        }

        private void vyjmoutToolStripButton_Click(object sender, EventArgs e)
        {
            vyjmi();
        }

        private void kopírovatToolStripButton_Click(object sender, EventArgs e)
        {
            kopirovat();
        }

        private void vložitToolStripButton_Click(object sender, EventArgs e)
        {
            vlozit();
        }
        private void linkf() {
          
        }

        private void nápovědaToolStripButton_Click(object sender, EventArgs e)
        {
            new napoveda().Show();
        }

        private void nápovědaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new napoveda().Show();
        }
    }
}