using System.ComponentModel.DataAnnotations;

namespace OppositeEnds.Models
{
    public class Floral
    {
        [Key]
        public int FloralId { get; set; }

        
        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Cannot be negative")]
        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Category { get; set; }

        public string Picture { get; set; }


        public string Details { get; set; }
        

       }
}