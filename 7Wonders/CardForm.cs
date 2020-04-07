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
    public partial class CardForm : Form
    {
        Card _Card;
        Playerboard theBoard;
        DecisionForm theForm;

        public CardForm(Card aCard, int mode, Playerboard board)
        {
            InitializeComponent();
            _Card = aCard;
            theBoard = board;
            this.Text = _Card.name;
            this.BackColor = getColor(_Card.color);
            richTextBox1.Text = _Card.description;
            showCost();

            if(mode == 0)
            {
                buildButton.Visible = false;
                wonderButton.Visible = false;
                sellButton.Text = "Pick";
            }
            if(mode == 2)
            {
                buildButton.Visible = false;
                sellButton.Visible = false;
                wonderButton.Visible = false;
            }
        }

        public CardForm(Card aCard, DecisionForm form)
        {
            InitializeComponent();
            theForm = form;
            _Card = aCard;
            this.Text = _Card.name;
            this.BackColor = getColor(_Card.color);
            richTextBox1.Text = _Card.description;
            showCost();

            buildButton.Visible = false;
            wonderButton.Visible = false;
            sellButton.Text = "Choose";
            
        }

        public CardForm(Card aCard)
        {
            InitializeComponent();

            _Card = aCard;
            this.Text = _Card.name;
            this.BackColor = getColor(_Card.color);
            richTextBox1.Text = _Card.description;
            showCost();

            buildButton.Visible = false;
            wonderButton.Visible = false;
            sellButton.Visible = false;
        }

        public CardForm()
        {
            InitializeComponent();
        }



        public Color getColor(string c)
        {
            switch(c)
            {
                case "White": return Color.White;
                case "Black": return Color.Black;
                case "Brown": return Color.Brown;
                case "Grey": return Color.Gray;
                case "Green": return Color.Green;
                case "Yellow": return Color.Yellow;
                case "Red": return Color.Crimson;
                case "Blue": return Color.Blue;
                case "Wondrous": return Color.Orange;
                case "Purple": return Color.Purple;
                default: return Color.Beige;
            }
        }

        private void sellButton_Click(object sender, EventArgs e)
        {
            if (sellButton.Text == "Pick") { theBoard.PickCard(_Card); }
            else if (sellButton.Text == "Choose") { theForm.ChosenCard(_Card); }
            else { theBoard.SellCard(_Card); }
            this.Close();
        }

        private void showCost()
        {
            string cost1 = "";
            string cost2 = "";
            int[] c = _Card.cost;
            if (c[0] > 0) { cost1 = c[0].ToString() + " Coin "; }
            if (c[1] > 0) { cost1 += c[1].ToString() + " Clay "; }
            if (c[2] > 0) { cost1 += c[2].ToString() + " Ore "; }
            if (c[3] > 0) { cost1 += c[3].ToString() + " Stone "; }
            if (c[4] > 0) { cost1 += c[4].ToString() + " Wood"; }
            if (c[5] > 0) { cost2 += c[5].ToString() + " Glass "; }
            if (c[6] > 0) { cost2 += c[6].ToString() + " Papyrus "; }
            if (c[7] > 0) { cost2 += c[7].ToString() + " Silk "; }

            if (cost1 == "") { label1.Text = cost2; label2.Text = ""; }
            else { label1.Text = cost1; label2.Text = cost2; }

           if(_Card.color == "Black" || _Card.color == "Blue" || _Card.color == "Purple")
           {
               label1.ForeColor = Color.White;
               label2.ForeColor = Color.White;
           }
        }

        private void buildButton_Click(object sender, EventArgs e)
        {
            theBoard.BuildCard(_Card);
            this.Close();
        }

        private void wonderButton_Click(object sender, EventArgs e)
        {
            theBoard.BuildWonder(_Card);
            this.Close();
        }
    }
}
