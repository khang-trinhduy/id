using System;

namespace Contact.Class
{
    public abstract class Apartment : Product
    {
        public double Price { get; set;}
        public string Direction { get; set;}
        public string View { get; set;}
        public int Floor { get; set;}
        public double Area { get; set;}
        internal abstract void SetPrice();
        internal abstract void SetDirection();
        internal abstract void SetView();
        internal abstract void SetFloor();
        internal abstract void SetArea();
    }
}