using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceProductCatalog
{
    internal class Cart
    {
        Product product;
        int quantity;

        public Cart(Product p, int q)
        {
            product = p;
            quantity = q;
            product.ReduceStock(q);
        }

        public int GetTotal()
        {
            return product.GetPrice() * quantity;
        }
    }
}
