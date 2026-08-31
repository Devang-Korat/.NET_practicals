<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leave_app.aspx.cs" Inherits="practical5.leave_app" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Application</title>
</head>

<body>
    <form id="form1" runat="server">

        <div>
            Leave Application
            <br /><br />

            Employee Name:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

            <br /><br />

            Leave Date:
            <asp:Label ID="lblleaveDate" runat="server"
                Text="Date will show here"></asp:Label>

            <br /><br />

            Leave Type:
            <asp:DropDownList ID="DropDownList2" runat="server" Height="31px">
                <asp:ListItem>Personal Leave</asp:ListItem>
                <asp:ListItem>Medical Leave</asp:ListItem>
                <asp:ListItem>Emergency Leave</asp:ListItem>
            </asp:DropDownList>

            <br /><br />
            
            Reason:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

            <br /><br />

            Remember Name:
            <asp:CheckBox ID="CheckBox1" runat="server"
                Text="Remember my name" />

            <br /><br />

            <asp:Button ID="Button1" runat="server"
                Text="Submit Leave"
                OnClick="Button1_Click" />

            <br /><br />

            <asp:Label ID="lblmsg" runat="server"
                Text="Details will be showing here"></asp:Label>

        </div>
    </form>
</body>
</html>
