using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{    
    public class Card
    {
        public string color;
        public string name;
        public string preReq;
        public int[] cost = new int[8];
        public int effect;
        public int scoring;
        public string description;
        public int symbol;

        public Card()
        {
            color = "";
            name = "";
            preReq = "";
            cost = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            effect = 0;
            scoring = 0;
            description = "";
            symbol = 0;
        }
        public Card(string c, string n, string p, int[] ct, int e, int s)
        {
            color = c;
            name = n;
            preReq = p;
            cost = ct;
            effect = e;
            scoring = s;
            description = "";
            symbol = 0;
        }
        public Card(string c, string n, string p, int ct, int e, int s)
        {
            color = c;
            name = n;
            preReq = p;
            cost = new int[] { ct, 0, 0, 0, 0, 0, 0, 0 };
            effect = e;
            scoring = s;
            description = "";
            symbol = 0;
        }
        public Card(string c, string n, string p, int[] ct, int e, int s, string d)
        {
            color = c;
            name = n;
            preReq = p;
            cost = ct;
            effect = e;
            scoring = s;
            description = d;
            symbol = 0;
        }
        public Card(string c, string n, string p, int ct, int e, int s, string d)
        {
            color = c;
            name = n;
            preReq = p;
            cost = new int[] { ct, 0, 0, 0, 0, 0, 0, 0 };
            effect = e;
            scoring = s;
            description = d;
            symbol = 0;
        }
        public Card(string c, string n, string p, int[] ct, int e, int s, int sy, string d)
        {
            color = c;
            name = n;
            preReq = p;
            cost = ct;
            effect = e;
            scoring = s;
            description = d;
            symbol = sy;
        }
        public Card(string c, string n, string p, int ct, int e, int s, int sy, string d)
        {
            color = c;
            name = n;
            preReq = p;
            cost = new int[] { ct, 0, 0, 0, 0, 0, 0, 0 };
            effect = e;
            scoring = s;
            description = d;
            symbol = sy;
        }

    }
}
