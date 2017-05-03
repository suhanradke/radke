using System.ComponentModel.DataAnnotations;

namespace OppositeEnds.Models
{
    public class Cart
    {
        [Key]
        public int ItemId { get; set; } 

        public string CartId { get; set; }

        public int Count { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int FloralId { get; set; }

        public int FurnitureId { get; set; }


        public virtual Floral Floral { get; set; }

        public virtual Furniture Furniture { get; set; }
    }
}