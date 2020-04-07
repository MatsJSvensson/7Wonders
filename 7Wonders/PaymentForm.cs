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
    public partial class PaymentForm : Form
    {
        Label[] spaces;
        Label[] westSpaces;
        Label[] eastSpaces;
        Button[] buttons;
        int[] tempResources;
        int[] tempEast;
        int[] tempWest;
        int pWest;
        int pEast;
        int moneyEast;
        int moneyWest;
        int filled;
        int eFilled;
        int wFilled;
        int current;
        int mode;
        int nRes;
        SpecialResource[] specials;
        Card theCard;
        Player thePlayer;
        GameMaster master;
        bool wonderstage;
        Card stageCard;

        public PaymentForm(Card c, SpecialResource[] s, Player p, GameMaster m, Card sc)
        {
            specials = s;
            theCard = c;
            thePlayer = p;
            master = m;
            stageCard = sc; 
            wonderstage = true;
            theFunction();
        }

        public PaymentForm(Card c, SpecialResource[] s, Player p, GameMaster m)
        {
            specials = s;
            theCard = c;
            thePlayer = p;
            master = m;
            wonderstage = false;
            theFunction();
        }

        private void theFunction()
        {
            InitializeComponent();
            
            mode = 1;
            nRes = 0;
            moneyEast = 0; moneyWest = 0;
            pEast = (thePlayer.position + master.nPlayers - 1) % master.nPlayers;
            pWest = (thePlayer.position + 1) % master.nPlayers;

            if (thePlayer.haveLeader[7] && thePlayer.haveLeader[8] && theCard.color == "Black" ) //Caligula
            { 
                caligulaButton.Visible = true;              
            }

            spaces = new Label[14];
            spaces[0] = label5;
            spaces[1] = label6;
            spaces[2] = label7;
            spaces[3] = label8;
            spaces[4] = label9;
            spaces[5] = label10;
            spaces[6] = label11;
            spaces[7] = label12;
            spaces[8] = label13;
            spaces[9] = label14;
            spaces[10] = label15;
            spaces[11] = label16;
            spaces[12] = label17;
            spaces[13] = label18;

            westSpaces = new Label[7];
            westSpaces[0] = label19;
            westSpaces[1] = label20;
            westSpaces[2] = label21;
            westSpaces[3] = label22;
            westSpaces[4] = label23;
            westSpaces[5] = label24;
            westSpaces[6] = label25;

            eastSpaces = new Label[7];
            eastSpaces[0] = label26;
            eastSpaces[1] = label27;
            eastSpaces[2] = label28;
            eastSpaces[3] = label29;
            eastSpaces[4] = label30;
            eastSpaces[5] = label31;
            eastSpaces[6] = label32;

            buttons = new Button[7];
            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;

            tempResources = new int[8];
            tempWest = new int[7];
            tempEast = new int[7];
            if (!wonderstage)
            {
                for (int i = 1; i < 8; i++)
                {
                    tempResources[i] = theCard.cost[i] - thePlayer.resources[i];
                    if (tempResources[i] < 0) { tempResources[i] = 0; }
                    tempWest[i - 1] = master.Players[pWest].resources[i];
                    tempEast[i - 1] = master.Players[pEast].resources[i];
                }
                tempResources[0] = thePlayer.resources[0] - theCard.cost[0];
            }
            else
            {
                for (int i = 1; i < 8; i++)
                {
                    tempResources[i] = stageCard.cost[i] - thePlayer.resources[i];
                    if (tempResources[i] < 0) { tempResources[i] = 0; }
                    tempWest[i - 1] = master.Players[pWest].resources[i];
                    tempEast[i - 1] = master.Players[pEast].resources[i];
                }
                tempResources[0] = thePlayer.resources[0] - stageCard.cost[0];
            }

            filled = specials.Count(x => x != null);
            eFilled = master.Players[pEast].specials.Count(x => x != null);
            wFilled = master.Players[pWest].specials.Count(x => x != null);

            label3.Text = "Coins left: " + tempResources[0].ToString();
            label2.Text = "Clay: " + tempResources[1].ToString() + "   Ore: " + tempResources[2].ToString() + "   Stone: " + tempResources[3].ToString() + "   Wood: " + tempResources[4].ToString() + "   Glass: " + tempResources[5].ToString() + "   Papyrus: " + tempResources[6].ToString() + "   Silk: " + tempResources[7].ToString();

            if (!wonderstage)
            {
                for (int i = 0; i < 14; i++)
                {
                    if (i < filled)
                    {
                        if (specials[i].condition == "" || specials[i].condition == theCard.color) { spaces[i].Text = specials[i].name; }
                        else { spaces[i].Text = ""; }
                        if (specials[i].name == "Secret Warehouse") { SecretWarehouse(i); }
                        if (specials[i].name == "Black Market") { BlackMarket(i); }
                    }
                    else { spaces[i].Text = ""; }
                }
            }
            else
            {
                for (int i = 0; i < 14; i++)
                {
                    if (i < filled)
                    {
                        if (specials[i].condition == "" || specials[i].condition == stageCard.color) { spaces[i].Text = specials[i].name; }
                        else { spaces[i].Text = ""; }
                        if (specials[i].name == "Secret Warehouse") { SecretWarehouse(i); }
                        if (specials[i].name == "Black Market") { BlackMarket(i); }
                    }
                    else { spaces[i].Text = ""; }
                }
            }

            int counter = 1;
            for (int i = 0; i < wFilled; i++)
            {
                if(master.Players[pWest].specials[i].tradable)
                {
                    westSpaces[counter].Text = master.Players[pWest].specials[i].name; counter++;
                }
            }
            for (int i = counter; i < 7; i++) { westSpaces[i].Text = ""; }

            counter = 1;
            for (int i = 0; i < eFilled; i++)
            {
                if (master.Players[pEast].specials[i].tradable)
                {
                    eastSpaces[counter].Text = master.Players[pEast].specials[i].name; counter++;
                }
            }
            for (int i = counter; i < 7; i++) { eastSpaces[i].Text = ""; }

            current = 0;
            for (int i = 0; i < 7; i++) { buttons[i].Visible = false; }
            for (int i = 0; i < filled; i++)
            {
                if (spaces[i].Text != "")
                {
                    current = i;
                    spaces[i].BackColor = Color.Azure;
                    for (int j = 0; j < 7; j++)
                    {
                        if (specials[current].resources[j] > 0) { buttons[j].Visible = true; }
                        else { buttons[j].Visible = false; }
                    }
                    break;
                }
            }
        }

        private void SecretWarehouse (int index)
        {
            for(int i = 0; i < 7; i++)
            {
                if (thePlayer.resources[i+1] > 0) { thePlayer.specials[index].resources[i] = 1; }
                else { thePlayer.specials[index].resources[i] = 0; }
            }
            filled = thePlayer.specials.Count(x => x != null);
            for (int i = 0; i < filled; i++ )
            {
                if (thePlayer.specials[i].tradable)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (thePlayer.specials[i].resources[j] > 0) { thePlayer.specials[index].resources[i] = 1; }
                    }
                }

            }
        }
        private void BlackMarket(int index)
        {
            for (int i = 0; i < 7; i++)
            {
                if (thePlayer.resources[i+1] > 0) { thePlayer.specials[index].resources[i] = 0; }
                else { thePlayer.specials[index].resources[i] = 1; }
            }
            filled = thePlayer.specials.Count(x => x != null);
            for (int i = 0; i < filled; i++)
            {
                if (thePlayer.specials[i].tradable)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (thePlayer.specials[i].resources[j] > 0) { thePlayer.specials[index].resources[i] = 0; }
                    }
                }

            }
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button butt = (Button) sender;
            switch(butt.Text)
            {
                case "Clay": nRes = 0; break;
                case "Ore": nRes = 1; break;
                case "Stone": nRes = 2; break;
                case "Wood": nRes = 3; break;
                case "Glass": nRes = 4; break;
                case "Papyrus": nRes = 5; break;
                case "Silk": nRes = 6; break;
            }
            tempResources[nRes + 1]--;


            int cost = 0;
            switch (mode)
            {
                case 2:
                    if (nRes > 3) { cost = 2 - thePlayer.luxuryDiscount; }
                    else { cost = 2 - thePlayer.basicDiscountEast; } 
                    if (thePlayer.haveLeader[13] && thePlayer.haveLeader[14]) { cost--; thePlayer.haveLeader[14] = false; } //East Clandestine Dock
                    tempResources[0] -= cost; moneyEast += cost;

                    if (current > 0) { eastSpaces[current].Text = ""; spaces[current].BackColor = DefaultBackColor; }
                    else { tempEast[nRes]--; }
                    break;
                case 1:
                    if (specials[current].name == "Bilkis") { tempResources[0]--; }
                    spaces[current].Text = ""; spaces[current].BackColor = DefaultBackColor;
                    break;
                case 0:
                    if (nRes > 3) { cost = 2 - thePlayer.luxuryDiscount; }
                    else { cost = 2 - thePlayer.basicDiscountWest; }
                    if (thePlayer.haveLeader[11] && thePlayer.haveLeader[12]) { cost--; thePlayer.haveLeader[12] = false; } //West Clandestine Dock
                    tempResources[0] -= cost; moneyWest += cost;

                    if (current > 0) { westSpaces[current].Text = ""; spaces[current].BackColor = DefaultBackColor; }
                    else { tempWest[nRes]--; }
                    break;
            }

            label3.Text = "Coins left: " + tempResources[0].ToString();
            label2.Text = "Clay: " + tempResources[1].ToString() + "   Ore: " + tempResources[2].ToString() + "   Stone: " + tempResources[3].ToString() + "   Wood: " + tempResources[4].ToString() + "   Glass: " + tempResources[5].ToString() + "   Papyrus: " + tempResources[6].ToString() + "   Silk: " + tempResources[7].ToString();
            
            switch (mode)
            {
                case 2: mode = -1; radioEast.Checked = false; radioEast.Checked = true; break;
                case 1: mode = -1; radioMe.Checked = false; radioMe.Checked = true; break;
                case 0: mode = -1; radioWest.Checked = false; radioWest.Checked = true; break;
            }
        }

        private void labelClick(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            theLabel.BackColor = Color.Azure;

            switch (mode)
            {
                case 0: westSpaces[current].BackColor = DefaultBackColor; break;
                case 1: spaces[current].BackColor = DefaultBackColor; break;
                case 2: eastSpaces[current].BackColor = DefaultBackColor; break;
            }
            for (int i = 0; i < filled; i++) { if (theLabel == spaces[i]) { current = i; break; } }
            mode = 1; radioMe.Checked = true;
    
            for (int j = 0; j < 7; j++)
            {
                if (specials[current].resources[j] > 0) { buttons[j].Visible = true; }
                else { buttons[j].Visible = false; }
            }
            
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            bool enough = true;
            for(int i = 1; i < 8; i++)
            {
                if (tempResources[i] > 0) { enough = false; break; }
            }
            if (tempResources[0] < 0) { enough = false; }

            thePlayer.haveLeader[12] = true; thePlayer.haveLeader[14] = true; //Clandestine Docks

            if(enough)
            {
                thePlayer.moneyEast = moneyEast; thePlayer.moneyWest = moneyWest;
                if (thePlayer.haveLeader[2]) //Hatshepsut
                {
                    if (moneyEast > 0) { thePlayer.resources[0]++; thePlayer.berenice2 = true; }
                    if (moneyWest > 0) { thePlayer.resources[0]++; thePlayer.berenice2 = true; }
                }

                if (!wonderstage) 
                { 
                    thePlayer.resources[0] -= theCard.cost[0];
                    thePlayer.board.CardBuilt(theCard); 
                }
                else 
                { 
                    thePlayer.resources[0] -= stageCard.cost[0];                    
                    thePlayer.board.CardBuilt(theCard, stageCard); 
                }
                
                this.Close();
            }
            else
            {
                thePlayer.board.DisplayMessage("Still not enough...");
                thePlayer.board.Show();
                this.Close();
            }
        }

        private void radioEast_CheckedChanged(object sender, EventArgs e)
        {
            if(mode != 2)
            {
                switch (mode)
                {
                    case 0: westSpaces[current].BackColor = DefaultBackColor; break;
                    case 1: spaces[current].BackColor = DefaultBackColor; break;
                    case 2: eastSpaces[current].BackColor = DefaultBackColor; break;
                }
                eastSpaces[0].BackColor = Color.Azure;

                for (int i = 0; i < 7; i++)
                {
                    if (tempEast[i] > 0) { buttons[i].Visible = true; }
                    else { buttons[i].Visible = false; }
                }
            }
            mode = 2;
        }

        private void radioWest_CheckedChanged(object sender, EventArgs e)
        {
            if (mode != 0)
            {
                switch (mode)
                {
                    case 0: westSpaces[current].BackColor = DefaultBackColor; break;
                    case 1: spaces[current].BackColor = DefaultBackColor; break;
                    case 2: eastSpaces[current].BackColor = DefaultBackColor; break;
                }
                westSpaces[0].BackColor = Color.Azure;

                for (int i = 0; i < 7; i++)
                {
                    if (tempWest[i] > 0) { buttons[i].Visible = true; }
                    else { buttons[i].Visible = false; }
                }
            }
            mode = 0;
        }

        private void radioMe_CheckedChanged(object sender, EventArgs e)
        {
            if(mode != 1)
            {
                switch (mode)
                {
                    case 0: westSpaces[current].BackColor = DefaultBackColor; break;
                    case 1: spaces[current].BackColor = DefaultBackColor; break;
                    case 2: eastSpaces[current].BackColor = DefaultBackColor; break;
                }

                current = 0;
                for (int i = 0; i < 7; i++) { buttons[i].Visible = false; }
                for (int i = 0; i < filled; i++)
                {
                    if (spaces[i].Text != "")
                    {
                        current = i;
                        spaces[i].BackColor = Color.Azure;
                        for (int j = 0; j < 7; j++)
                        {
                            if (specials[current].resources[j] > 0) { buttons[j].Visible = true; }
                            else { buttons[j].Visible = false; }
                        }
                        break;
                    }
                }
            }
            mode = 1;
        }

        private void labelClickWest(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            theLabel.BackColor = Color.Azure;

            switch (mode)
            {
                case 0: westSpaces[current].BackColor = DefaultBackColor; break;
                case 1: spaces[current].BackColor = DefaultBackColor; break;
                case 2: eastSpaces[current].BackColor = DefaultBackColor; break;
            }
            for (int i = 0; i < 7; i++) { if (theLabel == westSpaces[i]) { current = i; break; } }
            mode = 0; radioWest.Checked = true;

            if (current == 0) //Normal
            {
                for (int i = 0; i < 7; i++)
                {
                    if (tempWest[i] > 0) { buttons[i].Visible = true; }
                    else { buttons[i].Visible = false; }
                }
            }
            else //Special
            {
                SpecialResource tempSpec = master.Players[pWest].specials.First(x => x.name == theLabel.Text);
                for (int j = 0; j < 7; j++)
                {
                    if (tempSpec.resources[j] > 0) { buttons[j].Visible = true; }
                    else { buttons[j].Visible = false; }
                }
            }
        }

        private void labelClickEast(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            theLabel.BackColor = Color.Azure;

            switch (mode)
            {
                case 0: westSpaces[current].BackColor = DefaultBackColor; break;
                case 1: spaces[current].BackColor = DefaultBackColor; break;
                case 2: eastSpaces[current].BackColor = DefaultBackColor; break;
            }
            for (int i = 0; i < 7; i++) { if (theLabel == eastSpaces[i]) { current = i; break; } }
            mode = 2; radioEast.Checked = true;

            if (current == 0) //Normal
            {
                for(int i = 0; i < 7; i++)
                {
                    if (tempEast[i] > 0) { buttons[i].Visible = true; }
                    else { buttons[i].Visible = false; }
                }
            }
            else //Special Resources
            {
                SpecialResource tempSpec = master.Players[pEast].specials.First(x => x.name == theLabel.Text);
                for (int j = 0; j < 7; j++)
                {
                    if (tempSpec.resources[j] > 0) { buttons[j].Visible = true; }
                    else { buttons[j].Visible = false; }
                }
            }
        }

        private void caligulaButton_Click(object sender, EventArgs e)
        {
            thePlayer.berenice = thePlayer.resources[0]; //Berenice
            thePlayer.board.CardBuilt(theCard);
            thePlayer.haveLeader[8] = false;
            this.Close();
        }
    }
}
