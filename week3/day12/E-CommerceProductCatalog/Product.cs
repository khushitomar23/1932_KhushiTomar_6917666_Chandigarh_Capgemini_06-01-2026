using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceProductCatalog
{
    internal class Product
    {
        protected int id;
        protected string name;
        protected int price;
        protected int stock;

        public Product(int id, string name, int price, int stock)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.stock = stock;
        }

        public virtual void Display()
        {
            Console.WriteLine("ID    : " + id);
            Console.WriteLine("Name  : " + name);
            Console.WriteLine("Price : " + price);
            Console.WriteLine("Stock : " + stock);
        }

        public void ReduceStock(int qty)
        {
            stock = stock - qty;
        }

        public int GetPrice()
        {
            return price;
        }
    }
}
