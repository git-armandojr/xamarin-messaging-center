using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.Animal
{
    public class Birthdate
    {
        public string type = "DateTime";
        public DateTime value { get; set; }

        public Birthdate(DateTime value)
        {
            this.value = value;
        }
    }
}
