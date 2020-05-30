using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.AgriFarm
{
    class Location
    {
        string type = "geo:json";
        LocationValue value { get; set; }

        public Location(double[] coordinates)
        {
            LocationValue lv = new LocationValue(coordinates);
            value = lv;
        }
    }

    public class LocationValue
    {
        string type = "Point";
        double[] coordinates = new double[2];

        public LocationValue(double[] coordinates)
        {
            this.coordinates = coordinates;
        }
    }
}
