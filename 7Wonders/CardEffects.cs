using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{
    public static class CardEffects
    {

        public static void effects(int effect, Player thePlayer, GameMaster theMaster)
        {
            int filled;
            int p;
            int np = theMaster.nPlayers;
            int sum;
            Card[] tempArray;

            switch (effect)
            {
                case 1: //Lumber Yard
                    thePlayer.resources[4]++;
                    break;
                case 2: //Clay Pool
                    thePlayer.resources[1]++;
                    break;
                case 3: //Stone Pit
                    thePlayer.resources[3]++;
                    break;
                case 4: //Ore Vein
                    thePlayer.resources[2]++;
                    break;
                case 5: //Clay Pit
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Clay Pit", new int[] { 1, 1, 0, 0, 0, 0, 0 }, "", true);
                    break;
                case 6: //Timber Yard
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Timber Yard", new int[] { 0, 0, 1, 1, 0, 0, 0 }, "", true);
                    break;
                case 7: //Loom
                    thePlayer.resources[7]++;
                    break;
                case 8: //Glassworks
                    thePlayer.resources[5]++;
                    break;
                case 9: //Press
                    thePlayer.resources[6]++;
                    break;
                case 10: //West Trading Post
                    thePlayer.basicDiscountWest = 1;
                    break;
                case 11: //East Trading Post
                    thePlayer.basicDiscountEast = 1;
                    break;
                case 12: //Marketplace
                    thePlayer.luxuryDiscount = 1;
                    break;
                case 13: //Military age1
                    thePlayer.militaryStrength++;
                    break;
                case 14: //Excavation
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Excavation", new int[] { 1, 0, 1, 0, 0, 0, 0 }, "", true);
                    break;
                case 15: //Tavern
                    thePlayer.resources[0] += 5;
                    break;
                case 16: //Forest Cave
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Forest Cave", new int[] { 0, 1, 0, 1, 0, 0, 0 }, "", true);
                    break;
                case 17: //Tree Farm
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Tree Farm", new int[] { 1, 0, 0, 1, 0, 0, 0 }, "", true);
                    break;
                case 18: //Mine
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Mine", new int[] { 0, 1, 1, 0, 0, 0, 0 }, "", true);
                    break;
                case 19: //Sawmill
                    thePlayer.resources[4] += 2;
                    break;
                case 20: //Brickyard
                    thePlayer.resources[1] += 2;
                    break;
                case 21: //Quarry
                    thePlayer.resources[3] += 2;
                    break;
                case 22: //Foundry
                    thePlayer.resources[2] += 2;
                    break;
                case 23: //Forum
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Forum", new int[] { 0, 0, 0, 0, 1, 1, 1 }, "");
                    break;
                case 24: //Caravansery
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Caravansery", new int[] { 1, 1, 1, 1, 0, 0, 0 }, "");
                    break;
                case 25: //Vineyard
                    sum = 0;

                    p = (thePlayer.position + np - 1) % np;
                    sum += theMaster.Players[p].nColors[5];
                    p = (thePlayer.position + 1) % np;
                    sum += theMaster.Players[p].nColors[5];
                    sum += thePlayer.nColors[5];

                    thePlayer.resources[0] += sum;
                    break;
                case 26: //Military age2
                    thePlayer.militaryStrength += 2;
                    break;
                case 27: //Bazar                    
                    sum = 0;

                    p = (thePlayer.position + np - 1) % np;
                    sum += theMaster.Players[p].nColors[3];
                    p = (thePlayer.position + 1) % np;
                    sum += theMaster.Players[p].nColors[3];
                    sum += thePlayer.nColors[3];

                    thePlayer.resources[0] += sum *2;
                    break;
                case 28: //Haven
                    thePlayer.resources[0] += thePlayer.nColors[2];
                    break;
                case 29: //Lighthouse
                    thePlayer.resources[0] += thePlayer.nColors[5];
                    break;
                case 30: //Arena
                    thePlayer.resources[0] += 3 * thePlayer.nColors[8];
                    break;
                case 31: //Military age3
                    thePlayer.militaryStrength += 3;
                    break;
                case 32: //Chamber of Commerce
                    thePlayer.resources[0] += 2 * thePlayer.nColors[3];
                    break;
                case 33: //Aristotle
                    thePlayer.scienceSetScore = 10;
                    break;
                case 34: //Midas REMOVED!
                    break;
                case 35: //Bilkis
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Bilkis", new int[] { 1, 1, 1, 1, 1, 1, 1 }, "");
                    break;
                case 36: //Maecenas
                    thePlayer.leaderDiscount = 6;
                    break;
                case 37: //Ramses
                    thePlayer.haveLeader[0] = true;
                    break;
                case 38: //Tomyris
                    thePlayer.haveLeader[1] = true;
                    break;
                case 39: //Hannibal
                    thePlayer.militaryStrength++;
                    break;
                case 40: //Caesar
                    thePlayer.militaryStrength += 2;
                    break;
                case 41: //Hatshepsut
                    thePlayer.haveLeader[2] = true;
                    break;
                case 42: //Nero
                    thePlayer.haveLeader[3] = true;
                    break;
                case 43: //Xenophon
                    thePlayer.haveLeader[4] = true;
                    break;
                case 44: //Vitruvius
                    thePlayer.haveLeader[5] = true;
                    break;
                case 45: //Solomon
                    thePlayer.decisions[4]++;
                    break;
                case 46: //Croesus
                    thePlayer.resources[0] += 6;
                    break;
                case 47: //Archimedes
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Archimedes", new int[] { 1, 1, 1, 1, 1, 1, 1 }, "Green");
                    break;
                case 48: //Leonidas
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Leonidas", new int[] { 1, 1, 1, 1, 1, 1, 1 }, "Red");
                    break;
                case 49: //Hammurabi
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Hammurabi", new int[] { 1, 1, 1, 1, 1, 1, 1 }, "Blue");
                    break;
                case 50: //Imhotep
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Imhotep", new int[] { 1, 1, 1, 1, 1, 1, 1 }, "Wondrous");
                    break;
                case 51: //Berenice
                    thePlayer.haveLeader[6] = true;
                    break;
                case 52: //Aspasia
                    thePlayer.diplomacy++;
                    break;
                case 53: //Caligula
                    thePlayer.haveLeader[7] = true;
                    break;
                case 54: //Semiramis
                    thePlayer.haveLeader[9] = true;
                    break;
                case 55: //Diocletian
                    thePlayer.haveLeader[10] = true;
                    break;
                case 56: //Militia
                    thePlayer.militaryStrength += 2;
                    break;
                case 57: //HideOut
                    for (int i = 0; i < np; i++ )
                    {
                        if(i != thePlayer.position)
                        {
                            theMaster.Players[i].imminentLoss++;
                        }
                    }
                    break;
                case 58: //Residence
                    goto case 52;
                case 59: //Gambling den
                    thePlayer.imminentLoss -= 6;
                    p = (thePlayer.position + np - 1) % np;
                    theMaster.Players[p].imminentLoss--;
                    p = (thePlayer.position + 1) % np;
                    theMaster.Players[p].imminentLoss--;
                    break;
                case 60: //Clandestine dock east
                    thePlayer.haveLeader[13] = true;
                    break;
                case 61: //Clandestine dock west
                    thePlayer.haveLeader[11] = true;
                    break;
                case 62: //Secret warehouse
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Secret Warehouse", new int[] { 0, 0, 0, 0, 0, 0, 0 }, "");
                    break;
                case 63: //Mercenaries
                    thePlayer.militaryStrength += 3;
                    break;
                case 64: //Lair
                    for (int i = 0; i < np; i++ )
                    {
                        if(i != thePlayer.position)
                        {
                            theMaster.Players[i].imminentLoss += 2;
                        }
                    }
                    break;
                case 65: //Consulate
                    goto case 52;
                case 66: //Gambling House
                    thePlayer.imminentLoss -= 9;
                    p = (thePlayer.position + np - 1) % np;
                    theMaster.Players[p].imminentLoss -= 2;
                    p = (thePlayer.position + 1) % np;
                    theMaster.Players[p].imminentLoss -= 2;
                    break;
                case 67: //Black Market
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Black Market", new int[] { 0, 0, 0, 0, 0, 0, 0 }, "");
                    break;
                case 68: //Sepulcher
                    for (int i = 0; i < np; i++)
                    {
                        if (i != thePlayer.position)
                        {
                            theMaster.Players[i].imminentLoss += theMaster.Players[i].wins;
                        }
                    }
                    break;
                case 69: //Architect cabinet
                    thePlayer.haveLeader[15] = true;
                    break;
                case 70: //Contingent
                    thePlayer.militaryStrength += 5;
                    break;
                case 71: //Brotherhood
                    for (int i = 0; i < np; i++ )
                    {
                        if(i != thePlayer.position)
                        {
                            theMaster.Players[i].imminentLoss += 3;
                        }
                    }
                    break;
                case 72: //Embassy
                    goto case 52;
                case 73: //Cenotaph
                    for (int i = 0; i < np; i++)
                    {
                        if (i != thePlayer.position)
                        {
                            theMaster.Players[i].imminentLoss += theMaster.Players[i].wins;
                        }
                    }
                    break;
                case 74: //Builders Union
                    sum = 0;
                    for (int i = 0; i < np; i++)
                    {
                        if (i != thePlayer.position)
                        {
                            theMaster.Players[i].imminentLoss += theMaster.Players[i].nColors[8];
                        }
                    }
                    break;
                case 75: //Slave Market
                    thePlayer.resources[0] += thePlayer.wins;
                    break;
                case 76: //Illegal Network
                    filled = thePlayer.builtCards.Count(x => x != null);
                    tempArray = new Card[filled];
                    Array.Copy(thePlayer.builtCards, tempArray, filled);
                    thePlayer.resources[0] += tempArray.Count(x => x.color == "Black");
                    break;
                case 77: //Courtesans Guild
                    //thePlayer.decisions[2]++;
                    break;
                case 78: //Counterfeiters Guild
                    for (int i = 0; i < np; i++)
                    {
                        if (i != thePlayer.position)
                        {
                            theMaster.Players[i].imminentLoss += 3;
                        }
                    }
                    break;
                case 79: //Babylon
                    thePlayer.babylon = true;
                    break;
                case 80: //Alexandria Stage1
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Wonder Stage 1", new int[] { 1, 1, 1, 1, 0, 0, 0 }, "");
                    break;
                case 81: //Alexandria Stage2
                    filled = thePlayer.specials.Count(x => x != null);
                    thePlayer.specials[filled] = new SpecialResource("Wonder Stage 2", new int[] { 0, 0, 0, 0, 1, 1, 1 }, "");
                    break;
                case 82: //Olympus
                    thePlayer.basicDiscountEast = 1;
                    thePlayer.basicDiscountWest = 1;
                    break;
                case 83: //Halikarnassos
                    thePlayer.decisions[4]++;
                    break;
                case 84: //Ephesos
                    thePlayer.resources[0] += 4;
                    break;
                case 85: //Rhodos stage1
                    thePlayer.militaryStrength++;
                    thePlayer.resources[0] += 3;
                    break;
                case 86: //Rhodos stage2
                    thePlayer.militaryStrength++;
                    thePlayer.resources[0] += 4;
                    break;
                case 87: //Rome stage1
                    thePlayer.resources[0] += 5;
                    theMaster.dealRome(thePlayer.position);
                    break;
                case 88: //Rome stage23
                    thePlayer.rome = true;
                    break;
                case 89: //Petra
                    for (int i = 0; i < np; i++)
                    {
                        if (i != thePlayer.position)
                        {
                            theMaster.Players[i].imminentLoss += 2;
                        }
                    }
                    break;
                case 90: //Byzantium
                    goto case 52;
            }
        }

        public static void scoreEffects(int effect, Player thePlayer, GameMaster theMaster, Card aCard)
        {
            int min;
            int np = theMaster.nPlayers;
            int p;
            int si = 3;

            switch(aCard.color)
            {
                case "White": si = 7; break;
                case "Black": si = 8; break;
                case "Yellow": si = 4; break;
                case "Blue": si = 3; break;
                case "Wondrous": si = 2; break;
                case "Purple": si = 6; break;
            }

            switch(effect)
            {
                case 1:
                    thePlayer.totalScore[si]++;
                    break;
                case 2:
                    thePlayer.totalScore[si] += 2;
                    break;
                case 3:
                    thePlayer.totalScore[si] += 3;
                    break;
                case 4:
                    thePlayer.totalScore[si] += 4;
                    break;
                case 5:
                    thePlayer.totalScore[si] += 5;
                    break;
                case 6:
                    thePlayer.totalScore[si] += 6;
                    break;
                case 7:
                    thePlayer.totalScore[si] += 7;
                    break;
                case 8:
                    thePlayer.totalScore[si] += 8;
                    break;
                case 9: //Haven
                    thePlayer.totalScore[si] += thePlayer.nColors[2];
                    break;
                case 10: //Scientific cards
                    thePlayer.sciences[aCard.symbol - 1]++;
                    break;
                case 11: //Lighthouse
                    thePlayer.totalScore[si] += thePlayer.nColors[5];
                    break;
                case 12: //Arena
                    thePlayer.totalScore[si] += thePlayer.nColors[8];
                    break;
                case 13: //Chamber of Commerce
                    thePlayer.totalScore[si] += 2 * thePlayer.nColors[3];
                    break;
                case 14: //Amytis
                    thePlayer.totalScore[si] += 2 * thePlayer.nColors[8];
                    break;
                case 15: //Alexander
                    thePlayer.totalScore[si] += thePlayer.wins;
                    break;
                case 16: //Justinian
                    min = 10;
                    if (min > thePlayer.nColors[4]) { min = thePlayer.nColors[4]; }
                    if (min > thePlayer.nColors[6]) { min = thePlayer.nColors[6]; }
                    if (min > thePlayer.nColors[7]) { min = thePlayer.nColors[7]; }
                    thePlayer.totalScore[si] += 3 * min;
                    break;
                case 17: //Plato
                    min = 3;
                    if (min > thePlayer.nColors[2]) { min = thePlayer.nColors[2]; }
                    if (min > thePlayer.nColors[3]) { min = thePlayer.nColors[3]; }
                    if (min > thePlayer.nColors[4]) { min = thePlayer.nColors[4]; }
                    if (min > thePlayer.nColors[5]) { min = thePlayer.nColors[5]; }
                    if (min > thePlayer.nColors[6]) { min = thePlayer.nColors[6]; }
                    if (min > thePlayer.nColors[7]) { min = thePlayer.nColors[7]; }
                    if (min > thePlayer.nColors[9]) { min = thePlayer.nColors[9]; }
                    thePlayer.totalScore[si] += 7 * min;
                    break;
                case 18: //Hypatia
                    thePlayer.totalScore[si] += thePlayer.nColors[4];
                    break;
                case 19: //Nebuchadnezzar
                    thePlayer.totalScore[si] += thePlayer.nColors[7];
                    break;
                case 20: //Phidias
                    thePlayer.totalScore[si] += thePlayer.nColors[2];
                    break;
                case 21: //Varro
                    thePlayer.totalScore[si] += thePlayer.nColors[5];
                    break;
                case 22: //Pericles
                    thePlayer.totalScore[si] += 2 * thePlayer.nColors[6];
                    break;
                case 23: //Praxiteles
                    thePlayer.totalScore[si] += 2 * thePlayer.nColors[3];
                    break;
                case 24: //Hiram
                    thePlayer.totalScore[si] += 2 * thePlayer.nColors[9];
                    break;
                case 25: //Ptolemy and his friends
                    goto case 10;
                case 26:
                    goto case 10;
                case 27:
                    goto case 10;
                case 28: //Darius
                    thePlayer.totalScore[si] += thePlayer.nColors[1];
                    break;
                case 29: //Pigeon Loft
                    thePlayer.decisions[1]++;
                    break;
                case 30: //Spyring
                    goto case 29;
                case 31: //Torture Chamber
                    goto case 29;
                case 32: //Slave Market
                    thePlayer.totalScore[si] += thePlayer.wins;
                    break;
                case 33: //Illegal Network
                    thePlayer.totalScore[si] += thePlayer.nColors[1];
                    break;
                case 34: //Workers Guild
                    p = (thePlayer.position + np - 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[2];
                    p = (thePlayer.position + 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[2];
                    break;
                case 35: //Craftmens Guild
                    p = (thePlayer.position + np - 1) % np;
                    thePlayer.totalScore[si] += 2 * theMaster.Players[p].nColors[3];
                    p = (thePlayer.position + 1) % np;
                    thePlayer.totalScore[si] += 2 * theMaster.Players[p].nColors[3];
                    break;
                case 36: //Traders Guild
                    p = (thePlayer.position + np - 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[5];
                    p = (thePlayer.position + 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[5];
                    break;
                case 37: //Philodophers Guild
                    p = (thePlayer.position + np - 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[4];
                    p = (thePlayer.position + 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[4];
                    break;
                case 38: //Spies Guild
                    p = (thePlayer.position + np - 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[6];
                    p = (thePlayer.position + 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[6];
                    break;
                case 39: //Strategists Guild
                    p = (thePlayer.position + np - 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].losses;
                    p = (thePlayer.position + 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].losses;
                    break;
                case 40: //Shipowners Guild
                    thePlayer.totalScore[si] += thePlayer.nColors[2];
                    thePlayer.totalScore[si] += thePlayer.nColors[3];
                    thePlayer.totalScore[si] += thePlayer.nColors[9];
                    break;
                case 41: //Scientists Guild + Babylon
                    thePlayer.decisions[3]++;
                    break;
                case 42: //Magistrates Guild
                    p = (thePlayer.position + np - 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[7];
                    p = (thePlayer.position + 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[7];
                    break;
                case 43: //Builders Guild
                    p = (thePlayer.position + np - 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[8];
                    p = (thePlayer.position + 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[8];
                    thePlayer.totalScore[si] += thePlayer.nColors[8];
                    break;
                case 44: //Gamers Guild & Midas
                    thePlayer.totalScore[si] += thePlayer.resources[0] / 3;
                    break;
                case 45: //Courtesans Guild
                    thePlayer.decisions[2]++;
                    break;
                case 46: //Diplomats Guild
                    p = (thePlayer.position + np - 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[0];
                    p = (thePlayer.position + 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[0];
                    break;
                case 47: //Architects Guild
                    p = (thePlayer.position + np - 1) % np;
                    thePlayer.totalScore[si] += 3 * theMaster.Players[p].nColors[9];
                    p = (thePlayer.position + 1) % np;
                    thePlayer.totalScore[si] += 3 * theMaster.Players[p].nColors[9];
                    break;
                case 48: //Guild of Shadows
                    p = (thePlayer.position + np - 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[1];
                    p = (thePlayer.position + 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].nColors[1];
                    break;
                case 49: //Mourners Guild
                    p = (thePlayer.position + np - 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].wins;
                    p = (thePlayer.position + 1) % np;
                    thePlayer.totalScore[si] += theMaster.Players[p].wins;
                    break;
                case 50: //Olympus
                    thePlayer.decisions[0]++;
                    break;
                case 51: //Petra
                    thePlayer.totalScore[si] += 14;
                    break;
            }
        }
    }
}