using System;
using System.Text.RegularExpressions;

namespace Contact.Class
{
    public class LocalIdentityCard : IdentityCard
    {
        public string FullName { get; set; }
        public string HomeTown { get; set; }
        public string Residence { get; set; }
        public string EthnicGroup { get; set; }
        public string Religion { get; set; }
        public override void SetNumber(string number)
        {
            if (Invalid(number))
            {
                throw new Exception();
            }
            this.Number = number;
        }
        private string GetNumber()
        {
            return this.Number;
        }

        public bool Invalid(string number)
        {
            if (number.Length != 9)
            {
                return true;
            }
            Regex re = new Regex("[\\D]+");
            if (re.IsMatch(number))
            {
                return true;
            }
            return false;
        }

        public void SetId(int id) => this.Id = id;
        public void SetDOB(DateTime date) => this.DOB = date;
        public void SetAuthorizer(string authorizer) => this.AuthorizedBy = authorizer;
        public void SetPhoto(string path) => this.Photo = path;
    }
}