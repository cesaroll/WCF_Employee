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
            var empRequest = new EmployeeServiceReference.EmployeeRequest("AXG120ABC", Convert.ToInt32(txtId.Text));

            EmployeeServiceReference.EmployeeInfo empinfo = null;
            
            var client = new EmployeeServiceReference.EmployeeServiceClient();
            try
            {
                empinfo = client.GetEmployee(empRequest);
            }
            catch (Exception)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "Employee Not Found";
            }



            if (empinfo != null)
            {

                txtName.Text = empinfo.Name;
                txtGender.Text = empinfo.Gender;
                txtDoB.Text = empinfo.DOB.ToShortDateString();


                ddlEmpType.SelectedValue = ((int) empinfo.Type).ToString();

                SetFieldsVisible(empinfo.Type);

                txtAnualSal.Text = string.Empty;
                txtHourlyPay.Text = string.Empty;
                txtHoursWorked.Text = string.Empty;

                if (empinfo.Type == EmployeeServiceReference.EmployeeType.EmployeeFullTime)
                {
                    txtAnualSal.Text = empinfo.AnnualSalary.ToString();
                }
                else
                {
                    txtHourlyPay.Text = empinfo.HourlyPay.ToString();
                    txtHoursWorked.Text = empinfo.HoursWorked.ToString();
                }

                lblmsg.ForeColor = Color.Green;
                lblmsg.Text = "Employee retrieved";
            }
            else
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "Employee Not Found";
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeType empType = ddlEmpType.SelectedValue.ToEmployeeType();

            var empInfo = new EmployeeServiceReference.EmployeeInfo()
            {
                Id = Convert.ToInt32(txtId.Text),
                Name = txtName.Text,
                Gender = txtGender.Text,
                DOB = Convert.ToDateTime(txtDoB.Text),
                Type = empType
            };


            if (empType == EmployeeType.EmployeeFullTime)
            {
                empInfo.AnnualSalary = Convert.ToDecimal(txtAnualSal.Text);
            }
            else if (empType == EmployeeType.EmployeePartTime)
            {
                empInfo.HourlyPay = Convert.ToDecimal(txtHourlyPay.Text);
                empInfo.HoursWorked = Convert.ToInt32(txtHoursWorked.Text);
            }
            else
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "Please Select Employee Type";
                return;
            }
            
            var client = new EmployeeServiceReference.EmployeeServiceClient();

            client.SaveEmployee(empInfo);

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