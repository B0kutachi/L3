using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
     
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

