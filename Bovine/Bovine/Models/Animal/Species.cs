using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.Animal
{
    public class Species
    {
        public string value { get; set; }

        public Species(string value)
        {
            this.value = value;
        }
    }
}
