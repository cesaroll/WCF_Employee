using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {
        private string connStr { get; set; }
        public EmployeeService()
        {
            connStr = ConfigurationManager.ConnectionStrings["WCFDB"].ConnectionString;
        }

        public Employee GetEmployee(int id)
        {
            Employee employee = null;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployee",con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parmId = new SqlParameter("@Id", id);

                cmd.Parameters.Add(parmId);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    employee = new Employee()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"])
                    };
                    
                }

            }

            return employee;
        }

        public void SaveEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parmId = new SqlParameter("@Id", employee.Id);
                SqlParameter parmName = new SqlParameter("@Name", employee.Name);
                SqlParameter parmGender = new SqlParameter("@Gender", employee.Gender);
                SqlParameter parmDoB = new SqlParameter("@DateOfBirth", employee.DateOfBirth);

                cmd.Parameters.Add(parmId);
                cmd.Parameters.Add(parmName);
                cmd.Parameters.Add(parmGender);
                cmd.Parameters.Add(parmDoB);

                con.Open();

                cmd.ExecuteNonQuery();

            }
        }
    }
}
