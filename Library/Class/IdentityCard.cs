using System;
namespace Contact.Class
{
    public abstract class IdentityCard
    {
        public int Id { get; set; }
        public DateTime DOB { get; set; }
        public string AuthorizedBy { get; set; }
        public DateTime AuthorizedDate { get; set; }
        public string Number { get; set; }
        public string Photo { get; set; }
        public int? ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public abstract void SetNumber(string number);
    }
}