namespace OppositeEnds.Models
{
    public class ShoppingCartDetail
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Type  { get; set; }

        public int Quantity { get; set; }

        public double Total
        {
            get
            {
                return Quantity * Price;
            }
        }

        public double GrandTotal
        {
            get
            {
                double grandTotal = 0;
                grandTotal += Total;
                return grandTotal;
            }
        }

        public int RemainingItem
        {
            get;set;
        }
    }
}