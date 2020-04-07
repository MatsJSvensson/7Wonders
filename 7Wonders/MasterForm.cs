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
    public partial class MasterForm : Form
    {
        public GameMaster master;
        Playerboard[] boards;
        int currentPlayer;
        public ResultForm Neighbourhood;
        
        int phase;
        int phaseCounter;
        int age;
        int nP;
        int[] score;
        public bool lastCard;

        public MasterForm(GameMaster m)
        {
            master = m;
            currentPlayer = 0;
            phaseCounter = 0;
            age = 1;
            nP = master.nPlayers;
            lastCard = false;
            InitializeComponent();
            boards = new Playerboard[nP];
            score = new int[nP];

            if (master.version >= 1) { phase = 0; }
            else { phase = 2; }

            for(int i = 0; i < nP; i++)
            {
                score[i] = 0;
                boards[i] = new Playerboard(this, master.Players[i]);
                master.Players[i].board = boards[i];
                boards[i].Hide();
            }
            
            label1.Text = master.Players[currentPlayer].wonder;
            Neighbourhood = new ResultForm(this, "Neighborhood");
            Neighbourhood.Show();
        }

        public void nextPlayer()
        {
            currentPlayer++; 
            currentPlayer %= nP;
            label1.Text = master.Players[currentPlayer].wonder;

            bool decision = false;
            if (currentPlayer == 0) 
            {
                int i;
                for (i = 0; i < nP; i++ )
                {
                    if (master.Players[i].decisions[4] > 0) { decision = true; break; }
                    if (master.Players[i].rome) { decision = true; break; }
                }
                if (decision) 
                { 
                    DecisionForm D = new DecisionForm(master.Players[i], master, this); 
                    D.Show(); 
                }
                else
                {
                    this.Show();
                    endOfHand();
                }
            }
            else { this.Show(); }
        }

        public void AfterHalikarnassos()
        {
            bool decision = false;
            int i;
            for (i = 0; i < nP; i++)
            {
                if (master.Players[i].decisions[4] > 0) { decision = true; break; }
                if (master.Players[i].rome) { decision = true; break; }
            }
            if (decision) { DecisionForm D = new DecisionForm(master.Players[i], master, this); D.Show(); }
            else
            {
                endOfHand();
                this.Show();
            }
        }

        private void endOfHand()
        {            
            if (phase == 0)
            {
                phaseCounter++;
                if (phaseCounter < 4) { SendHands(); }
                else
                {
                    for(int i = 0; i < nP; i++)
                    {
                        master.Players[i].leaderHand = master.Players[i].tempLeaderHand;
                    }
                    phase++; phaseCounter = 0;
                }                
            }
            else if (phase == 1) //Buy Leader phase
            {
                phase++;
            } 
            else if (phase == 2) //Normal phase
            {
                int maxHand;
                if(master.version == 2) { maxHand = 8;}
                else { maxHand = 7; }
                if (phaseCounter < maxHand - 2) 
                {
                    if (phaseCounter == maxHand - 3) { lastCard = true; }
                    phaseCounter++; 
                    for(int i = 0; i < nP; i++) //Trade-money & debts
                    {
                        if (master.Players[i].haveLeader[6] && master.Players[i].berenice2) { master.Players[i].resources[0]++; }
                        master.Players[i].berenice2 = false;

                        master.Players[(i + nP - 1) % nP].resources[0] += master.Players[i].moneyEast;
                        master.Players[(i + 1) % nP].resources[0] += master.Players[i].moneyWest;
                        master.Players[i].resources[0] -= master.Players[i].moneyEast + master.Players[i].moneyWest;
                        master.Players[i].moneyEast = 0; master.Players[i].moneyWest = 0;

                        master.Players[i].resources[0] -= master.Players[i].imminentLoss;
                        master.Players[i].imminentLoss = 0;
                        if(master.Players[i].resources[0] < 0)
                        {
                            master.Players[i].debt -= master.Players[i].resources[0];
                            master.Players[i].resources[0] = 0;
                        }
                    }
                    SendHands();
                }
                else //End of turn
                {
                    lastCard = false;
                    WarResolution();
                    
                    if (age < 3) 
                    {
                        if(master.version > 0) { phase--; }
                        phaseCounter = 0;

                        int handSize = 7; if (master.version >= 2) { handSize = 8; }
                        for (int i = 0; i < nP; i++) { master.Players[i].hand = new Card[handSize]; }
                        for (int i = 0; i < handSize; i++)
                        {
                            for (int j = 0; j < nP; j++)
                            {
                                master.Players[j].dealCard(master.AgeDecks[age][i * nP + j], i);
                            }
                        }

                        for (int i = 0; i < nP; i++) { master.Players[i].haveLeader[8] = true; } //Caligula;
                        age++;
                    }
                    else
                    {
                        this.Hide();
                        scoring1();                        
                    }
                }

                if (!Neighbourhood.IsDisposed) { Neighbourhood.neighbourUpdate(); }
            }
        }

        private void SendHands()
        {
            if (phase == 0)
            {
                Card[] tempHand = master.Players[0].leaderHand;
                for(int i = 0; i < nP - 1; i++)
                {
                    master.Players[i].leaderHand = master.Players[i + 1].leaderHand;
                }
                master.Players[master.nPlayers - 1].leaderHand = tempHand;
            }
            else
            {
                if (age % 2 == 0)
                {
                    Card[] tempHand = master.Players[0].hand;
                    for (int i = 0; i < nP - 1; i++)
                    {
                        master.Players[i].hand = master.Players[i + 1].hand;
                    }
                    master.Players[nP - 1].hand = tempHand;
                }
                else
                {
                    Card[] tempHand = master.Players[nP - 1].hand;
                    for (int i = nP-1; i > 0; i--)
                    {
                        master.Players[i].hand = master.Players[i - 1].hand;
                    }
                    master.Players[0].hand = tempHand;
                }
            }
        }

        public void AddDiscard(Card aCard)
        {
            int filled = master.discardPile.Count(x => x != null);
            master.discardPile[filled] = aCard;
        }

        private void WarResolution()
        {
            int np = master.nPlayers;
            int[] warmongers = new int[np];
            int j = 0;
            for(int i = 0; i < np; i++)
            {
                if(master.Players[i].diplomacy > 0)
                {
                    master.Players[i].diplomacy--;
                }
                else
                {
                    warmongers[j] = i;
                    j++;
                }
            }
            int nWars = j;
            if (j == 2) { nWars = 1; }
            if (j == 1) { nWars = 0; }

            int[] victories = new int[np]; int[] defeats = new int[np];
            for (int i = 0; i < np; i++) { victories[i] = 0; defeats[i] = 0; }

            for (int i = 0; i < nWars; i++)
            {
                if (master.Players[warmongers[i]].militaryStrength < master.Players[warmongers[(i + 1) % j]].militaryStrength)
                {
                    victories[warmongers[(i + 1) % j]]++; defeats[warmongers[i]]++; //Leader purposes

                    master.Players[warmongers[(i + 1) % j]].wins++; 
                    master.Players[warmongers[(i + 1) % j]].winScore += 2 * age - 1;

                    if (master.Players[warmongers[i]].haveLeader[1]) //Tomyris
                    {
                        master.Players[warmongers[(i + 1) % j]].losses++;
                        master.Players[warmongers[(i + 1) % j]].winScore--;
                    }
                    else
                    {
                        master.Players[warmongers[i]].losses++;
                        master.Players[warmongers[i]].winScore--;
                    }
                }
                else if (master.Players[warmongers[i]].militaryStrength > master.Players[warmongers[(i + 1) % j]].militaryStrength)
                {
                    defeats[warmongers[(i + 1) % j]]++; victories[warmongers[i]]++; //Leader Purposes

                    master.Players[warmongers[i]].wins++;
                    master.Players[warmongers[i]].winScore += 2 * age - 1;

                    if (master.Players[warmongers[(i + 1) % j]].haveLeader[1]) //Tomyris
                    {
                        master.Players[warmongers[i]].losses++;
                        master.Players[warmongers[i]].winScore--;
                    }
                    else
                    {
                        master.Players[warmongers[(i + 1) % j]].losses++;
                        master.Players[warmongers[(i + 1) % j]].winScore--;
                    }
                }
            }

            for (int i = 0; i < np; i++) //Semiramis & Nero & Berenice
            {
                if (master.Players[i].haveLeader[3] && victories[i] > 0) 
                { 
                    master.Players[i].resources[0] += 2 * victories[i];
                    if (master.Players[i].haveLeader[6]) { master.Players[i].resources[0]++; }
                }
                if (master.Players[i].haveLeader[9]) { master.Players[i].militaryStrength += defeats[i]; }
            }
        }

        private void scoring1()
        {
            int[] totScore;
            Player p;
            int filled;

            for(int i = 0; i < nP; i++)
            {
                p = master.Players[i];
                totScore = p.totalScore;
                totScore[0] += p.winScore;
                totScore[1] += p.resources[0] / 3 - p.debt;
                filled = p.builtCards.Count(x => x != null);
                
                for(int j = 0; j < filled; j++)
                {
                    if (p.builtCards[j].scoring != 0)
                    {
                        CardEffects.scoreEffects(p.builtCards[j].scoring, p, master, p.builtCards[j]);
                    }
                }
            }
            int id;
            bool decision = false;
            for(id = 0; id < nP; id++)
            {
                if (master.Players[id].decisions.Sum() > 0) { decision = true; break; }
            }
            if (decision) { DecisionForm D = new DecisionForm(master.Players[id], master, this); D.Show(); }
            else { scoring2(); }
        }

        public void AfterDecision()
        {
            int id;
            bool decision = false;
            for (id = 0; id < nP; id++)
            {
                if (master.Players[id].decisions.Sum() > 0) { decision = true; break; }
            }
            if (decision) { DecisionForm D = new DecisionForm(master.Players[id], master, this); D.Show(); }
            else { scoring2(); }
        }

        private void scoring2()
        {
            Player p;
            int[] totScore;
            int min;
            for (int i = 0; i < nP; i++)
            {
                p = master.Players[i];
                totScore = p.totalScore;
                totScore[5] += p.sciences[0] * p.sciences[0] + p.sciences[1] * p.sciences[1] + p.sciences[2] * p.sciences[2];
                min = 10;
                if (min > p.sciences[0]) { min = p.sciences[0]; }
                if (min > p.sciences[1]) { min = p.sciences[1]; }
                if (min > p.sciences[2]) { min = p.sciences[2]; }
                totScore[5] += min * p.scienceSetScore;
            }

            ResultForm R = new ResultForm(this, "Result");
            R.Show();
            button1.Text = "Restart";
            label1.Text = "or Quit";
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Restart")
            {
                master.restart = true;
                this.Close();
            }
            else
            {
                this.Hide();
                if (boards[currentPlayer].IsDisposed) 
                { 
                    boards[currentPlayer] = new Playerboard(this, master.Players[currentPlayer]);
                    master.Players[currentPlayer].board = boards[currentPlayer];
                }

                boards[currentPlayer].phase = phase;
                if (phase < 2) { boards[currentPlayer].showLeaderHand(); }
                else { boards[currentPlayer].showHand(); }

                boards[currentPlayer].UpdateGold(); boards[currentPlayer].DisplayMessage("");
                boards[currentPlayer].Show();
            }
        }
    }
}
