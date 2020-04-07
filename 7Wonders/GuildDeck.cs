using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{
    class GuildDeck
    {
         public Card[] theDeck;

        public GuildDeck(int version)
        {
            int versionBonus = 0;
            if (version == 1) { versionBonus += 4; }
            if (version == 2) { versionBonus += 7; }

            theDeck = new Card[10 + versionBonus];

            theDeck[0] = new Card("Purple", "Worker's Guild", "", new int[] { 0, 1, 2, 1, 1, 0, 0, 0 } , 0, 34, "1p per brown card in your neighbours cities");
            theDeck[1] = new Card("Purple", "Craftmen's Guild", "", new int[] { 0, 0, 2, 2, 0, 0, 0, 0 }, 0, 35, "2p per grey card in your neighbours cities");
            theDeck[2] = new Card("Purple", "Trader's Guild", "", new int[] { 0, 0, 0, 0, 0, 1, 1, 1 }, 0, 36, "1p per yellow card in your neighbours cities");
            theDeck[3] = new Card("Purple", "Philosopher's Guild", "", new int[] { 0, 3, 0, 0, 0, 0, 1, 1 }, 0, 37, "1p per green card in your neighbours cities");
            theDeck[4] = new Card("Purple", "Spies' Guild", "", new int[] { 0, 3, 0, 0, 0, 1, 0, 0 }, 0, 38, "1p per red card in your neighbours cities");
            theDeck[5] = new Card("Purple", "Strategist's Guild", "", new int[] { 0, 0, 2, 1, 0, 0, 0, 1 }, 0, 39, "1p per defeat token in your neighbours cities");
            theDeck[6] = new Card("Purple", "Shipowner's Guild", "", new int[] { 0, 0, 0, 0, 3, 1, 1, 0 }, 0, 40, "1p per brown, grey and purple card in your city");
            theDeck[7] = new Card("Purple", "Scientist's Guild", "", new int[] { 0, 0, 2, 0, 2, 0, 1, 0 }, 0, 41, "Counts as a scientific symbol of your choice");
            theDeck[8] = new Card("Purple", "Magistrate's Guild", "", new int[] { 0, 0, 0, 1, 3, 0, 0, 1 }, 0, 42, "1p per blue card in your neighbours cities");
            theDeck[9] = new Card("Purple", "Builder's Guild", "", new int[] { 0, 2, 0, 2, 0, 1, 0, 0 }, 0, 43, "1p per completed wonder stage in your and your neighbours cities");

            if(version >= 1)
            {
                theDeck[10] = new Card("Purple", "Gamer's Guild", "", new int[] { 0, 1, 1, 1, 1, 0, 0, 0 }, 0, 44, "1p per 3 Coins rounded down");
                theDeck[11] = new Card("Purple", "Courtesan's Guild", "", new int[] { 0, 1, 0, 0, 1, 1, 0, 1 }, 77, 45, "Immediately copy a leader in a neighbouring city");
                theDeck[12] = new Card("Purple", "Diplomat's Guild", "", new int[] { 0, 0, 0, 1, 1, 1, 1, 0 }, 0, 46, "1p per white (leader) card in your neighbours cities");
                theDeck[13] = new Card("Purple", "Architect's Guild", "", new int[] { 0, 1, 3, 0, 0, 0, 1, 1 }, 0, 47, "3p per purple (guild) card in your neighbours cities");
            }

            if(version >= 2)
            {
                theDeck[14] = new Card("Purple", "Counterfeiter's Guild", "", new int[] { 0, 0, 3, 0, 0, 1, 0, 1 }, 78, 5, "5p and everyone else looses 3 Coins");
                theDeck[15] = new Card("Purple", "Guild of Shadows", "", new int[] { 0, 0, 0, 2, 1, 0, 1, 0 }, 0, 48, "1p per black card in your neighbours cities");
                theDeck[16] = new Card("Purple", "Mourner's Guild", "", new int[] { 0, 2, 0, 0, 1, 1, 0, 1 }, 0, 49, "1p per victory token in your neighbours cities");
            }
        }
    }
}
