using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7Wonders
{
    public partial class Form1 : Form
    {
        int[] startVal;
        int leaders;
        int cities;

        public Form1(int[] startValues)
        {
            InitializeComponent();
            startVal = startValues;
            leaders = 0;
            cities = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            startVal[0] = 3;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            startVal[0] = 4;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            startVal[0] = 5;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            startVal[0] = 6;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            startVal[0] = 7;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { leaders = 1; }
            else { leaders = 0; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { cities = 1; checkBox1.Checked = true; checkBox1.Enabled = false; }
            else { cities = 0; checkBox1.Enabled = true; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cities == 1) { startVal[1] = 2; }
            else if (leaders == 1) { startVal[1] = 1; }
            this.Close();
        }
    }
}
