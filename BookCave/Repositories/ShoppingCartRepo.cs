using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BookCave.Repositories
{
    public class ShoppingCartRepo
    {
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
/*
        public static ShoppingCart GetCart(HttpContext context)
        {
            
        }
*/
    }
}