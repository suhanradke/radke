﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OppositeEnds.Models
{
    public class Floral
    {
        [Key]
        public int Id { get; set; }

        
        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Cannot be negative")]
        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Category { get; set; }

        public string Picture { get; set; }

<<<<<<< HEAD
        public static implicit operator Floral(List<Floral> v)
        {
            throw new NotImplementedException();
        }
=======
        public string Details { get; set; }

        //public byte[] ImageData { get; set; }

        //public string ImageMimeType { get; set; }

>>>>>>> b87dd92c48a5880e869d0e519a63421f37211778
    }
}