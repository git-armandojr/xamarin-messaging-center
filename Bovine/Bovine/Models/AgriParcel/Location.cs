using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.AgriParcel
{
    class Location
    {
        LocationValue value { get; set; }

        public Location(double[] coordinates)
        {
            LocationValue lv = new LocationValue(coordinates);
            value = lv;
        }
    }

    public class LocationValue
    {
        public string type = "Polygon";
        public double[] coordinates;

        public LocationValue(double[] coordinates)
        {
            this.coordinates = coordinates;
        }
    }
}
