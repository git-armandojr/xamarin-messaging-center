using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models
{
    public class Address
    {
        public string addressLocality { get; set; }
        public string addressCountry { get; set; }
        public string streetAddress { get; set; }

        public Address(string addressLocality, string addressCountry, string streetAddress)
        {
            this.addressLocality = addressLocality;
            this.addressCountry = addressCountry;
            this.streetAddress = streetAddress;
        }
    }
}
