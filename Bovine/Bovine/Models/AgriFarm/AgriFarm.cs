using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.AgriParcel
{
    public class AgriFarm
    {
        string id = "urn:ngsi-ld:AgriFarm:"; //concatenar com string de um id. Ex.: urn:ngsi-ld:AgriFarm:0001
        string type = "AgriFarm";
        DateCreated dateCreated;
        DateModified dateModified;
        Name name;
        Description description;
        Location location;
        LandLocation landLocation;
        Address address;
        HasAgriParcel hasAgriParcel;

        public AgriFarm(string id,
                        DateTime dateCreated,
                        DateTime dateModified,
                        string name,
                        string description,
                        double[] location,
                        double[] landLocation,
                        string addressLocality,
                        string addressCountry,
                        string streetAddress,
                        string[] hasAgriParcel)
        {
            this.id += id;
            this.dateCreated = new DateCreated(dateCreated);
            this.dateModified = new DateModified(dateModified);
            this.name = new Name(name);
            this.description = new Description(description);
            this.location = new Location(location);
            this.landLocation = new LandLocation(landLocation);
            address = new Address(addressLocality, addressCountry, streetAddress);
            this.hasAgriParcel = new HasAgriParcel(hasAgriParcel);
        }
    }
}
