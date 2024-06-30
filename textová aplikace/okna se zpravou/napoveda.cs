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

namespace okna_se_zpravou
{
    public partial class napoveda : Form
    {
        public napoveda()
        {
            InitializeComponent();
        }

        private void napoveda_Load(object sender, EventArgs e)
        {
          StreamReader otevri = new StreamReader("n.txt");
            richTextBox1.Text = otevri.ReadToEnd();
            otevri.Close();
        }
    }
}
