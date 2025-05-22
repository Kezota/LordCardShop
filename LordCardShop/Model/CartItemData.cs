using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Model
{
    public class CartItemData
    {
        public int CartID { get; set; }
        public int CardID { get; set; }
        public string CardName { get; set; }
        public double CardPrice { get; set; }
        public string CardType { get; set; }
        public int Quantity { get; set; }
    }

}