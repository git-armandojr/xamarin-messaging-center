using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.AgriParcel
{
    public class HasAnimal
    {
        string type = "Relationship";
        string[] value { get; set; }

        public HasAnimal(string[] value)
        {
            this.value = value;
        }
    }
}
