namespace Contact.Class
{
    public abstract class Shop : Product
    {
        public double Price { get; set; }
        public double Area { get; set; }

        public abstract void SetPrice(double price);
        public abstract void SetArea(double area);
    }
}