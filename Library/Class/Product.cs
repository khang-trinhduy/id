namespace Contact.Class
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public abstract void SetName(string name);
        public abstract void SetType(string type);

    }

}