﻿namespace OppositeEnds.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int FloralId { get; set; }
        public int Furnitured { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Floral Floral { get; set; }
        public virtual Furniture furniture { get; set; }
        public virtual Order Order { get; set; }
    }
}