using System.Collections.Generic;

namespace Contact.Class
{
    public class Contact
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual IdentityCard Identity { get; set; }
        public virtual List<Product> Product { get; set; }
        public Contact()
        {
        }
    }
}