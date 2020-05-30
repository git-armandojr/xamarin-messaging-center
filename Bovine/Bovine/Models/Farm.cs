using Bovine.Models.Geolocation;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models
{
    public class Farm
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        //public const string Type = "AgriFarm";
        //public DateTime DateCreated { get; set; }
        //public DateTime DateModified { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string Locality { get; set; }
        public string Country { get; set; }
        //public Point Location { get; set; }
        //public Polygon LandLocation { get; set; }
        //public Address Address { get; set; }
        //public ContactPoint ContactPoint { get; set; }
    }
}
