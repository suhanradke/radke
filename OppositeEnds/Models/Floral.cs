using System.ComponentModel.DataAnnotations;

namespace OppositeEnds.Models
{
    public class Floral
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Category { get; set; }

        public string Picture { get; set; }

    }
}