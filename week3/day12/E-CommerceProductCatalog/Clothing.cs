using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceProductCatalog
{
    internal class Clothing:Product
    {
        public Clothing(int id, string name, int price, int stock)
            : base(id, name, price, stock) { }
    }
}
