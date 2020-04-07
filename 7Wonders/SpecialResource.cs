using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{
    public class SpecialResource
    {
        public string name;
        public int[] resources;
        public string condition;
        public bool tradable;

        public SpecialResource(string n, int[] r, string c)
        {
            name = n;
            resources = r;
            condition = c;
            tradable = false;
        }
        public SpecialResource(string n, int[] r, string c, bool t)
        {
            name = n;
            resources = r;
            condition = c;
            tradable = t;
        }
    }
}
