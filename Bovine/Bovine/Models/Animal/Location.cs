using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.Animal
{
    public class Location
    {
        public string type = "geo:json";
        public LocationValue value { get; set; }

        public Location(double[] coordinates)
        {
            LocationValue lv = new LocationValue(coordinates);
            value = lv;
        }
    }

    public class LocationValue
    {
        public string type = "Point";
        public double[] coordinates = new double[2];

        public LocationValue(double[] coordinates)
        {
            this.coordinates = coordinates;
        }
    }
}
