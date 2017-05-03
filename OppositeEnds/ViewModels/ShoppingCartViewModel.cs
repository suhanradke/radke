using OppositeEnds.Models;
using System.Collections.Generic;

namespace OppositeEnds.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}