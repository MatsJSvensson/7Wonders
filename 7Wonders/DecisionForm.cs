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
    public partial class DecisionForm : Form
    {
        Label[] spaces;
        Player thePlayer;
        GameMaster theMaster;
        MasterForm theMasterForm;
        int np;
        CardForm _CardForm;
        string mode;
        int spyCounter;
        int pr, pl;

        public DecisionForm(Player aPlayer, GameMaster aMaster, MasterForm _MasterForm)
        {
            InitializeComponent();
            theMaster = aMaster;
            thePlayer = aPlayer;
            theMasterForm = _MasterForm;
            np = theMaster.nPlayers;
            spyCounter = 0;
            pl = (thePlayer.position + 1) % np; //Left Player
            pr = (thePlayer.position + np - 1) % np; //Right Player
            this.Text = thePlayer.wonder + "'s Decision";

            if (thePlayer.decisions[0] > 0) { mode = "Olympus"; }
            else if (thePlayer.decisions[1] > 0) { mode = "Spy Card"; }
            else if (thePlayer.decisions[2] > 0) { mode = "Courtesan"; }
            else if (thePlayer.decisions[3] > 0) { mode = "Science Symbol"; }
            else if (thePlayer.decisions[4] > 0) { mode = "Halikarnassos"; }
            else if (thePlayer.rome) { mode = "Rome"; }

            spaces = new Label[48];
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

            button1.Visible = false;

            switch(mode)
            {
                case "Olympus":
                    ShowNeighbours("Purple");
                    break;
                case "Spy Card":
                    ShowNeighbours("Green");
                    break;
                case "Courtesan":
                    ShowNeighbours("White");
                    break;
                case "Science Symbol":
                    for (int i = 0; i < 48; i++) { spaces[i].Text = ""; }
                    spaces[0].Text = "Compass (" + thePlayer.sciences[0].ToString() + ")";
                    spaces[16].Text = "Gear (" + thePlayer.sciences[1].ToString() + ")";
                    spaces[32].Text = "Tablet (" + thePlayer.sciences[2].ToString() + ")";
                    break;
                case "Halikarnassos":
                    ShowDiscards(0);
                    break;
                case "Rome":
                    for (int i = 0; i < 48; i++) { spaces[i].Text = ""; }
                    int filled = thePlayer.leaderHand.Length;
                    for (int i = 0; i < filled; i++ )
                    {
                        spaces[i + 16].Text = thePlayer.leaderHand[i].name;
                        spaces[i + 16].BackColor = Color.White;
                    }
                    label33.Text = "Coins: " + thePlayer.resources[0].ToString();
                    break;
            }

            _CardForm = new CardForm(); _CardForm.Hide();
        }

        private void ShowNeighbours(string color)
        {
            
            int filled;
            int counter = 0;

            filled = theMaster.Players[pl].builtCards.Count(x => x != null);
            for (int i = 0; i < filled; i++)
            {
                if (theMaster.Players[pl].builtCards[i].color == color)
                {
                    spaces[counter].Text = theMaster.Players[pl].builtCards[i].name;
                    spaces[counter].BackColor = getColor(color);
                    if (color == "Purple") { spaces[counter].ForeColor = Color.White; }
                    else { spaces[counter].ForeColor = Color.Black; }
                    counter++;
                }
            }
            for (int i = counter; i < 32; i++) { spaces[i].Text = ""; }

            counter = 32;
            filled = theMaster.Players[pr].builtCards.Count(x => x != null);
            for (int i = 0; i < filled; i++)
            {
                if (theMaster.Players[pr].builtCards[i].color == color)
                {
                    spaces[counter].Text = theMaster.Players[pr].builtCards[i].name;
                    spaces[counter].BackColor = getColor(color);
                    if (color == "Purple") { spaces[counter].ForeColor = Color.White; }
                    else { spaces[counter].ForeColor = Color.Black; }
                    counter++;
                }
            }
            for (int i = counter; i < 48; i++) { spaces[i].Text = ""; }
        }

        private void ShowDiscards(int n)
        {
            int max = 0;
            int filled = theMaster.discardPile.Count(x => x != null);
            filled -= n * 48;
            if (filled > 48) { max = 48; }
            else { max = filled; }
            for(int i = 0; i < 48; i++)
            {
                if (i < max)
                {
                    Card temp = theMaster.discardPile[i + n * 48];
                    spaces[i].Text = temp.name;
                    spaces[i].BackColor = getColor(temp.color);
                    if ( temp.color == "Purple" || temp.color == "Black" || temp.color == "Blue") { spaces[i].ForeColor = Color.White; }
                    else { spaces[i].ForeColor = Color.Black; }
                }
                else { spaces[i].Text = ""; }
            }

            if (filled > 48) { button1.Visible = true; }
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

        private void labelClickLeft(object sender, EventArgs e)
        {
            Label theLabel = (Label) sender;
            int filled;
            Card aCard = new Card();

            switch (mode)
            {
                case "Olympus":
                    int pl = (thePlayer.position + 1) % np; //Left Player
                    filled = theMaster.Players[pl].builtCards.Count(x => x != null);
                    for (int i = 0; i < filled; i++ )
                    {
                        if(theMaster.Players[pl].builtCards[i].name == theLabel.Text)
                        {
                            aCard = theMaster.Players[pl].builtCards[i];
                            break;
                        }
                    }
                    break;
                case "Spy Card":
                    goto case "Olympus";
                case "Courtesan":
                    goto case "Olympus";
                case "Science Symbol":
                    thePlayer.sciences[0]++;
                    ChosenCard(aCard); //Fictional Card
                    break;
                case "Halikarnassos":
                    filled = theMaster.discardPile.Count(x => x != null);
                    for (int i = 0; i < filled; i++ )
                    {
                        if(theMaster.discardPile[i].name == theLabel.Text)
                        {
                            aCard = theMaster.discardPile[i];
                            break;
                        }
                    }
                    break;
            }

            if (mode != "Science Symbol")
            {
                if (!_CardForm.IsDisposed)
                {
                    _CardForm.Close();
                }
                _CardForm = new CardForm(aCard, this);
                _CardForm.Show();
            }
            
        }

        private void labelClickMid(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            int filled;
            Card aCard = new Card();

            switch (mode)
            {
                case "Science Symbol":
                    thePlayer.sciences[1]++;
                    ChosenCard(aCard); //Fictional Card
                    break;
                case "Halikarnassos":
                    filled = theMaster.discardPile.Count(x => x != null);
                    for (int i = 0; i < filled; i++)
                    {
                        if (theMaster.discardPile[i].name == theLabel.Text)
                        {
                            aCard = theMaster.discardPile[i];
                            break;
                        }
                    }
                    break;
                case "Rome":
                    for (int i = 0; i < thePlayer.leaderHand.Length; i++ )
                    {
                        if(thePlayer.leaderHand[i].name == theLabel.Text)
                        {
                            aCard = thePlayer.leaderHand[i]; break;
                        }
                    }
                    break;
            }

            if (mode != "Science Symbol")
            {
                if (!_CardForm.IsDisposed)
                {
                    _CardForm.Close();
                }
                _CardForm = new CardForm(aCard, this);
                _CardForm.Show();
            }
        }

        private void labelClickRight(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            int filled;
            Card aCard = new Card();

            switch (mode)
            {
                case "Olympus":
                    int pr = (thePlayer.position + np - 1) % np; //Right Player
                    filled = theMaster.Players[pr].builtCards.Count(x => x != null);
                    for (int i = 0; i < filled; i++)
                    {
                        if (theMaster.Players[pr].builtCards[i].name == theLabel.Text)
                        {
                            aCard = theMaster.Players[pr].builtCards[i];
                            break;
                        }
                    }
                    break;
                case "Spy Card":
                    goto case "Olympus";
                case "Courtesan":
                    goto case "Olympus";
                case "Science Symbol":
                    thePlayer.sciences[2]++;
                    ChosenCard(aCard); //Fictional Card
                    break;
                case "Halikarnassos":
                    filled = theMaster.discardPile.Count(x => x != null);
                    for (int i = 0; i < filled; i++)
                    {
                        if (theMaster.discardPile[i].name == theLabel.Text)
                        {
                            aCard = theMaster.discardPile[i];
                            break;
                        }
                    }
                    break;
            }

            if (mode != "Science Symbol")
            {
                if (!_CardForm.IsDisposed)
                {
                    _CardForm.Close();
                }
                _CardForm = new CardForm(aCard, this);
                _CardForm.Show();
            }
        }

        public void ChosenCard(Card aCard)
        {
            int filled;

            switch (mode)
            {
                case "Olympus":
                    CardEffects.scoreEffects(aCard.scoring, thePlayer, theMaster, aCard);
                    thePlayer.decisions[0]--;
                    this.Close(); //Closing calls AfterHalikarnassos/AfterDecision
                    break;
                case "Spy Card":
                    thePlayer.sciences[aCard.symbol - 1]++;
                    thePlayer.decisions[1]--;
                    spyCounter++;
                    
                    if (thePlayer.decisions[1] > 0 && theMaster.Players[pl].nColors[4] + theMaster.Players[pr].nColors[4] > spyCounter)
                    {
                        for(int i = 0; i < 48; i++)
                        {
                            if(spaces[i].Text == aCard.name)
                            {
                                spaces[i].Text = "";
                                break;
                            }
                        }
                    }
                    else { this.Close(); } //Closing calls AfterHalikarnassos/AfterDecision
                    break;
                case "Courtesan":
                    CardEffects.scoreEffects(aCard.scoring, thePlayer, theMaster, aCard);
                    thePlayer.decisions[2]--;
                    this.Close(); //Closing calls AfterHalikarnassos/AfterDecision
                    break;
                case "Science Symbol":
                    thePlayer.decisions[3]--;
                    if(thePlayer.decisions[3] > 0)
                    {
                        spaces[0].Text = "Compass (" + thePlayer.sciences[0].ToString() + ")";
                        spaces[16].Text = "Gear (" + thePlayer.sciences[1].ToString() + ")";
                        spaces[32].Text = "Tablet (" + thePlayer.sciences[2].ToString() + ")";
                    }
                    else { this.Close(); } //Closing calls AfterHalikarnassos/AfterDecision
                    break;
                case "Halikarnassos":
                    thePlayer.berenice = thePlayer.resources[0]; //Berenice
                    CardEffects.effects(aCard.effect, thePlayer, theMaster);
                    filled = thePlayer.builtCards.Count(x => x != null);
                    thePlayer.builtCards[filled] = aCard;
                    thePlayer.board.ShowBuiltCard(aCard);
                    filled = theMaster.discardPile.Count(x => x != null);
                    for(int i = 0; i < filled; i++)
                    {
                        if (theMaster.discardPile[i] == aCard) 
                        {
                            theMaster.discardPile[i] = theMaster.discardPile[filled - 1];
                            theMaster.discardPile[filled - 1] = null;
                            break;
                        }
                    }
                    if ((thePlayer.haveLeader[4] && aCard.color == "Yellow") || (thePlayer.haveLeader[10] && aCard.color == "Black")) 
                    { thePlayer.resources[0] += 2; } //Leader Bonuses
                    if (thePlayer.haveLeader[6] && thePlayer.berenice < thePlayer.resources[0]) { thePlayer.berenice2 = true; } //Berenice

                    thePlayer.decisions[4]--;
                    this.Close(); //Closing calls AfterHalikarnassos/AfterDecision
                    break;
                case "Rome":
                    int cost = aCard.cost[0] - thePlayer.leaderDiscount;
                    if (thePlayer.resources[0] > cost)
                    {
                        if (cost < 0) { cost = 0; }
                        thePlayer.resources[0] -= cost;
                        filled = thePlayer.builtCards.Count(x => x != null);
                        thePlayer.builtCards[filled] = aCard;
                        thePlayer.board.ShowBuiltCard(aCard);
                        CardEffects.effects(aCard.effect, thePlayer, theMaster);

                        int size = thePlayer.leaderHand.Length;
                        Card[] tempHand = new Card[size - 1];
                        int j = 0;
                        for (int i = 0; i < size; i++)
                        {
                            if (aCard != thePlayer.leaderHand[i])
                            {
                                tempHand[j] = thePlayer.leaderHand[i]; j++;
                            }
                        }
                        thePlayer.leaderHand = tempHand;

                        thePlayer.rome = false;
                        this.Close(); //Closing calls AfterHalikarnassos/AfterDecision
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "More...")
            {
                ShowDiscards(1);
                button1.Text = "Less";
            }
            else if (button1.Text == "Less")
            {
                ShowDiscards(0);
                button1.Text = "More...";
            }
        }

        private void DecisionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mode == "Halikarnassos" || mode == "Rome")
            {
                theMasterForm.AfterHalikarnassos();
            }
            else
            {
                theMasterForm.AfterDecision();
            }
        }

        private void ignoreButton_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case "Olympus":
                    thePlayer.decisions[0]--;
                    break;
                case "Spy Card":
                    thePlayer.decisions[1]--;
                    break;
                case "Courtesan":
                    thePlayer.decisions[2]--;
                    break;
                case "Science Symbol":
                    thePlayer.decisions[3]--;
                    break;
                case "Halikarnassos":
                    thePlayer.decisions[4]--;
                    break;
                case "Rome":
                    thePlayer.rome = false;
                    break;
            }
            this.Close();
        }

    }
}
