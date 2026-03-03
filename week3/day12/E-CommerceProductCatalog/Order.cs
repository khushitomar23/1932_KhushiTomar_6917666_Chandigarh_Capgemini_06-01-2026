using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceProductCatalog
{
    internal class Order
    {
        Customer customer;
        Cart cart;

        public Order(Customer c, Cart cart)
        {
            customer = c;
            this.cart = cart;
        }

        public void ShowOrder()
        {
            customer.DisplayCustomer();
            Console.WriteLine("Total Bill: " + cart.GetTotal());
        }
    }
}
