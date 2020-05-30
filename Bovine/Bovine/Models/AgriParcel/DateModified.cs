using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.AgriParcel
{
    public class DateModified
    {
        string type = "DateTime";
        DateTime value { get; set; }

        public DateModified(DateTime value)
        {
            this.value = value;
        }
    }
}
