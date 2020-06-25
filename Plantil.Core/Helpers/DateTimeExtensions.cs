using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Plantil.Core
{
    public static class DateTimeExtensions
    {
        public static int GetGapDays(this DateTime dateTimeOffset) {
            var currentdate = DateTime.Now;
            int days = (currentdate - dateTimeOffset).Days;
            return days;
        }
    }

}
