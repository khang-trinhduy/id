using System;
namespace Contact.Class.Shops
{
    public class Shophouse : Shop
    {
        public Shophouse(string name, double price, double area)
        {
            this.Name = name;
            this.Price = price;
            this.Area = area;
        }

        public override void SetPrice(double price)
        {
            throw new NotImplementedException();
        }

        public override void SetArea(double area)
        {
            throw new NotImplementedException();
        }

        public override void SetName(string name)
        {
            throw new NotImplementedException();
        }

        public override void SetType(string type)
        {
            throw new NotImplementedException();
        }
    }
}