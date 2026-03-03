using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceProductCatalog
{
    internal class Electronics:Product
    {
        public Electronics(int id, string name, int price, int stock)
           : base(id, name, price, stock) { }
    }
}
