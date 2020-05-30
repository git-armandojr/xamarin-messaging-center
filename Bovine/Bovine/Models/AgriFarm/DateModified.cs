using System;
using System.Collections.Generic;
using System.Text;

namespace Bovine.Models.AgriFarm
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
