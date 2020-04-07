using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{
    public class GameMaster
    {
        public Player[] Players;
        Card[] theLeaderDeck;
        public Card[][] AgeDecks;
        public Card[] discardPile;
        
        string[] wonders;
        public int nPlayers;
        public int version;
        public bool restart;

        public GameMaster(int[] startVal)
        {
            nPlayers = startVal[0]; version = startVal[1];
            Players = new Player[nPlayers];
            restart = false;

            initializeWonders();

            for(int i = 0; i < nPlayers; i++)
            {
                Players[i] = new Player(wonders[i], i, version);
            }

            for (int i = 0; i < nPlayers; i++) //Kolla Roms grannar
            {
                if(Players[i].wonder == "Rome")
                {
                    Players[(i+nPlayers-1)%nPlayers].leaderDiscount = 1;
                    Players[(i + 1) % nPlayers].leaderDiscount = 1;
                }
            }

            if (version >= 1)
            {
                LeaderDeck _LeaderDeck = new LeaderDeck(version);
                theLeaderDeck = _LeaderDeck.theDeck;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < nPlayers; j++)
                    {
                        Players[j].dealCard(theLeaderDeck[i * nPlayers + j], i);
                    }
                }
            }
            AgeDecks = new Card[3][];
            AgeDeck _AgeDeck1 = new AgeDeck(nPlayers, version, 1); AgeDecks[0] = _AgeDeck1.theDeck;
            AgeDeck _AgeDeck2 = new AgeDeck(nPlayers, version, 2); AgeDecks[1] = _AgeDeck2.theDeck;
            AgeDeck _AgeDeck3 = new AgeDeck(nPlayers, version, 3); AgeDecks[2] = _AgeDeck3.theDeck;

            int handSize = 7; if (version >= 2) { handSize = 8; }
            for(int i = 0; i < handSize; i++)
            {
                for(int j = 0; j < nPlayers; j++)
                {
                    Players[j].dealCard(AgeDecks[0][i * nPlayers + j], i);
                }
            }
            discardPile = new Card[8 * nPlayers];
        }

        private void initializeWonders()
        {
            int versionBonus = 0;
            if (version == 1) { versionBonus = 1; }
            if (version == 2) { versionBonus = 3; }
            wonders = new string[7 + versionBonus];

            wonders[0] = "Babylon";
            wonders[1] = "Alexandria";
            wonders[2] = "Giza";
            wonders[3] = "Olympus";
            wonders[4] = "Halikarnassos";
            wonders[5] = "Ephesos";
            wonders[6] = "Rhodos";

            if(version >= 1)
            {
                wonders[7] = "Rome";
            }
            if(version >= 2)
            {
                wonders[8] = "Petra";
                wonders[9] = "Byzantium";
            }

            ShuffleString(wonders);
        }

        private void ShuffleString(string[] aDeck)
        {
            Random r = new Random();
            int r1; int r2;
            int size = aDeck.Length;
            string temp;

            for (int i = 0; i < size; i++)
            {
                r1 = r.Next(0, size); r2 = r.Next(0, size);
                temp = aDeck[r1];
                aDeck[r1] = aDeck[r2];
                aDeck[r2] = temp;
            }
        }

        public void dealRome(int player)
        {
            int size = Players[player].leaderHand.Length;
            Card[] tempHand = new Card[size + 4];
            for(int i = 0; i < size; i++)
            {
                tempHand[i] = Players[player].leaderHand[i];
            }
            for(int i = 0; i < 4; i++)
            {
                tempHand[size + i] = theLeaderDeck[nPlayers * 4 + i];
            }
            Players[player].leaderHand = tempHand;
        }
    }
}
