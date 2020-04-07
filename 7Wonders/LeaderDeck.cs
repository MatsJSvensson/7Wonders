using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{
    class LeaderDeck
    {
        public Card[] theDeck;

        public LeaderDeck(int version)
        {
            int versionBonus = 0;
            if(version == 2) { versionBonus = 6; }
            theDeck = new Card[36 + versionBonus];

            theDeck[0] = new Card("White", "Amytis", "", 4, 0, 14, "2p per built wonder stage");
            theDeck[1] = new Card("White", "Alexander", "", 3, 0, 15, "1p per victory token");
            theDeck[2] = new Card("White", "Aristotle", "", 3, 33, 0, "3p per science set");
            theDeck[3] = new Card("White", "Justinian", "", 3, 0, 16, "3p per set of 3 cards of the different colors red, green and blue");
            theDeck[4] = new Card("White", "Plato", "", 4, 0, 17, "7p per set of 7 cards of all colors except black and white");
            theDeck[5] = new Card("White", "Midas", "", 3, 0, 44, "1p per 3 coins rounded down");
            theDeck[6] = new Card("White", "Bilkis", "", 4, 35, 0, "Buy any one resource for 1 coin once per turn");
            theDeck[7] = new Card("White", "Maecenas", "", 1, 36, 0, "Subsequent leaders are free");
            theDeck[8] = new Card("White", "Ramses", "", 5, 37, 0, "Guilds cost no resources except coins");
            theDeck[9] = new Card("White", "Tomyris", "", 4, 38, 0, "During subsequent conflict resolutions, your defeat token are given to the victorious city");
            theDeck[10] = new Card("White", "Hannibal", "", 2, 39, 0, "Gain a shield");
            theDeck[11] = new Card("White", "Caesar", "", 5, 40, 0, "Gain 2 shields");
            theDeck[12] = new Card("White", "Hatshepsut", "", 2, 41, 0, "Once per turn per neighbour, gain 1 coin when you purchase their resources");
            theDeck[13] = new Card("White", "Nero", "", 1, 42, 0, "Gain 2 coins for each victory token you earn");
            theDeck[14] = new Card("White", "Xenophon", "", 2, 43, 0, "Gain 2 coins when you build a yellow building");
            theDeck[15] = new Card("White", "Vitruvius", "", 1, 44, 0, "Gain 2 coins each time you build a building using a chain");
            theDeck[16] = new Card("White", "Solomon", "", 3, 45, 0, "Choose an age card from the discard pile and build it for free");
            theDeck[17] = new Card("White", "Croesus", "", 1, 46, 0, "Gain 6 coins");
            theDeck[18] = new Card("White", "Hypatia", "", 4, 0, 18, "1p per green card built");
            theDeck[19] = new Card("White", "Nebuchadnezzar", "", 4, 0, 19, "1p per blue card built");
            theDeck[20] = new Card("White", "Phidias", "", 3, 0, 20, "1p per brown card built");
            theDeck[21] = new Card("White", "Varro", "", 3, 0, 21, "1p per yellow card built");
            theDeck[22] = new Card("White", "Pericles", "", 6, 0, 22, "2p per red card built");
            theDeck[23] = new Card("White", "Praxiteles", "", 3, 0, 23, "2p per gray card built");
            theDeck[24] = new Card("White", "Hiram", "", 3, 0, 24, "2p per purple card built");
            theDeck[25] = new Card("White", "Sappho", "", 1, 0, 2, "Worth 2p");
            theDeck[26] = new Card("White", "Zenobia", "", 2, 0, 3, "Worth 3p");
            theDeck[27] = new Card("White", "Nefertiti", "", 3, 0, 4, "Worth 4p");
            theDeck[28] = new Card("White", "Cleopatra", "", 4, 0, 5, "Worth 5p");
            theDeck[29] = new Card("White", "Archimedes", "", 4, 47, 0, "Gives a discount of 1 resource (not coins), when constructing green buildings");
            theDeck[30] = new Card("White", "Leonidas", "", 2, 48, 0, "Gives a discount of 1 resource (not coins), when constructing red buildings");
            theDeck[31] = new Card("White", "Hammurabi", "", 2, 49, 0, "Gives a discount of 1 resource (not coins), when constructing blue buildings");
            theDeck[32] = new Card("White", "Imhotep", "", 3, 50, 0, "Gives a discount of 1 resource (not coins), when constructing wonder stages");
            theDeck[33] = new Card("White", "Euclid", "", 5, 0, 25, 1, "Counts as a compass symbol for scientific scoring");
            theDeck[34] = new Card("White", "Ptolemy", "", 5, 0, 26, 3, "Counts as a tablet symbol for scientific scoring");
            theDeck[35] = new Card("White", "Pythagoras", "", 5, 0, 27, 2, "Counts as a gear symbol for scientific scoring");

            if(version == 2)
            {
                theDeck[36] = new Card("White", "Berenice", "", 2, 51, 0, "Once per turn, increase the amount of coins from the bank by 1");
                theDeck[37] = new Card("White", "Darius", "", 4, 0, 28, "1p per black card");
                theDeck[38] = new Card("White", "Aspasia", "", 3, 52, 2, "Worth 2p and gain a diplomacy token");
                theDeck[39] = new Card("White", "Caligula", "", 3, 53, 0, "Once per age, construct a black building for free");
                theDeck[40] = new Card("White", "Semiramis", "", 5, 54, 0, "Each defeat token gained from here on counts as a shield");
                theDeck[41] = new Card("White", "Diocletian", "", 2, 55, 0, "Gain 2 coins when you construct a black building");
            }
            Shuffle(theDeck);
        }

        public void Shuffle(Card[] aDeck)
        {
            Random r = new Random();
            int r1; int r2;
            int size = aDeck.Length;
            Card temp;

            for (int i = 0; i < size; i++)
            {
                r1 = r.Next(0, size); r2 = r.Next(0, size);
                temp = aDeck[r1];
                aDeck[r1] = aDeck[r2];
                aDeck[r2] = temp;
            }
        }
    }
}
