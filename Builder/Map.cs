using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Map
    {
        public Intersection Intersection { get; set; }
        public Branch Branch{ get; set; }
    }

    public class Branch
    {
    }

    public class Intersection
    {
    }
}
