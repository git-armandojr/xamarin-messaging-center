using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.AgriParcel
{
    public class HasAgriParcel
    {
        string type = "Relationship";
        string[] value { get; set; }

        public HasAgriParcel(string[] value)
        {
            this.value = value;
        }
    }
}
