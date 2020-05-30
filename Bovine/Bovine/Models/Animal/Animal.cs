using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.Animal
{
    public class Animal
    {
        public string id = "urn:ngsi-ld:Animal:";
        public string type = "Animal";
        public Species species;
        public LegalID legalID;
        public Birthdate birthdate;
        public Sex sex;
        public Location location;
        public Weight weight;

        public Animal(string id, string species, string legalID, DateTime birthdate, string sex, double[] location, double weight)
        {
            this.id += id;
            this.species = new Species(species);
            this.legalID = new LegalID(legalID);
            this.birthdate = new Birthdate(birthdate);
            this.sex = new Sex(sex);
            this.location = new Location(location);
            this.weight = new Weight(weight);
        }
    }
}
