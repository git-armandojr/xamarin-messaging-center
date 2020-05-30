using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.Animal
{
    public class LegalID
    {
        public string value { get; set; }

        public LegalID(string value)
        {
            this.value = value;
        }
    }
}
