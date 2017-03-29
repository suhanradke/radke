using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OppositeEnds.Models
{
    public class Furniture
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Cannot be negative")]
        public double Price { get; set; }

        public int Quantity { get; set; }
        
        public string Category { get; set; }

        public string Picture { get; set; }

<<<<<<< HEAD
        public static implicit operator Furniture(List<Furniture> v)
        {
            throw new NotImplementedException();
        }
=======
        public string Details { get; set; }

>>>>>>> b87dd92c48a5880e869d0e519a63421f37211778
    }
}