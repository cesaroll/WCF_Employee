using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeClient.EmployeeServiceReference;
using EmployeeClient.Util;

namespace EmployeeClient
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetEmployee_Click(object sender, EventArgs e)
        {
            var client = new EmployeeServiceReference.EmployeeServiceClient();

            EmployeeServiceReference.Employee emp = client.GetEmployee(Convert.ToInt32(txtId.Text));

            
            if (emp != null)
            {

                txtName.Text = emp.Name;
                txtGender.Text = emp.Gender;
                txtDoB.Text = emp.DateOfBirth.ToShortDateString();


                ddlEmpType.SelectedValue = ((int) emp.Type).ToString();

                SetFieldsVisible(emp.Type);

                txtAnualSal.Text = string.Empty;
                txtHourlyPay.Text = string.Empty;
                txtHoursWorked.Text = string.Empty;

                var empFullTime = emp as EmployeeServiceReference.EmployeeFullTime;

                if (empFullTime != null)
                {
                    txtAnualSal.Text = empFullTime.AnnualSalary.ToString();
                }
                else
                {
                    var empHourly = emp as EmployeeServiceReference.EmployeePartTime;

                    if (empHourly != null)
                    {
                        txtHourlyPay.Text = empHourly.HourlyPay.ToString();
                        txtHoursWorked.Text = empHourly.HoursWorked.ToString();
                    }
                }


                lblmsg.Text = "Employee retrieved";
            }
            else
                lblmsg.Text = "Employee Not Found";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeType empType = ddlEmpType.SelectedValue.ToEmployeeType();
            EmployeeServiceReference.Employee emp = null;


            if (empType == EmployeeType.EmployeeFullTime)
            {
                emp = new EmployeeServiceReference.EmployeeFullTime()
                {
                    ID = Convert.ToInt32(txtId.Text),
                    Name = txtName.Text,
                    Gender = txtGender.Text,
                    DateOfBirth = Convert.ToDateTime(txtDoB.Text),
                    Type = empType,
                    AnnualSalary = Convert.ToDecimal(txtAnualSal.Text)
                };
            }
            else if (empType == EmployeeType.EmployeePartTime)
            {
                emp = new EmployeeServiceReference.EmployeePartTime()
                {
                    ID = Convert.ToInt32(txtId.Text),
                    Name = txtName.Text,
                    Gender = txtGender.Text,
                    DateOfBirth = Convert.ToDateTime(txtDoB.Text),
                    Type = empType,
                    HourlyPay = Convert.ToDecimal(txtHourlyPay.Text),
                    HoursWorked = Convert.ToInt32(txtHoursWorked.Text)
                };
            }
            else
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "Please Select Employee Type";
                return;
            }
            
            var client = new EmployeeServiceReference.EmployeeServiceClient();

            client.SaveEmployee(emp);

            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = "Employee Saved";
        }

        protected void ddlEmpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            trAnualSal.Visible = false;
            trHourlyPay.Visible = false;
            trHoursWorked.Visible = false;

            SetFieldsVisible(ddlEmpType.SelectedValue.ToEmployeeType());

        }


        private void SetFieldsVisible(EmployeeType empType)
        {
            if (empType == EmployeeType.EmployeeFullTime)
            {
                trAnualSal.Visible = true;
                trHourlyPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else if(empType == EmployeeType.EmployeePartTime)
            {
                trAnualSal.Visible = false;
                trHourlyPay.Visible = true;
                trHoursWorked.Visible = true;
            }
            else
            {
                trAnualSal.Visible = false;
                trHourlyPay.Visible = false;
                trHoursWorked.Visible = false;
            }
        }
    }

    
}