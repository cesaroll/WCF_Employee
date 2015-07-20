<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="EmployeeClient.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table >
            <tr>
                <td>ID</td>
                <td>
                    <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Name</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Gender</td>
                <td>
                    <asp:TextBox ID="txtGender" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Date Of Birth</td>
                <td>
                    <asp:TextBox ID="txtDoB" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Employee Type</td>
                <td>
                    <asp:DropDownList ID="ddlEmpType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEmpType_SelectedIndexChanged">
                        <asp:ListItem Text="Select Employee Type" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Full Time Employee" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Part Time Employee" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
           <tr id="trAnualSal" runat="server" Visible="false">
                <td>Annual Salary</td>
                <td>
                    <asp:TextBox ID="txtAnualSal" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="trHourlyPay" runat="server" Visible="false">
                <td>Hourly Pay</td>
                <td>
                    <asp:TextBox ID="txtHourlyPay" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="trHoursWorked" runat="server" Visible="false">
                <td>Hours Worked</td>
                <td>
                    <asp:TextBox ID="txtHoursWorked" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnGetEmployee" runat="server" Text="Get Employee" OnClick="btnGetEmployee_Click" />
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save Employee" OnClick="btnSave_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblmsg" runat="server" ></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
