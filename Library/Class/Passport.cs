using System;
using Contact.Enum;

namespace Contact.Class
{
    public class Passport : IdentityCard
    {
        public Gender Gender { get; set; }
        public string CountryOfPassport { get; set; }
        public string Type { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Nationality { get; set; }
        public string FamiliName { get; set; }
        public string GivenName { get; set; }

        public void SetId(int id) => this.Id = id;
        public void SetDOB(DateTime date) => this.DOB = date;
        public override void SetNumber(string number)
        {
            this.Number = number;
        }
        public void SetAuthorizer(string authorizer) => this.AuthorizedBy = authorizer;
        public void SetPhoto(string path) => this.Photo = path;
    }
}