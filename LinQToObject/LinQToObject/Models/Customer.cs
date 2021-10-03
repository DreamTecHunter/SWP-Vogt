using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LinQToObject.Models
{
    [DefaultValue(Gender.unspecified)]

    enum Gender
    {
        male, female, unspecified
    }
    class Customer
    {

        private const int IDLENGTH = 8;
        private static int IdCounter = 0;
        // (KundenId, Vorname, Nachname, Geschlecht, Geburtsdatum, Postleitzahl, Wohnort, Adresse) 
        public String CustomerId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int PostalCode { get; set; }
        public string Domicile { get; set; }
        public string Address { get; set; }

        public Customer() : this(null, null, Gender.unspecified, DateTime.UnixEpoch, 0, null, null)
        {

        }

        public Customer(string firstName, string lastName, Gender gender, DateTime birthday, int postalCode, string domicile, string address)
        {

            this.CustomerId = string.Concat(Enumerable.Repeat("0", IDLENGTH - IMath.Log10(IdCounter))) + IdCounter;
            IdCounter++;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
            this.PostalCode = postalCode;
            this.Domicile = domicile;
            this.Address = address;
        }
    }
}
