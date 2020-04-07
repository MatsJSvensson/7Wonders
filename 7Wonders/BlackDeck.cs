using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{
    class BlackDeck
    {
        public Card[] theDeck;

        public BlackDeck(int age)
        {
            theDeck = new Card[9];

            switch(age)
            {
                case 1:
                    theDeck[0] = new Card("Black", "Pigeon Loft", "", new int[] { 1, 0, 1, 0, 0, 0, 0, 0 }, 0, 29, "Copy a scientific symbol from a neighbouring city");
                    theDeck[1] = new Card("Black", "Militia", "", 3, 56, 0, "2 Shields");
                    theDeck[2] = new Card("Black", "Hideout", "", 0, 57, 2, "2p and everyone else losses 1 Coin");
                    theDeck[3] = new Card("Black", "Residence", "", new int[] { 0, 1, 0, 0, 0, 0, 0, 0 }, 58, 1, "1p and gain a diplomacy token");
                    theDeck[4] = new Card("Black", "Gambling Den", "", 0, 59, 0, "You gain 6 Coins and your neighbours gain 1 each");
                    theDeck[5] = new Card("Black", "Clandestine Dock E", "", 1, 60, 0, "Once each turn, a resource from your eastern neighbour costs 1 Coin less");
                    theDeck[6] = new Card("Black", "Clandestine Dock W", "", 1, 61, 0, "Once each turn, a resource from your western neighbour costs 1 Coin less");
                    theDeck[7] = new Card("Black", "Secret Warehouse", "", 2, 62, 0, "Produces a resource that a brown or grey card in your city or your initial resource allready produces");
                    theDeck[8] = new Card("Black", "City Gates", "", new int[] { 1, 0, 0, 0, 1, 0, 0, 0 }, 0, 4, "4p");
                    break;

                case 2:
                    theDeck[0] = new Card("Black", "Spyring", "", new int[] { 2, 1, 0, 1, 0, 0, 0, 0 }, 0, 30, "Copy a scientific symbol from a neighbouring city");
                    theDeck[1] = new Card("Black", "Mercenaries", "", new int[] { 4, 0, 0, 0, 0, 0, 1, 0 }, 63, 0, "3 Shields");
                    theDeck[2] = new Card("Black", "Lair", "", new int[] { 0, 0, 0, 0, 1, 1, 0, 0 }, 64, 3, "3p and everyone else looses 2 Coins");
                    theDeck[3] = new Card("Black", "Consulate", "", new int[] { 0, 1, 0, 0, 0, 0, 1, 0 }, 65, 2, "2p and you gain a diplomacy token");
                    theDeck[4] = new Card("Black", "Gambling House", "", 1, 66, 0, "You gain 9 Coins and your neighbours gain 2 each");
                    theDeck[5] = new Card("Black", "Black Market", "", new int[] { 0, 0, 1, 0, 0, 0, 0, 1 }, 67, 0, "Produces a resource that your grey, brown and initial resources does not");
                    theDeck[6] = new Card("Black", "Sepulcher", "", new int[] { 0, 0, 0, 1, 0, 1, 0, 1 }, 68, 4, "4p and everyone else losses 1 Coin per victory token");
                    theDeck[7] = new Card("Black", "Architect Cabinet", "", new int[] { 1, 0, 0, 0, 0, 0, 1, 0 }, 69, 2, "2p and your wonder stages are henceforth free (except Coin costs)");
                    theDeck[8] = new Card("Black", "Tabularium", "", new int[] { 2, 0, 1, 0, 1, 0, 0, 1 }, 0, 6, "6p");
                    break;
                case 3:
                    theDeck[0] = new Card("Black", "Torture Chamber", "", new int[] { 3, 0, 2, 0, 0, 1, 0, 0 }, 0, 31, "Copy a scientific symbol from a neighbouring city");
                    theDeck[1] = new Card("Black", "Contingent", "", new int[] { 5, 0, 0, 0, 0, 0, 0, 1 }, 70, 0, "5 Shields");
                    theDeck[2] = new Card("Black", "Brotherhood", "", new int[] { 0, 0, 1, 0, 2, 0, 0, 1 }, 71, 4, "4p and everyone else looses 3 Coins");
                    theDeck[3] = new Card("Black", "Embassy", "", new int[] { 0, 0, 0, 1, 0, 0, 1, 1 }, 72, 3, "3p and you gain a diplomacy token");
                    theDeck[4] = new Card("Black", "Cenotaph", "", new int[] { 0, 2, 0, 1, 0, 1, 0, 1 }, 73, 5, "5p and everyone else looses 1 Coin per victory token");
                    theDeck[5] = new Card("Black", "Builder's Union", "", new int[] { 0, 1, 0, 0, 1, 1, 1, 0 }, 74, 4, "4p and everyone else looses 1 Coin per completed wonder stage");
                    theDeck[6] = new Card("Black", "Capitol", "", new int[] { 2, 2, 0, 2, 0, 1, 1, 0 }, 0, 8, "8p");
                    theDeck[7] = new Card("Black", "Slave Market", "", new int[] { 0, 0, 2, 0, 2, 0, 0, 0 }, 75, 32, "1p and 1 Coin for each victory token");
                    theDeck[8] = new Card("Black", "Illegal Network", "", new int[] { 0, 0, 0, 1, 0, 0, 1, 0 }, 76, 33, "1p and 1 Coin for each black card in your city");
                    break;
            }
        }
    }
}
