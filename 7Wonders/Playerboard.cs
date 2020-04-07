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
    public partial class Playerboard : Form
    {
        public Label[] spaces;
        public Label[] handSpaces;
        public Player thisPlayer;
        
        CardForm _CardForm;
        MasterForm _MasterForm;
        LeaderHandForm _LeaderHandForm;
        public int phase;
        bool copy;

        public Playerboard(MasterForm MasterF, Player p)
        {
            thisPlayer = p;
            _MasterForm = MasterF;
            Constructor();
            copy = false;
        }

        public Playerboard(MasterForm MasterF, Player p, bool dummy)
        {
            thisPlayer = p;
            _MasterForm = MasterF;
            Constructor();
            copy = dummy;
            if (copy) 
            {
                neighbourButton.Visible = false;
                leaderButton.Visible = false;
            }
        }

        private void Constructor()
        {
            InitializeComponent();
            
            phase = 0;
            
            spaces = new Label[84];

            
                spaces[0] = label1;
                spaces[1] = label2;
                spaces[2] = label3;
                spaces[3] = label4;
                spaces[4] = label5;
                spaces[5] = label6;
                spaces[6] = label7;
                spaces[7] = label8;
                spaces[8] = label9;
                spaces[9] = label10;
                spaces[10] = label11;
                spaces[11] = label12;
                spaces[12] = label13;
                spaces[13] = label14;
                spaces[14] = label15;
                spaces[15] = label16;
                spaces[16] = label17;
                spaces[17] = label18;
                spaces[18] = label19;
                spaces[19] = label20;
                spaces[20] = label21;
                spaces[21] = label22;
                spaces[22] = label23;
                spaces[23] = label24;
                spaces[24] = label25;
                spaces[25] = label26;
                spaces[26] = label27;
                spaces[27] = label28;
                spaces[28] = label29;
                spaces[29] = label30;
                spaces[30] = label31;
                spaces[31] = label32;
                spaces[32] = label33;
                spaces[33] = label34;
                spaces[34] = label35;
                spaces[35] = label36;
                spaces[36] = label37;
                spaces[37] = label38;
                spaces[38] = label39;
                spaces[39] = label40;
                spaces[40] = label41;
                spaces[41] = label42;
                spaces[42] = label43;
                spaces[43] = label44;
                spaces[44] = label45;
                spaces[45] = label46;
                spaces[46] = label47;
                spaces[47] = label48;
                spaces[48] = label49;
                spaces[49] = label50;
                spaces[50] = label51;
                spaces[51] = label52;
                spaces[52] = label53;
                spaces[53] = label54;
                spaces[54] = label55;
                spaces[55] = label56;
                spaces[56] = label57;
                spaces[57] = label58;
                spaces[58] = label59;
                spaces[59] = label60;
                spaces[60] = label61;
                spaces[61] = label62;
                spaces[62] = label63;
                spaces[63] = label64;
                spaces[64] = label65;
                spaces[65] = label66;
                spaces[66] = label67;
                spaces[67] = label68;
                spaces[68] = label69;
                spaces[69] = label70;
                spaces[70] = label71;
                spaces[71] = label72;
                spaces[72] = label73;
                spaces[73] = label74;
                spaces[74] = label75;
                spaces[75] = label76;
                spaces[76] = label77;
                spaces[77] = label78;
                spaces[78] = label79;
                spaces[79] = label80;
                spaces[80] = label81;
                spaces[81] = label82;
                spaces[82] = label83;
                spaces[83] = label84;

            handSpaces = new Label[8];
            handSpaces[0] = label85;
            handSpaces[1] = label86;
            handSpaces[2] = label87;
            handSpaces[3] = label88;
            handSpaces[4] = label89;
            handSpaces[5] = label90;
            handSpaces[6] = label91;
            handSpaces[7] = label92;

            for (int i = 0; i < 8; i++) { handSpaces[i].Text = ""; }
            for (int i = 0; i < 80; i++) { spaces[i].Text = ""; }
            int size = thisPlayer.wonderStages.Length;
            for (int i = 0; i < 4; i++) 
            { 
                if (i < size) { spaces[i + 80].Text = thisPlayer.wonderStages[i].name; }
                else { spaces[i + 80].Text = ""; }
            }

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile( thisPlayer.wonder + ".jpg");
            this.Text = thisPlayer.wonder;
            InitalResource();
            UpdateGold();
            _CardForm = new CardForm(); _CardForm.Hide();
            _LeaderHandForm = new LeaderHandForm(thisPlayer.leaderHand); _LeaderHandForm.Hide();

            int filled = thisPlayer.builtCards.Count(x => x != null);
            for(int i = 0; i < filled; i++)
            {
                ShowBuiltCard(thisPlayer.builtCards[i]);
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            Label thisLabel = (Label)sender;
            LabelClick(thisLabel, 2);
        }

        private void Hand_Click(object sender, EventArgs e)
        {
            Label thisLabel = (Label) sender;
            if (phase == 0) { LabelClick(thisLabel, 0); }
            else { LabelClick(thisLabel, 1); }
        }

        private void LabelClick(Label thisLabel, int mode)
        {
            Card[] SearchHand = thisPlayer.hand;

            if (mode == 2) { SearchHand = thisPlayer.builtCards; }
            else if (thisLabel.BackColor == Color.White) { SearchHand = thisPlayer.leaderHand; }
            if (thisLabel.BackColor == SystemColors.Control) { SearchHand = thisPlayer.wonderStages; }
            
            int size = SearchHand.Count(x => x != null);
            Card thisCard = SearchHand[0];
            for (int i = 0; i < size; i++)
            {
                if (thisLabel.Text == SearchHand[i].name)
                {
                    thisCard = SearchHand[i];
                    break;
                }
            }

            if (!_CardForm.IsDisposed)
            {
                _CardForm.Close();
            }
            _CardForm = new CardForm(thisCard, mode, this);
            _CardForm.Show();
        }

        public void showHand()
        {
            Card[] thisHand = thisPlayer.hand;
            int size = thisHand.Length;
            for(int i = 0; i < 8; i++)
            {
                if (i < size)
                {
                    handSpaces[i].BackColor = getColor(thisHand[i].color);
                    handSpaces[i].Text = thisHand[i].name;
                    if (thisHand[i].color == "Black" || thisHand[i].color == "Blue" || thisHand[i].color == "Purple")
                    {
                        handSpaces[i].ForeColor = Color.White;
                    }
                    else
                    {
                        handSpaces[i].ForeColor = Color.Black;
                    }
                }
                else
                {
                    handSpaces[i].Text = "";
                }
            }
        }

        public void showLeaderHand()
        {
            Card[] thisHand = thisPlayer.leaderHand;
            int size = thisHand.Length;
            for (int i = 0; i < 8; i++)
            {
                if (i < size)
                {
                    handSpaces[i].BackColor = Color.White;
                    handSpaces[i].Text = thisHand[i].name;
                    handSpaces[i].ForeColor = Color.Black;
                }
                else
                {
                    handSpaces[i].Text = "";
                }
            }
        }

        public Color getColor(string c)
        {
            switch (c)
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

        private void InitalResource()
        {
            switch (thisPlayer.wonder)
            {
                case "Babylon": label93.Text = "Clay"; label93.BackColor = Color.Brown; break;
                case "Alexandria": label93.Text = "Glass"; label93.BackColor = Color.Gray; break;
                case "Giza": label93.Text = "Stone"; label93.BackColor = Color.Brown; break;
                case "Halikarnassos": label93.Text = "Silk"; label93.BackColor = Color.Gray; break;
                case "Rhodos": label93.Text = "Iron Ore"; label93.BackColor = Color.Brown; break;
                case "Olympus": label93.Text = "Wood"; label93.BackColor = Color.Brown; break;
                case "Ephesos": label93.Text = "Papyrus"; label93.BackColor = Color.Gray; break;
                case "Rome": label93.Text = "Leader Discount"; label93.BackColor = Color.White; break;
                case "Petra": label93.Text = "Clay"; label93.BackColor = Color.Brown; break;
                case "Byzantium": label93.Text = "Stone"; label93.BackColor = Color.Brown; break;
            }
        }

        public void SellCard(Card aCard)
        {
            thisPlayer.resources[0] += 3;
            UpdateGold();
            if (aCard.color != "White")
            {
                _MasterForm.AddDiscard(aCard);
            }
            RemoveCard(aCard);
        }

        public void PickCard(Card aCard)
        {
            if (phase == 0)
            {
                int filled = thisPlayer.tempLeaderHand.Count(x => x != null);
                thisPlayer.tempLeaderHand[filled] = aCard;
                RemoveCard(aCard);
            }
            else
            {
            }
        }

        public void BuildCard(Card aCard)
        {
            bool chain = false;
            bool built = false;
            int filled = thisPlayer.builtCards.Count(x => x != null);
            for(int i = 0; i < filled; i++) //Check for doublets and chains
            {
                if (aCard.name == thisPlayer.builtCards[i].name) { built = true; break; }
                if (aCard.preReq == thisPlayer.builtCards[i].name) { chain = true; }
                if(aCard.name == "Forum" && (thisPlayer.builtCards[i].name == "West Trading Post" || thisPlayer.builtCards[i].name == "East Trading Post")) //Brute solution to forum problem
                { chain = true; }
            }

            bool enough = true;
            for(int i = 0; i < 8; i++) //Check leader discount
            {
                if (aCard.color == "White" && i == 0) { if (aCard.cost[0] > thisPlayer.resources[0] + thisPlayer.leaderDiscount) { enough = false; break; } }
                else if (thisPlayer.resources[i] < aCard.cost[i]) { enough = false; break; }
            }
            if (thisPlayer.haveLeader[0] && aCard.color == "Purple") { enough = true; } //Check for Ramses

            if((chain || enough) && !built && !(thisPlayer.haveLeader[7] && aCard.color == "Black"))
            {
                if(!chain && aCard.color == "White")
                {
                    int cost = aCard.cost[0] - thisPlayer.leaderDiscount;
                    if (cost < 0) { cost = 0; }
                    thisPlayer.resources[0] -= cost;
                }
                else if (!chain) { thisPlayer.resources[0] -= aCard.cost[0]; }
                UpdateGold();

                if(chain && thisPlayer.haveLeader[5] ) //Vitruvian
                { thisPlayer.resources[0] += 2; }
                

                CardBuilt(aCard);
            }
            else if(!built && aCard.color != "White")
            {
                PaymentForm pay = new PaymentForm(aCard, thisPlayer.specials, thisPlayer, _MasterForm.master);
                pay.Show();
                this.Hide();
            }
            else { DisplayMessage("Allready built"); }
        }

        public void CardBuilt(Card aCard)
        {
            thisPlayer.berenice = thisPlayer.resources[0]; //Berenice
            int filled = thisPlayer.builtCards.Count(x => x != null);
            thisPlayer.builtCards[filled] = aCard;

            AddColor(aCard.color);
            ShowBuiltCard(aCard);
            CardEffects.effects(aCard.effect, thisPlayer, _MasterForm.master);

            if ((thisPlayer.haveLeader[4] && aCard.color == "Yellow") || (thisPlayer.haveLeader[10] && aCard.color == "Black")) 
            { thisPlayer.resources[0] += 2; } //Leader Bonuses

            RemoveCard(aCard);            
        }

        public void CardBuilt(Card aCard, Card stageCard)
        {
            thisPlayer.berenice = thisPlayer.resources[0]; //Berenice
            int filled = thisPlayer.builtCards.Count(x => x != null);
            thisPlayer.builtCards[filled] = stageCard;

            int size = thisPlayer.wonderStages.Length;
            Card[] tempStages = new Card[size - 1];
            for (int i = 0; i < size - 1; i++) { tempStages[i] = thisPlayer.wonderStages[i + 1]; }
            thisPlayer.wonderStages = tempStages;

            AddColor(stageCard.color);
            ShowBuiltCard(stageCard);
            CardEffects.effects(stageCard.effect, thisPlayer, _MasterForm.master);
            RemoveCard(aCard);
        }

        public void AddColor(string color)
        {
            switch (color)
            {
                case "White": thisPlayer.nColors[0]++; break;
                case "Black": thisPlayer.nColors[1]++; break;
                case "Brown": thisPlayer.nColors[2]++; break;
                case "Grey": thisPlayer.nColors[3]++; break;
                case "Green": thisPlayer.nColors[4]++; break;
                case "Yellow": thisPlayer.nColors[5]++; break;
                case "Red": thisPlayer.nColors[6]++; break;
                case "Blue": thisPlayer.nColors[7]++; break;
                case "Wondrous": thisPlayer.nColors[8]++; break;
                case "Purple": thisPlayer.nColors[9]++; break;
            }
        }

        public void BuildWonder(Card aCard)
        {
            Card stageCard = new Card();
            bool built = false;
            int size = thisPlayer.wonderStages.Length;
            if(size > 0) { stageCard = thisPlayer.wonderStages[0]; }
            else { messageBoard.Text = "All Wonder stages are allready built!"; built = true; }
            
            bool enough = true;
            for (int i = 0; i < 8; i++)
            {
                if (thisPlayer.resources[i] < stageCard.cost[i]) { enough = false; break; }
            }
            if (thisPlayer.haveLeader[15] && thisPlayer.resources[0] >= stageCard.cost[0]) { enough = true; } //Check for Architect

            if (enough && !built)
            {
                thisPlayer.resources[0] -= stageCard.cost[0];

                CardBuilt(aCard, stageCard);
            }
            else if (!built)
            {
                PaymentForm pay = new PaymentForm(aCard, thisPlayer.specials, thisPlayer, _MasterForm.master, stageCard);
                pay.Show();
                this.Hide();
            }
        }

        public void RemoveCard(Card aCard)
        {
            Card[] tempHand;
            if (aCard.color == "White")
            {
                int size = thisPlayer.leaderHand.Length;
                tempHand = new Card[size - 1];
                int j = 0;
                for(int i = 0; i < size; i++)
                {
                    if(aCard != thisPlayer.leaderHand[i])
                    {
                        tempHand[j] = thisPlayer.leaderHand[i]; j++;
                    }
                }
                thisPlayer.leaderHand = tempHand;
            }
            else
            {
                int size = thisPlayer.hand.Length;
                tempHand = new Card[size - 1];
                int j = 0; bool done = false;
                for(int i = 0; i < size; i++)
                {
                    if(aCard != thisPlayer.hand[i] || done)
                    {
                        tempHand[j] = thisPlayer.hand[i]; j++;
                    }
                    else { done = true; }
                }
                thisPlayer.hand = tempHand;
            }

            if (thisPlayer.haveLeader[6] && thisPlayer.berenice < thisPlayer.resources[0]) { thisPlayer.berenice2 = true; } //Berenice

            if (_MasterForm.lastCard && tempHand.Length != 0)
            {
                if (!thisPlayer.babylon)
                {
                    _MasterForm.AddDiscard(thisPlayer.hand[0]);
                    this.Hide(); _LeaderHandForm.Hide();
                    _MasterForm.nextPlayer();
                }
                else
                {
                    showHand();
                    thisPlayer.board.Show();
                }
            }
            else
            {
                this.Hide(); _LeaderHandForm.Hide();
                _MasterForm.nextPlayer();
            }
        }

        public void ShowBuiltCard(Card aCard)
        {
            int position = 0;
            switch (aCard.color)
            {
                case "Blue": position = 0; break;
                case "Red": position = 13; break;
                case "Yellow": position = 36; break;
                case "Black": position = 48; break;
                case "Brown": position = 59; break;
                case "Grey": position = 59; break;
                case "Purple": position = 70; break;
                case "White": position = 75; break;
                case "Wondrous": position = 80; break;
                case "Green":
                    if (aCard.symbol == 1) { position = 24; }
                    if (aCard.symbol == 2) { position = 28; }
                    if (aCard.symbol == 3) { position = 32; }
                    break;
            }
            for(int i = position; i < 84; i++)
            {
                if (spaces[i].Text == "" || spaces[i].Text == aCard.name)
                {
                    spaces[i].Text = aCard.name;
                    spaces[i].BackColor = getColor(aCard.color);
                    if (aCard.color == "Black" || aCard.color == "Blue" || aCard.color == "Purple")
                    {
                        spaces[i].ForeColor = Color.White;
                    }
                    else
                    {
                        spaces[i].ForeColor = Color.Black;
                    }
                    break;
                }
            }
        }

        public void DisplayMessage(string message)
        {
            messageBoard.Text = message;
        }

        public void UpdateGold()
        {
            GoldLabel.Text = "Coins: " + thisPlayer.resources[0].ToString();
            MilitaryLabel.Text = "Military Strength: " + thisPlayer.militaryStrength.ToString();
        }

        private void Playerboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            _CardForm.Close();
            if (!copy)
            {
                _MasterForm.Show();
            }
        }

        private void neighbourButton_Click(object sender, EventArgs e)
        {
            if(_MasterForm.Neighbourhood.IsDisposed)
            {
                _MasterForm.Neighbourhood = new ResultForm(_MasterForm, "Neighbourhood");
            }
            else { _MasterForm.Neighbourhood.Show(); }
        }

        private void leaderButton_Click(object sender, EventArgs e)
        {
            if (phase == 0)
            {
                if (_LeaderHandForm == null) { _LeaderHandForm = new LeaderHandForm(thisPlayer.tempLeaderHand); }
                else if (_LeaderHandForm.IsDisposed) { _LeaderHandForm = new LeaderHandForm(thisPlayer.tempLeaderHand); }
                else { _LeaderHandForm.Close(); _LeaderHandForm = new LeaderHandForm(thisPlayer.tempLeaderHand); }
                _LeaderHandForm.Show();
            }
            else
            {
                if (_LeaderHandForm == null) { _LeaderHandForm = new LeaderHandForm(thisPlayer.leaderHand); }
                else if (_LeaderHandForm.IsDisposed) { _LeaderHandForm = new LeaderHandForm(thisPlayer.leaderHand); }
                else { _LeaderHandForm.Close(); _LeaderHandForm = new LeaderHandForm(thisPlayer.leaderHand); }
                _LeaderHandForm.Show();
            }
        }
    }
}
