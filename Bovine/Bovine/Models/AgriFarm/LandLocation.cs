using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.AgriParcel
{
    public class LandLocation
    {
        LandLocationValue value { get; set; }

        public LandLocation(double[] coordinates)
        {
            LandLocationValue llv = new LandLocationValue(coordinates);
            value = llv;
        }
    }

    public class LandLocationValue
    {
        string type = "Polygon";
        double[] coordinates;

        public LandLocationValue(double[] coordinates)
        {
            this.coordinates = coordinates;
        }
    }
}
