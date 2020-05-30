using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.AgriParcel
{
    public class Address
    {
        string type = "PostalAddress";
        AddressValue value { get; set; }

        public Address(string addressLocality, string addressCountry, string streetAddress)
        {
            AddressValue av = new AddressValue(addressLocality, addressCountry, streetAddress);
            value = av;
        }
    }

    public class AddressValue
    {
        string addressLocality { get; set; }
        string addressCountry { get; set; }
        string streetAddress { get; set; }

        public AddressValue(string addressLocality, string addressCountry, string streetAddress)
        {
            this.addressLocality = addressLocality;
            this.addressCountry = addressCountry;
            this.streetAddress = streetAddress;
        }
    }
}
