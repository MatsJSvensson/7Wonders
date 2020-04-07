using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{
    public class Player
    {
        public int position;
        public int[] resources = new int[8];
        public string wonder;
        public Card[] builtCards;
        public Card[] hand;
        public Card[] leaderHand;
        public Card[] tempLeaderHand;
        public Card[] wonderStages;
        public int leaderDiscount;
        public int basicDiscountWest;
        public int basicDiscountEast;
        public int luxuryDiscount;
        public int militaryStrength;
        public int moneyWest;
        public int moneyEast;
        public int imminentLoss;
        public int debt;
        public int berenice;
        public bool berenice2;
        public int wins;
        public int losses;
        public int winScore;
        public int diplomacy;
        public int[] totalScore;
        public int[] sciences;
        public int scienceSetScore;
        public Playerboard board;
        public SpecialResource[] specials;
        public bool[] haveLeader; //Ramses, Tomyris, Hatshepsut, Nero, Xenophon, Vitruvius, Berenice, Caligula1, Caligula2, Semiramis, Diocletian, ClandW1, ClandW2, ClandE1, ClandE2, Architect
        public bool babylon;
        public bool rome;
        public int[] nColors; //White, Black, Brown, Grey, Green, Yellow, Red, Blue, Wondrous, Purple
        public int[] decisions; //Olympus, Spy Card, Courtesan, Science Symbol, Halikarnassos

        public Player(string wonderName, int pos, int version)
        {
            wonder = wonderName;
            position = pos;
            resources = new int[] { 3, 0, 0, 0, 0, 0, 0, 0 };
            leaderDiscount = 0; basicDiscountEast = 0; basicDiscountWest = 0; luxuryDiscount = 0;
            militaryStrength = 0; wins = 0; losses = 0; winScore = 0;
            diplomacy = 0;
            moneyEast = 0; moneyWest = 0; imminentLoss = 0; debt = 0;
            totalScore = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0};
            haveLeader = new bool[16]; for (int i = 0; i < 16; i++) { haveLeader[i] = false; }
            babylon = false; rome = false; berenice2 = false;
            sciences = new int[] { 0, 0, 0 }; scienceSetScore = 7;
            specials = new SpecialResource[15];
            nColors = new int[10]; for (int i = 0; i < 10; i++) { nColors[i] = 0; }
            decisions = new int[] { 0, 0, 0, 0, 0 };

            if (version >= 1) 
            { 
                resources[0] += 3;                
            }
            leaderHand = new Card[4]; //Allways created, not allways seen
            tempLeaderHand = new Card[4];
            int handSize = 7; if (version >= 2) { handSize = 8; }
            hand = new Card[handSize]; 
            builtCards = new Card[handSize*4];
            initializeStages();
        }

        private void initializeStages()
        {
            switch (wonder)
            {
                case "Babylon":
                    wonderStages = new Card[3];
                    wonderStages[0] = new Card("Wondrous", "Stage 1", "", new int[] { 0, 1, 0, 0, 0, 0, 0, 1 }, 0, 3, "3p");
                    wonderStages[1] = new Card("Wondrous", "Stage 2", "", new int[] { 0, 0, 0, 0, 2, 1, 0, 0 }, 79, 0, "You may use the last card in your hand");
                    wonderStages[2] = new Card("Wondrous", "Stage 3", "", new int[] { 0, 1, 0, 0, 0, 0, 0, 1 }, 0, 41, "Counts as a scientific symbol of your choice");
                    resources[1] = 1;
                    break;
                case "Alexandria":
                    wonderStages = new Card[3];
                    wonderStages[0] = new Card("Wondrous", "Stage 1", "", new int[] { 0, 2, 0, 0, 0, 0, 0, 0 }, 80, 0, "Counts as any one basic resource");
                    wonderStages[1] = new Card("Wondrous", "Stage 2", "", new int[] { 0, 0, 0, 0, 2, 0, 0, 0 }, 81, 0, "Counts as any one luxury resource");
                    wonderStages[2] = new Card("Wondrous", "Stage 3", "", new int[] { 0, 0, 0, 3, 0, 0, 0, 1 }, 0, 7, "7p");
                    resources[5] = 1;
                    break;
                case "Giza":
                    wonderStages = new Card[4];
                    wonderStages[0] = new Card("Wondrous", "Stage 1", "", new int[] { 0, 0, 0, 0, 2, 0, 0, 0 }, 0, 3, "3p");
                    wonderStages[1] = new Card("Wondrous", "Stage 2", "", new int[] { 0, 0, 0, 3, 0, 0, 0, 0 }, 0, 5, "5p");
                    wonderStages[2] = new Card("Wondrous", "Stage 3", "", new int[] { 0, 3, 0, 0, 0, 0, 0, 0 }, 0, 5, "5p");
                    wonderStages[3] = new Card("Wondrous", "Stage 4", "", new int[] { 0, 0, 0, 4, 0, 0, 1, 0 }, 0, 7, "7p");
                    resources[3] = 1;
                    break;
                case "Olympus":
                    wonderStages = new Card[3];
                    wonderStages[0] = new Card("Wondrous", "Stage 1", "", new int[] { 0, 0, 0, 0, 2, 0, 0, 0 }, 82, 0, "1 Coin discount on basic resources from neighbours");
                    wonderStages[1] = new Card("Wondrous", "Stage 2", "", new int[] { 0, 0, 0, 2, 0, 0, 0, 0 }, 0, 5, "5p");
                    wonderStages[2] = new Card("Wondrous", "Stage 3", "", new int[] { 0, 0, 2, 0, 0, 0, 0, 1 }, 0, 50, "Enables you to copy a Guild from a neighbouring players city");
                    resources[4] = 1;
                    break;
                case "Halikarnassos":
                    wonderStages = new Card[3];
                    wonderStages[0] = new Card("Wondrous", "Stage 1", "", new int[] { 0, 0, 2, 0, 0, 0, 0, 0 }, 83, 2, "2p and you may immidiately build a card from the discard pile for free");
                    wonderStages[1] = new Card("Wondrous", "Stage 2", "", new int[] { 0, 3, 0, 0, 0, 0, 0, 0 }, 83, 1, "1p and you may immidiately build a card from the discard pile for free");
                    wonderStages[2] = new Card("Wondrous", "Stage 3", "", new int[] { 0, 0, 0, 0, 0, 1, 1, 1 }, 83, 0, "You may immidiately build a card from the discard pile for free");
                    resources[7] = 1;
                    break;
                case "Ephesos":
                    wonderStages = new Card[3];
                    wonderStages[0] = new Card("Wondrous", "Stage 1", "", new int[] { 0, 0, 0, 2, 0, 0, 0, 0 }, 84, 2, "2p and 4 Coins");
                    wonderStages[1] = new Card("Wondrous", "Stage 2", "", new int[] { 0, 0, 0, 0, 2, 0, 0, 0 }, 84, 3, "3p and 4 Coins");
                    wonderStages[2] = new Card("Wondrous", "Stage 3", "", new int[] { 0, 0, 0, 0, 0, 1, 1, 1 }, 84, 5, "5p and 4 Coins");
                    resources[6] = 1;
                    break;
                case "Rhodos":
                    wonderStages = new Card[2];
                    wonderStages[0] = new Card("Wondrous", "Stage 1", "", new int[] { 0, 0, 0, 3, 0, 0, 0, 0 }, 85, 3, "1 Shield, 3p and 3 Coins");
                    wonderStages[1] = new Card("Wondrous", "Stage 2", "", new int[] { 0, 0, 4, 0, 0, 0, 0, 0 }, 86, 4, "1 Shield, 4p and 4 Coins");
                    resources[2] = 1;
                    break;
                case "Rome":
                    wonderStages = new Card[3];
                    wonderStages[0] = new Card("Wondrous", "Stage 1", "", new int[] { 0, 1, 0, 0, 1, 0, 0, 0 }, 87, 0, "Draw 4 new cards to your leader hand and gain 5 Coins");
                    wonderStages[1] = new Card("Wondrous", "Stage 2", "", new int[] { 0, 1, 0, 1, 0, 0, 0, 1 }, 88, 3, "3p and you may build another leader (Not for free)");
                    wonderStages[2] = new Card("Wondrous", "Stage 3", "", new int[] { 0, 0, 0, 2, 0, 0, 1, 0 }, 88, 3, "3p and you may build another leader (Not for free)");
                    leaderDiscount = 2;
                    break;
                case "Petra":
                    wonderStages = new Card[2];
                    wonderStages[0] = new Card("Wondrous", "Stage 1", "", new int[] { 0, 2, 2, 0, 0, 0, 0, 0 }, 89, 3, "3p and everyone else looses 2 Coins");
                    wonderStages[1] = new Card("Wondrous", "Stage 2", "", new int[] { 14, 0, 0, 0, 0, 0, 0, 0 }, 0, 51, "14p");
                    resources[1] = 1;
                    break;
                case "Byzantium":
                    wonderStages = new Card[2];
                    wonderStages[0] = new Card("Wondrous", "Stage 1", "", new int[] { 0, 0, 1, 0, 1, 1, 1, 0 }, 90, 3, "3p and gain a diplomacy token");
                    wonderStages[1] = new Card("Wondrous", "Stage 2", "", new int[] { 0, 1, 2, 0, 0, 0, 0, 1 }, 90, 4, "4p and gain a diplomacy token");
                    resources[3] = 1;
                    break;
            }
        }

        public void dealCard(Card newCard, int index)
        {
            if (newCard.color == "White") { leaderHand[index] = newCard; }
            else { hand[index] = newCard; }
        }
    }
}
