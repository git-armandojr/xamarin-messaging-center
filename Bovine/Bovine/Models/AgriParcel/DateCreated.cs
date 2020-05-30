using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.AgriParcel
{
    public class DateCreated
    {
        string type = "DateTime";
        DateTime value { get; set; }

        public DateCreated(DateTime value)
        {
            this.value = value;
        }
    }
}
