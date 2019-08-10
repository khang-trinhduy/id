using System;

namespace Contact.Class.Apartments
{
    public class StudioApartment : Apartment
    {
        public StudioApartment(double price, string name, string direction, string view, int floor, double area)
        {
            this.Area = area;
            this.Name = name;
            this.Direction = direction;
            this.View = view;
            this.Floor = floor;
            this.Price = price;
        }

        internal override void SetPrice()
        {
            throw new NotImplementedException();
        }

        internal override void SetDirection()
        {
            throw new NotImplementedException();
        }

        internal override void SetView()
        {
            throw new NotImplementedException();
        }

        internal override void SetFloor()
        {
            throw new NotImplementedException();
        }

        internal override void SetArea()
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