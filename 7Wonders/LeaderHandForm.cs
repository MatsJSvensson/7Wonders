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
    public partial class LeaderHandForm : Form
    {
        Label[] spaces;
        CardForm _CardForm;
        Card[] theHand;
        public LeaderHandForm(Card[] hand)
        {
            InitializeComponent();
            theHand = hand;

            spaces = new Label[7];
            spaces[0] = label1;
            spaces[1] = label2;
            spaces[2] = label3;
            spaces[3] = label4;
            spaces[4] = label5;
            spaces[5] = label6;
            spaces[6] = label7;

            int filled = hand.Count(x => x != null);
            for(int i = 0; i < 7; i++)
            {
                if(i < filled)
                {
                    spaces[i].BackColor = Color.White;
                    spaces[i].Text = hand[i].name;
                }
                else { spaces[i].Text = ""; }
            }
        }

        private void labelClick(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            int i;
            for(i = 0; i < 7; i++)
            {
                if (spaces[i] == theLabel) { break; }
            }
            if (_CardForm == null) { _CardForm = new CardForm(theHand[i]); }
            else if (_CardForm.IsDisposed) { _CardForm = new CardForm(theHand[i]); }
            else { _CardForm.Close(); _CardForm = new CardForm(theHand[i]); }
            _CardForm.Show();
        }
    }
}
