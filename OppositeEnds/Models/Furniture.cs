using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OppositeEnds.Models
{
    public class Furniture
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
        
        public string Category { get; set; }

        public string Picture { get; set; }

    }
}