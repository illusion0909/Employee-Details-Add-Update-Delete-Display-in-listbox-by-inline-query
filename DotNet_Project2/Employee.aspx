<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="DotNet_Project2.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            /* Employee Details Add, Update,Delete, Display in listbox by inline query&nbsp; */<br />
            <br />
            Employee Number:<asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <br />
            Employee Name:<asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            <br />
            Employee Address:<asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
            <br />
            Employee Salary<asp:TextBox ID="TextBox4" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
            <br />
            <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Height="256px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="295px"></asp:ListBox>
            <br />
            <br />
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="margin-left: 25px; height: 29px;" Text="Update" Width="76px" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" style="margin-left: 30px" Text="Delete" Width="70px" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" style="width: 68px; margin-left: 25px" Text="Display" />
    </form>
</body>
</html>
