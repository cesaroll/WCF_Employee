using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeClient
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetEmployee_Click(object sender, EventArgs e)
        {
            EmployeeServiceReference.EmployeeServiceClient client = new EmployeeServiceReference.EmployeeServiceClient();

            EmployeeServiceReference.Employee emp = client.GetEmployee(Convert.ToInt32(txtId.Text));

            if (emp != null)
            {

                txtName.Text = emp.Name;
                txtGender.Text = emp.Gender;
                txtDoB.Text = emp.DateOfBirth.ToShortDateString();

                lblmsg.Text = "Employee retrieved";
            }
            else
                lblmsg.Text = "Employee Not Found";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeServiceReference.Employee emp = new EmployeeServiceReference.Employee()
            {
                Id = Convert.ToInt32(txtId.Text),
                Name = txtName.Text,
                Gender = txtGender.Text,
                DateOfBirth = Convert.ToDateTime(txtDoB.Text)
            };

            EmployeeServiceReference.EmployeeServiceClient client = new EmployeeServiceReference.EmployeeServiceClient();

            client.SaveEmployee(emp);

            lblmsg.Text = "Employee Saved";
        }
    }
}