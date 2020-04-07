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
    public partial class ResultForm : Form
    {
        GameMaster theMaster;
        MasterForm _MasterForm;
        TextBox[] spaces;
        Playerboard theCopy;
        int np;
        public ResultForm(MasterForm masterF, string mode)
        {
            InitializeComponent();
            theMaster = masterF.master;
            _MasterForm = masterF;
            np = theMaster.nPlayers;

            spaces = new TextBox[98];
            spaces[0] = textBox1;
            spaces[1] = textBox2;
            spaces[2] = textBox3;
            spaces[3] = textBox4;
            spaces[4] = textBox5;
            spaces[5] = textBox6;
            spaces[6] = textBox7;
            spaces[7] = textBox8;
            spaces[8] = textBox9;
            spaces[9] = textBox10;
            spaces[10] = textBox11;
            spaces[11] = textBox12;
            spaces[12] = textBox13;
            spaces[13] = textBox14;
            spaces[14] = textBox15;
            spaces[15] = textBox16;
            spaces[16] = textBox17;
            spaces[17] = textBox18;
            spaces[18] = textBox19;
            spaces[19] = textBox20;
            spaces[20] = textBox21;
            spaces[21] = textBox22;
            spaces[22] = textBox23;
            spaces[23] = textBox24;
            spaces[24] = textBox25;
            spaces[25] = textBox26;
            spaces[26] = textBox27;
            spaces[27] = textBox28;
            spaces[28] = textBox29;
            spaces[29] = textBox30;
            spaces[30] = textBox31;
            spaces[31] = textBox32;
            spaces[32] = textBox33;
            spaces[33] = textBox34;
            spaces[34] = textBox35;
            spaces[35] = textBox36;
            spaces[36] = textBox37;
            spaces[37] = textBox38;
            spaces[38] = textBox39;
            spaces[39] = textBox40;
            spaces[40] = textBox41;
            spaces[41] = textBox42;
            spaces[42] = textBox43;
            spaces[43] = textBox44;
            spaces[44] = textBox45;
            spaces[45] = textBox46;
            spaces[46] = textBox47;
            spaces[47] = textBox48;
            spaces[48] = textBox49;
            spaces[49] = textBox50;
            spaces[50] = textBox51;
            spaces[51] = textBox52;
            spaces[52] = textBox53;
            spaces[53] = textBox54;
            spaces[54] = textBox55;
            spaces[55] = textBox56;
            spaces[56] = textBox57;
            spaces[57] = textBox58;
            spaces[58] = textBox59;
            spaces[59] = textBox60;
            spaces[60] = textBox61;
            spaces[61] = textBox62;
            spaces[62] = textBox63;
            spaces[63] = textBox64;
            spaces[64] = textBox65;
            spaces[65] = textBox66;
            spaces[66] = textBox67;
            spaces[67] = textBox68;
            spaces[68] = textBox69;
            spaces[69] = textBox70;
            spaces[70] = textBox71;
            spaces[71] = textBox72;
            spaces[72] = textBox73;
            spaces[73] = textBox74;
            spaces[74] = textBox75;
            spaces[75] = textBox76;
            spaces[76] = textBox77;
            spaces[77] = textBox78;
            spaces[78] = textBox79;
            spaces[79] = textBox80;
            spaces[80] = textBox81;
            spaces[81] = textBox82;
            spaces[82] = textBox83;
            spaces[83] = textBox84;
            spaces[84] = textBox85;
            spaces[85] = textBox86;
            spaces[86] = textBox87;
            spaces[87] = textBox88;
            spaces[88] = textBox89;
            spaces[89] = textBox90;
            spaces[90] = textBox91;
            spaces[91] = textBox92;
            spaces[92] = textBox93;
            spaces[93] = textBox94;
            spaces[94] = textBox95;
            spaces[95] = textBox96;
            spaces[96] = textBox97;
            spaces[97] = textBox98;



            if (mode == "Result") { Result(); }
            else { Neighbourhood(); }
        }

        private void Neighbourhood()
        {
            pictureBox1.BackColor = Color.White;
            pictureBox2.BackColor = Color.Black;
            pictureBox3.BackColor = Color.Brown;
            pictureBox4.BackColor = Color.Gray;
            pictureBox5.BackColor = Color.Green;
            pictureBox6.BackColor = Color.Yellow;
            pictureBox7.BackColor = Color.Crimson;
            pictureBox8.BackColor = Color.Blue;
            pictureBox9.BackColor = Color.Orange;
            pictureBox10.BackColor = Color.Purple;

            for (int i = 0; i < np; i++)
            {
                spaces[i * 11].Text = Initials(theMaster.Players[i].wonder);
                for (int j = 0; j < 10; j++)
                {
                    spaces[i * 11 + j + 1].Text = theMaster.Players[i].nColors[j].ToString();
                }
                string temp = ""; if (theMaster.Players[i].diplomacy > 0) { temp = "*"; }
                spaces[77 + i * 3].Text = theMaster.Players[i].militaryStrength.ToString() + temp;
                spaces[78 + i * 3].Text = theMaster.Players[i].wins.ToString() + "/" + theMaster.Players[i].losses.ToString();
                spaces[79 + i * 3].Text = theMaster.Players[i].resources[0].ToString();

                
            }

            this.Text = "Neighbourhood";
        }

        public void neighbourUpdate()
        {
            for (int i = 0; i < np; i++)
            {
                spaces[i * 11].Text = Initials(theMaster.Players[i].wonder);
                for (int j = 0; j < 10; j++)
                {
                    spaces[i * 11 + j + 1].Text = theMaster.Players[i].nColors[j].ToString();
                }
                spaces[77 + i * 3].Text = theMaster.Players[i].militaryStrength.ToString();
                spaces[78 + i * 3].Text = theMaster.Players[i].wins.ToString() + "/" + theMaster.Players[i].losses.ToString();
                spaces[79 + i * 3].Text = theMaster.Players[i].resources[0].ToString();
            }
        }

        private void Result()
        {

            for(int i = 0; i < np; i++)
            {
                spaces[i * 11].Text = Initials(theMaster.Players[i].wonder);
                for(int j = 0; j < 9; j++)
                {
                    spaces[i * 11 + j + 1].Text = theMaster.Players[i].totalScore[j].ToString();
                }
                spaces[(i + 1) * 11 - 1].Text = theMaster.Players[i].totalScore.Sum().ToString();
            }

            for (int i = 77; i < 98; i++) { spaces[i].Visible = false; }
            label1.Visible = false; label2.Visible = false; label3.Visible = false;

            pictureBox1.BackColor = Color.Crimson;
            pictureBox2.BackColor = Color.Gold;
            pictureBox3.BackColor = Color.Orange;
            pictureBox4.BackColor = Color.Blue;
            pictureBox5.BackColor = Color.Yellow;
            pictureBox6.BackColor = Color.Green;
            pictureBox7.BackColor = Color.Purple;
            pictureBox8.BackColor = Color.White;
            pictureBox9.BackColor = Color.Black;

            this.Text = "Result";
        }

        private string Initials(string wonder)
        {
            switch(wonder)
            {
                case "Babylon": return "BAB";
                case "Giza": return "GIZ";
                case "Halikarnassos": return "HAL";
                case "Rhodos": return "RHO";
                case "Ephesos": return "EPH";
                case "Olympus": return "OLY";
                case "Alexandria": return "ALX";
                case "Rome": return "ROM";
                case "Petra": return "PET";
                case "Byzantium": return "BYZ";
                default: return "MÄDZ";
            }
        }

        private void itemClick1(object sender, EventArgs e)
        {
            if(theCopy == null) { theCopy = new Playerboard(_MasterForm, theMaster.Players[0], true); }
            else if (theCopy.IsDisposed) { theCopy = new Playerboard(_MasterForm, theMaster.Players[0], true); }
            else if (theCopy.thisPlayer == theMaster.Players[0])
            {
                theCopy.Close();
                theCopy = new Playerboard(_MasterForm, theMaster.Players[0], true);
            }
            theCopy.Show();
        }

        private void itemClick2(object sender, EventArgs e)
        {
            if (theCopy == null) { theCopy = new Playerboard(_MasterForm, theMaster.Players[1], true); }
            else if (theCopy.IsDisposed) { theCopy = new Playerboard(_MasterForm, theMaster.Players[1], true); }
            else if (theCopy.thisPlayer == theMaster.Players[1])
            {
                theCopy.Close();
                theCopy = new Playerboard(_MasterForm, theMaster.Players[1], true);
            }
            theCopy.Show();
        }

        private void itemClick3(object sender, EventArgs e)
        {
            if (theCopy == null) { theCopy = new Playerboard(_MasterForm, theMaster.Players[2], true); }
            else if (theCopy.IsDisposed) { theCopy = new Playerboard(_MasterForm, theMaster.Players[2], true); }
            else if (theCopy.thisPlayer == theMaster.Players[2]) 
            {
                theCopy.Close();
                theCopy = new Playerboard(_MasterForm, theMaster.Players[2], true);
            }
            theCopy.Show();
        }

        private void itemClick4(object sender, EventArgs e)
        {
            if (theCopy == null) { theCopy = new Playerboard(_MasterForm, theMaster.Players[3], true); }
            else if (theCopy.IsDisposed) { theCopy = new Playerboard(_MasterForm, theMaster.Players[3], true); }
            else if (theCopy.thisPlayer == theMaster.Players[3])
            {
                theCopy.Close();
                theCopy = new Playerboard(_MasterForm, theMaster.Players[3], true);
            }
            theCopy.Show();
        }

        private void itemClick5(object sender, EventArgs e)
        {
            if (theCopy == null) { theCopy = new Playerboard(_MasterForm, theMaster.Players[4], true); }
            else if (theCopy.IsDisposed) { theCopy = new Playerboard(_MasterForm, theMaster.Players[4], true); }
            else if (theCopy.thisPlayer == theMaster.Players[4])
            {
                theCopy.Close();
                theCopy = new Playerboard(_MasterForm, theMaster.Players[4], true);
            }
            theCopy.Show();
        }

        private void itemClick6(object sender, EventArgs e)
        {
            if (theCopy == null) { theCopy = new Playerboard(_MasterForm, theMaster.Players[5], true); }
            else if (theCopy.IsDisposed) { theCopy = new Playerboard(_MasterForm, theMaster.Players[5], true); }
            else if (theCopy.thisPlayer == theMaster.Players[5])
            {
                theCopy.Close();
                theCopy = new Playerboard(_MasterForm, theMaster.Players[5], true);
            }
            theCopy.Show();
        }

        private void itemClick7(object sender, EventArgs e)
        {
            if (theCopy == null) { theCopy = new Playerboard(_MasterForm, theMaster.Players[6], true); }
            else if (theCopy.IsDisposed) { theCopy = new Playerboard(_MasterForm, theMaster.Players[6], true); }
            else if (theCopy.thisPlayer != theMaster.Players[6])
            {
                theCopy.Close();
                theCopy = new Playerboard(_MasterForm, theMaster.Players[6], true);
            }
            theCopy.Show();
        }

        private void ResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (theCopy != null)
            {
                if (!theCopy.IsDisposed)
                {
                    theCopy.Close();
                }
            }
        }
        
    }
}
