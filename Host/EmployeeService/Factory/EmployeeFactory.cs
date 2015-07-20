using System;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel.Channels;
using EmployeeService.Entity;
using EmployeeService.Entity.Interface;
using EmployeeService.Factory.Interface;
using EmployeeService.Util;

namespace EmployeeService.Factory
{
    public class EmployeeFactory : IFactory
    {

        public virtual Employee GetFromDb(int id)
        {
            using (SqlConnection con = new SqlConnection(DBUtil.ConnStr))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployee", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parmId = new SqlParameter("@Id", id);

                cmd.Parameters.Add(parmId);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EmployeeType employeeType = (EmployeeType) reader["EmployeeType"];

                    switch (employeeType)
                    {
                        case EmployeeType.EmployeeFullTime:
                            return new EmployeeFullTime()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                Type = EmployeeType.EmployeeFullTime,
                                AnnualSalary = Convert.ToDecimal(reader["AnnualSalary"])
                            };

                        case EmployeeType.EmployeePartTime:
                            return new EmployeePartTime()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                Type = EmployeeType.EmployeePartTime,
                                HourlyPay = Convert.ToDecimal(reader["HourlyPay"]),
                                HoursWorked = Convert.ToInt32(reader["HoursWorked"])
                            };
                    }
                }

            }

            return null;
        }


        public virtual void Persist(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(DBUtil.ConnStr))
            {

                SqlCommand cmd = new SqlCommand("spSaveEmployee", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                
                cmd.Parameters.Add(new SqlParameter("@Id", employee.Id));
                cmd.Parameters.Add(new SqlParameter("@Name", employee.Name));
                cmd.Parameters.Add(new SqlParameter("@Gender", employee.Gender));
                cmd.Parameters.Add(new SqlParameter("@DateOfBirth", employee.DateOfBirth));
                cmd.Parameters.Add(new SqlParameter("@EmployeeType", employee.Type));

                PersistAddExtraParameters(cmd.Parameters, employee);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public virtual void PersistAddExtraParameters(SqlParameterCollection parameters, Employee employee)
        {
            //Must override in child clasess to add extra parameters
        }

        
        IEntity IFactory.GetFromDb(int id)
        {
            return GetFromDb(id);
        }

        void IFactory.Persist(IEntity entity)
        {
            Persist(entity as Employee);
        }
        
    }
}