using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.AgriParcel
{
    public class AgriParcel
    {
        string id = "urn:ngsi-ld:AgriParcel:";
        string type = "AgriParcel";
        DateCreated dateCreated;
        DateModified dateModified;
        Location location;
        Area area;
        Description description;
        Category category;
        HasAnimal hasAnimal;

        public AgriParcel(string id,
                          DateTime dateCreated,
                          DateTime dateModified,
                          double[] location,
                          double area,
                          string description,
                          string category,
                          string[] hasAnimal)
        {
            this.id += id;
            this.dateCreated = new DateCreated(dateCreated);
            this.dateModified =  new DateModified(dateModified);
            this.location = new Location(location);
            this.area = new Area(area);
            this.description = new Description(description);
            this.category = new Category(category);
            this.hasAnimal = new HasAnimal(hasAnimal);
        }
    }
}
