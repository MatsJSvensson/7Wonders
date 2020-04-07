using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{
    class AgeDeck
    {
        public Card[] theDeck;
        int nPlayers;
        int version;

        public AgeDeck(int nP, int v, int age)
        {
            nPlayers = nP;
            version = v;
            int cardFactor;
            if(version > 1) { cardFactor = 8; } else { cardFactor = 7; }
            theDeck = new Card[nPlayers*cardFactor];

            switch(age)
            {
                case 1:
                    InitializeAge1();
                    break;
                case 2:
                    InitializeAge2();
                    break;
                case 3:
                    InitializeAge3();
                    break;
            }
            Shuffle(theDeck);
        }

        private void InitializeAge1()
        {
            switch (nPlayers)
            {
                case 7:
                    theDeck[42] = new Card("Blue", "Baths", "", new int[] { 0, 0, 0, 1, 0, 0, 0, 0 }, 0, 3, "3p, leads to Aqueduct");
                    theDeck[43] = new Card("Blue", "Pawnshop", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 3, "3p");
                    theDeck[44] = new Card("Yellow", "West Trading Post", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 10, 0, "1 coin discount on purchases of basic resources from your left neighbour, leads to Forum");
                    theDeck[45] = new Card("Yellow", "East Trading Post", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 11, 0, "1 coin discount on purchases of basic resources from your right neighbour, leada to Forum");
                    theDeck[46] = new Card("Yellow", "Tavern", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 15, "Gain 5 coins");
                    theDeck[47] = new Card("Red", "Stockade", "", new int[] { 0, 0, 0, 0, 1, 0, 0, 0 }, 13, 0, "1 shield");
                    theDeck[48] = new Card("Green", "Workshop", "", new int[] { 0, 0, 0, 0, 0, 1, 0, 0 }, 0, 10, 2, "1 Gear, leads to Archery Range and Laboratory");
                    goto case 6;
                case 6:
                    theDeck[35] = new Card("Brown", "Tree Farm", "", new int[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 17, 0, "Clay/Wood");
                    theDeck[36] = new Card("Brown", "Mine", "", new int[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 18, 0, "Ore/Stone");
                    theDeck[37] = new Card("Grey", "Loom", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 7, 0, "Silk");
                    theDeck[38] = new Card("Grey", "Glassworks", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 8, 0, "Glass");
                    theDeck[39] = new Card("Grey", "Press", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 9, 0, "Papyrus");
                    theDeck[40] = new Card("Blue", "Theatre", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 2, "2p, leads to Statue");
                    theDeck[41] = new Card("Yellow", "Marketplace", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 12, 0, "1 coin discount on purchases of luxury resources from neighbours, leads to Caravansery");
                    goto case 5;
                case 5:
                    theDeck[28] = new Card("Brown", "Clay Pool", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 2, 0, "Clay");
                    theDeck[29] = new Card("Brown", "Stone Pit", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 3, 0, "Stone");
                    theDeck[30] = new Card("Brown", "Forest Cave", "", new int[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 16, 0, "Ore/Wood");
                    theDeck[31] = new Card("Blue", "Altar", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 2, "2p, leads to Temple");
                    theDeck[32] = new Card("Yellow", "Tavern", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 15, "Gain 5 coins");
                    theDeck[33] = new Card("Red", "Barracks", "", new int[] { 0, 0, 1, 0, 0, 0, 0, 0 }, 13, 0, "1 shield");
                    theDeck[34] = new Card("Green", "Apothecary", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 1 }, 0, 10, 1, "1 Compass, leads to Stables and Dispensary");                    
                    goto case 4;
                case 4:
                    theDeck[21] = new Card("Brown", "Excavation", "", new int[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 14, 0, "Clay/Stone");
                    theDeck[22] = new Card("Brown", "Lumber Yard", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 1, 0, "Wood");
                    theDeck[23] = new Card("Brown", "Ore Vein", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 4, 0, "Ore");
                    theDeck[24] = new Card("Blue", "Pawnshop", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 3, "3p");
                    theDeck[25] = new Card("Yellow", "Tavern", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 15, "Gain 5 coins");
                    theDeck[26] = new Card("Red", "Guard Tower", "", new int[] { 0, 1, 0, 0, 0, 0, 0, 0 }, 13, 0, "1 shield");
                    theDeck[27] = new Card("Green", "Scriptorium", "", new int[] { 0, 0, 0, 0, 0, 0, 1, 0 }, 0, 10, 3, "1 Tablet, leads to Courthouse and Library");
                    goto case 3;
                case 3:
                    theDeck[0] = new Card("Brown", "Lumber Yard", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 1, 0, "Wood");
                    theDeck[1] = new Card("Brown", "Clay Pool", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 2, 0, "Clay");
                    theDeck[2] = new Card("Brown", "Stone Pit", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 3, 0, "Stone");
                    theDeck[3] = new Card("Brown", "Ore Vein", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 4, 0, "Ore");
                    theDeck[4] = new Card("Brown", "Clay Pit", "", new int[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 5, 0, "Clay/Ore");
                    theDeck[5] = new Card("Brown", "Timber Yard", "", new int[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 6, 0, "Stone/Wood");
                    theDeck[6] = new Card("Grey", "Loom", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 7, 0, "Silk");
                    theDeck[7] = new Card("Grey", "Glassworks", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 8, 0, "Glass");
                    theDeck[8] = new Card("Grey", "Press", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 9, 0, "Papyrus");
                    theDeck[9] = new Card("Blue", "Baths", "", new int[] { 0, 0, 0, 1, 0, 0, 0, 0 }, 0, 3, "3p, leads to Aqueduct");
                    theDeck[10] = new Card("Blue", "Altar", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 2, "2p, leads to Temple");
                    theDeck[11] = new Card("Blue", "Theatre", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 2, "2p, leads to Statue");
                    theDeck[12] = new Card("Yellow", "West Trading Post", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 10, 0, "1 coin discount on purchases of basic resources from your left neighbour, leads to Forum");
                    theDeck[13] = new Card("Yellow", "East Trading Post", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 11, 0, "1 coin discount on purchases of basic resources from your right neighbour, leads to Forum");
                    theDeck[14] = new Card("Yellow", "Marketplace", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 12, 0, "1 coin discount on purchases of luxury resources from neighbours, leads to Caravansery");
                    theDeck[15] = new Card("Red", "Stockade", "", new int[] { 0, 0, 0, 0, 1, 0, 0, 0 }, 13, 0, "1 shield");
                    theDeck[16] = new Card("Red", "Barracks", "", new int[] { 0, 0, 1, 0, 0, 0, 0, 0 }, 13, 0, "1 shield");
                    theDeck[17] = new Card("Red", "Guard Tower", "", new int[] { 0, 1, 0, 0, 0, 0, 0, 0 }, 13, 0, "1 shield");
                    theDeck[18] = new Card("Green", "Apothecary", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 1 }, 0, 10, 1, "1 Compass, leads to Stables and Dispensary");
                    theDeck[19] = new Card("Green", "Workshop", "", new int[] { 0, 0, 0, 0, 0, 1, 0, 0 }, 0, 10, 2, "1 Gear, leads to Archery Range and Laboratory");
                    theDeck[20] = new Card("Green", "Scriptorium", "", new int[] { 0, 0, 0, 0, 0, 0, 1, 0 }, 0, 10, 3, "1 Tablet, leads to Courthouse and Library");
                    break;
            }

            if (version >= 2)
            {
                BlackDeck _BlackDeck = new BlackDeck(1);
                Card[] Blacks = _BlackDeck.theDeck;
                Shuffle(Blacks);
                int start = nPlayers * 7;

                for (int i = 0; i < nPlayers; i++)
                {
                    theDeck[start + i] = Blacks[i];
                }
            }
        }

        private void InitializeAge2()
        {
            switch (nPlayers)
            {
                case 7:
                    theDeck[42] = new Card("Blue", "Aqueduct", "Baths", new int[] { 0, 0, 0, 3, 0, 0, 0, 0 }, 0, 5, "5p");
                    theDeck[43] = new Card("Blue", "Statue", "Theatre", new int[] { 0, 0, 2, 0, 1, 0, 0, 0 }, 0, 4, "4p, leads to Gardens");
                    theDeck[44] = new Card("Yellow", "Forum", "Trading Post", new int[] { 0, 2, 0, 0, 0, 0, 0, 0 }, 23, 0, "Counts as any one luxury resource, leads to Haven");
                    theDeck[45] = new Card("Yellow", "Bazar", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 27, 0, "2 coins for each grey card in yours and your neighbours' cities");
                    theDeck[46] = new Card("Red", "Walls", "", new int[] { 0, 0, 0, 3, 0, 0, 0, 0 }, 26, 0, "2 Shields, leads to Fortifications");
                    theDeck[47] = new Card("Red", "Training Ground", "", new int[] { 0, 0, 2, 0, 1, 0, 0, 0 }, 26, 0, "2 Shields, leads to Circus");
                    theDeck[48] = new Card("Green", "School", "", new int[] { 0, 0, 0, 0, 1, 0, 1, 0 }, 0, 10, 3, "1 Tablet, leads to Academy and Study");
                    goto case 6;
                case 6:
                    theDeck[35] = new Card("Blue", "Temple", "Altar", new int[] { 0, 1, 0, 0, 1, 1, 0, 0 }, 0, 3, "3p, leads to Parthenon");
                    theDeck[36] = new Card("Yellow", "Forum", "Trading Post", new int[] { 0, 2, 0, 0, 0, 0, 0, 0 }, 23, 0, "Counts as any one luxury resource, leads to Haven");
                    theDeck[37] = new Card("Yellow", "Caravansery", "Marketplace", new int[] { 0, 0, 0, 0, 2, 0, 0, 0 }, 24, 0, "Counts as any one basic resource, leads to Lighthouse");
                    theDeck[38] = new Card("Yellow", "Vineyard", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 25, 0, "1 coin for each brown card in yours and your neighbours' cities");
                    theDeck[39] = new Card("Red", "Archery Range", "Workshop", new int[] { 0, 0, 1, 0, 2, 0, 0, 0 }, 26, 0, "2 Shields");
                    theDeck[40] = new Card("Red", "Training Ground", "", new int[] { 0, 0, 2, 0, 1, 0, 0, 0 }, 26, 0, "2 Shields, leads to Circus");
                    theDeck[41] = new Card("Green", "Library", "Scriptorium", new int[] { 0, 0, 0, 2, 0, 0, 0, 1 }, 0, 10, 3, "1 Tablet, leads to Senate and University");
                    goto case 5;
                case 5:
                    theDeck[28] = new Card("Grey", "Loom", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 7, 0, "Silk");
                    theDeck[29] = new Card("Grey", "Glassworks", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 8, 0, "Glass");
                    theDeck[30] = new Card("Grey", "Press", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 9, 0, "Papyrus");
                    theDeck[31] = new Card("Blue", "Courthouse", "Scriptorium", new int[] { 0, 2, 0, 0, 0, 0, 0, 1 }, 0, 4, "4p");
                    theDeck[32] = new Card("Yellow", "Caravansery", "Marketplace", new int[] { 0, 0, 0, 0, 2, 0, 0, 0 }, 24, 0, "Counts as any one basic resource, leads to Lighthouse");
                    theDeck[33] = new Card("Red", "Stables", "Apothecary", new int[] { 0, 1, 1, 0, 1, 0, 0, 0 }, 26, 0, "2 Shields");
                    theDeck[34] = new Card("Green", "Laboratory", "Workshop", new int[] { 0, 2, 0, 0, 0, 0, 1, 0 }, 0, 10, 2, "1 Gear, leads to Siege Workshop and Observatory");
                    goto case 4;
                case 4:
                    theDeck[21] = new Card("Brown", "Sawmill", "", new int[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 19, 0, "2 Wood");
                    theDeck[22] = new Card("Brown", "Brickyard", "", new int[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 20, 0, "2 Clay");
                    theDeck[23] = new Card("Brown", "Quarry", "", new int[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 21, 0, "2 Stone");
                    theDeck[24] = new Card("Brown", "Foundry", "", new int[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 22, 0, "2 Ore");
                    theDeck[25] = new Card("Yellow", "Bazar", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 27, 0, "2 coins for each grey card in yours and your neighbours' cities");
                    theDeck[26] = new Card("Red", "Training Ground", "", new int[] { 0, 0, 2, 0, 1, 0, 0, 0 }, 26, 0, "2 Shields, leads to Circus");
                    theDeck[27] = new Card("Green", "Dispensary", "Apothecary", new int[] { 0, 0, 2, 0, 0, 1, 0, 0 }, 0, 10, 1, "1 Compass, leads to Lodge and Arena");
                    goto case 3;
                case 3:
                    theDeck[0] = new Card("Brown", "Sawmill", "", new int[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 19, 0, "2 Wood");
                    theDeck[1] = new Card("Brown", "Brickyard", "", new int[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 20, 0, "2 Clay");
                    theDeck[2] = new Card("Brown", "Quarry", "", new int[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 21, 0, "2 Stone");
                    theDeck[3] = new Card("Brown", "Foundry", "", new int[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 22, 0, "2 Ore");
                    theDeck[4] = new Card("Grey", "Loom", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 7, 0, "Silk");
                    theDeck[5] = new Card("Grey", "Glassworks", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 8, 0, "Glass");
                    theDeck[6] = new Card("Grey", "Press", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 9, 0, "Papyrus");
                    theDeck[7] = new Card("Blue", "Aqueduct", "Baths", new int[] { 0, 0, 0, 3, 0, 0, 0, 0 }, 0, 5, "5p");
                    theDeck[8] = new Card("Blue", "Temple", "Altar", new int[] { 0, 1, 0, 0, 1, 1, 0, 0 }, 0, 3, "3p, leads to Parthenon");
                    theDeck[9] = new Card("Blue", "Statue", "Theatre", new int[] { 0, 0, 2, 0, 1, 0, 0, 0 }, 0, 4, "4p leads to Gardens");
                    theDeck[10] = new Card("Blue", "Courthouse", "Scriptorium", new int[] { 0, 2, 0, 0, 0, 0, 0, 1 }, 0, 4, "4p");
                    theDeck[11] = new Card("Yellow", "Forum", "Trading Post", new int[] { 0, 2, 0, 0, 0, 0, 0, 0 }, 23, 0, "Counts as any one luxury resource, leads to Haven");
                    theDeck[12] = new Card("Yellow", "Caravansery", "Marketplace", new int[] { 0, 0, 0, 0, 2, 0, 0, 0 }, 24, 0, "Counts as any one basic resource, leads to Lighthouse");
                    theDeck[13] = new Card("Yellow", "Vineyard", "", new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 25, 0, "1 coin for each brown card in yours and your neighbours' cities");
                    theDeck[14] = new Card("Red", "Walls", "", new int[] { 0, 0, 0, 3, 0, 0, 0, 0 }, 26, 0, "2 Shields, leads to Fortifications");
                    theDeck[15] = new Card("Red", "Stables", "Apothecary", new int[] { 0, 1, 1, 0, 1, 0, 0, 0 }, 26, 0, "2 Shields");
                    theDeck[16] = new Card("Red", "Archery Range", "Workshop", new int[] { 0, 0, 1, 0, 2, 0, 0, 0 }, 26, 0, "2 Shields");
                    theDeck[17] = new Card("Green", "Dispensary", "Apothecary", new int[] { 0, 0, 2, 0, 0, 1, 0, 0 }, 0, 10, 1, "1 Compass, leads to Lodge and Arena");
                    theDeck[18] = new Card("Green", "Laboratory", "Workshop", new int[] { 0, 2, 0, 0, 0, 0, 1, 0 }, 0, 10, 2, "1 Gear, leads to Siege Workshop and Observatory");
                    theDeck[19] = new Card("Green", "Library", "Scriptorium", new int[] { 0, 0, 0, 2, 0, 0, 0, 1 }, 0, 10, 3, "1 Tablet, leads to Senate and University");
                    theDeck[20] = new Card("Green", "School", "", new int[] { 0, 0, 0, 0, 1, 0, 1, 0 }, 0, 10, 3, "1 Tablet, leads to Academy and Study");
                    break;
            }

            if (version >= 2)
            {
                BlackDeck _BlackDeck = new BlackDeck(2);
                Card[] Blacks = _BlackDeck.theDeck;
                Shuffle(Blacks);
                int start = nPlayers * 7;

                for (int i = 0; i < nPlayers; i++)
                {
                    theDeck[start + i] = Blacks[i];
                }
            }
        }

        private void InitializeAge3()
        {
            switch (nPlayers)
            {
                case 7:
                    theDeck[34] = new Card("Blue", "Palace", "", new int[] { 0, 1, 1, 1, 1, 1, 1, 1 }, 0, 8, "8p");
                    theDeck[35] = new Card("Yellow", "Arena", "Dispensary", new int[] { 0, 0, 1, 2, 0, 0, 0, 0 }, 30, 12, "3 Coins and 1p for each built wonder stage");
                    theDeck[36] = new Card("Red", "Fortifications", "Walls", new int[] { 0, 0, 3, 1, 0, 0, 0, 0 }, 31, 0, "3 Shields");
                    theDeck[37] = new Card("Red", "Arsenal", "", new int[] { 0, 0, 1, 0, 2, 0, 0, 1 }, 31, 0, "3 Shields");
                    theDeck[38] = new Card("Green", "Observatory", "Laboratory", new int[] { 0, 0, 2, 0, 0, 1, 0, 1 }, 0, 10, 2, "1 Gear");
                    theDeck[39] = new Card("Green", "Academy", "School", new int[] { 0, 0, 0, 3, 0, 1, 0, 0 }, 0, 10, 1, "1 Compass");
                    goto case 6;
                case 6:
                    theDeck[28] = new Card("Blue", "Town Hall", "", new int[] { 0, 0, 1, 2, 0, 1, 0, 0 }, 0, 6, "6p");
                    theDeck[29] = new Card("Blue", "Pantheon", "Temple", new int[] { 0, 2, 1, 0, 0, 1, 1, 1 }, 0, 7, "7p");
                    theDeck[30] = new Card("Yellow", "Lighthouse", "Caravansery", new int[] { 0, 0, 0, 1, 0, 1, 0, 0 }, 29, 11, "1 Coin and 1p for each yellow card in your city");
                    theDeck[31] = new Card("Yellow", "Chamber of Commerce", "", new int[] { 0, 2, 0, 0, 0, 0, 1, 0 }, 32, 13, "2 Coins and 2p for each grey card in your city");
                    theDeck[32] = new Card("Red", "Circus", "Training Ground", new int[] { 0, 0, 1, 3, 0, 0, 0, 0 }, 31, 0, "3 Shields");
                    theDeck[33] = new Card("Green", "Lodge", "Dispensary", new int[] { 0, 2, 0, 0, 0, 0, 1, 1 }, 0, 10, 1, "1 Compass");
                    goto case 5;
                case 5:
                    theDeck[22] = new Card("Blue", "Town Hall", "", new int[] { 0, 0, 1, 2, 0, 1, 0, 0 }, 0, 6, "6p");
                    theDeck[23] = new Card("Blue", "Senate", "Library", new int[] { 0, 0, 1, 1, 2, 0, 0, 0 }, 0, 6, "6p");
                    theDeck[24] = new Card("Yellow", "Arena", "Dispensary", new int[] { 0, 0, 1, 2, 0, 0, 0, 0 }, 30, 12, "3 Coins and 1p for each built wonder stage");
                    theDeck[25] = new Card("Red", "Circus", "Training Ground", new int[] { 0, 0, 1, 3, 0, 0, 0, 0 }, 31, 0, "3 Shields");
                    theDeck[26] = new Card("Red", "Siege Workshop", "Laboratory", new int[] { 0, 3, 0, 0, 1, 0, 0, 1 }, 31, 0, 2, "3 Shields");
                    theDeck[27] = new Card("Green", "Study", "School", new int[] { 0, 1, 0, 0, 0, 0, 1, 1 }, 0, 10, 2, "1 Gear");
                    goto case 4;
                case 4:
                    theDeck[16] = new Card("Blue", "Gardens", "Statue", new int[] { 0, 2, 0, 0, 1, 0, 0, 0 }, 0, 5, "5p");
                    theDeck[17] = new Card("Yellow", "Haven", "Forum", new int[] { 0, 0, 1, 0, 1, 0, 0, 1 }, 28, 9, "1 Coin and 1p for each brown card in your city");
                    theDeck[18] = new Card("Yellow", "Chamber of Commerce", "", new int[] { 0, 2, 0, 0, 0, 0, 1, 0 }, 32, 13, "2 Coins and 2p for each grey card in your city");
                    theDeck[19] = new Card("Red", "Arsenal", "", new int[] { 0, 0, 1, 0, 2, 0, 0, 1 }, 31, 0, "3 Shields");
                    theDeck[20] = new Card("Red", "Circus", "Training Ground", new int[] { 0, 0, 1, 3, 0, 0, 0, 0 }, 31, 0, "3 Shields");
                    theDeck[21] = new Card("Green", "University", "Library", new int[] { 0, 0, 0, 0, 2, 1, 1, 0 }, 0, 10, 3, "1 Tablet");
                    goto case 3;
                case 3:
                    theDeck[0] = new Card("Blue", "Pantheon", "Temple", new int[] { 0, 2, 1, 0, 0, 1, 1, 1 }, 0, 7, "7p");
                    theDeck[1] = new Card("Blue", "Gardens", "Statue", new int[] { 0, 2, 0, 0, 1, 0, 0, 0 }, 0, 5, "5p");
                    theDeck[2] = new Card("Blue", "Town Hall", "", new int[] { 0, 0, 1, 2, 0, 1, 0, 0 }, 0, 6, "6p");
                    theDeck[3] = new Card("Blue", "Palace", "", new int[] { 0, 1, 1, 1, 1, 1, 1, 1 }, 0, 8, "8p");
                    theDeck[4] = new Card("Blue", "Senate", "Library", new int[] { 0, 0, 1, 1, 2, 0, 0, 0 }, 0, 6, "6p");
                    theDeck[5] = new Card("Yellow", "Haven", "Forum", new int[] { 0, 0, 1, 0, 1, 0, 0, 1 }, 28, 9, "1 Coin and 1p for each brown card in your city");
                    theDeck[6] = new Card("Yellow", "Lighthouse", "Caravansery", new int[] { 0, 0, 0, 1, 0, 1, 0, 0 }, 29, 11, "1 Coin and 1p for each yellow card in your city");
                    theDeck[7] = new Card("Yellow", "Arena", "Dispensary", new int[] { 0, 0, 1, 2, 0, 0, 0, 0 }, 30, 12, "3 Coins and 1p for each built wonder stage");
                    theDeck[8] = new Card("Red", "Fortifications", "Walls", new int[] { 0, 0, 3, 1, 0, 0, 0, 0 }, 31, 0, "3 Shields");
                    theDeck[9] = new Card("Red", "Arsenal", "", new int[] { 0, 0, 1, 0, 2, 0, 0, 1 }, 31, 0, "3 Shields");
                    theDeck[10] = new Card("Red", "Siege Workshop", "Laboratory", new int[] { 0, 3, 0, 0, 1, 0, 0, 1 }, 31, 0, "3 Shields");
                    theDeck[11] = new Card("Green", "Lodge", "Dispensary", new int[] { 0, 2, 0, 0, 0, 0, 1, 1 }, 0, 10, 1, "1 Compass");
                    theDeck[12] = new Card("Green", "Observatory", "Laboratory", new int[] { 0, 0, 2, 0, 0, 1, 0, 1 }, 0, 10, 2, "1 Gear");
                    theDeck[13] = new Card("Green", "University", "Library", new int[] { 0, 0, 0, 0, 2, 1, 1, 0 }, 0, 10, 3, "1 Tablet");
                    theDeck[14] = new Card("Green", "Academy", "School", new int[] { 0, 0, 0, 3, 0, 1, 0, 0 }, 0, 10, 1, "1 Compass");
                    theDeck[15] = new Card("Green", "Study", "School", new int[] { 0, 1, 0, 0, 0, 0, 1, 1 }, 0, 10, 2, "1 Gear");
                    break;
            }

            GuildDeck _GuildDeck = new GuildDeck(version);
            Card[] Guilds = _GuildDeck.theDeck;
            Shuffle(Guilds);
            int start = nPlayers * 6 - 2;

            for(int i = 0; i < nPlayers +2; i++)
            {
                theDeck[start + i] = Guilds[i];
            }

            if (version >= 2)
            {
                BlackDeck _BlackDeck = new BlackDeck(3);
                Card[] Blacks = _BlackDeck.theDeck;
                Shuffle(Blacks);
                start = nPlayers * 7;

                for(int i = 0; i < nPlayers; i++)
                {
                    theDeck[start + i] = Blacks[i];
                }
            }
        }

        public void Shuffle(Card[] aDeck)
        {
            Random r = new Random();
            int r1; int r2;
            int size = aDeck.Length;
            Card temp;

            for(int i = 0; i < size; i++)
            {
                r1 = r.Next(0, size); r2 = r.Next(0, size);
                temp = aDeck[r1];
                aDeck[r1] = aDeck[r2];
                aDeck[r2] = temp;
            }
        }
    }
}
