using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeClient.EmployeeServiceReference;

namespace EmployeeClient.Util
{
    public static class StringExtensions
    {
        public static EmployeeType ToEmployeeType(this string str)
        {
            return (EmployeeType)Convert.ToInt32(str);
        }
    }
}