using System.Configuration;
using EmployeeService.Entity.Interface;

namespace EmployeeService.Util
{
    public class DBUtil
    {
        public static string ConnStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["WCFDB"].ConnectionString;
            }
        }
 

    }
}