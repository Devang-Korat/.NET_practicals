<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="practical4.WebForm1"  UnobtrusiveValidationMode="None" %> 

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>College Event Registration</title>
</head>

<body>

<form id="form1" runat="server">

    <div>
        <h2>College Event Registration</h2>
        <div>
            Student Name:
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvName"
                runat="server"
                ControlToValidate="txtName"
                ErrorMessage="Enter name"
                ForeColor="Red">
            </asp:RequiredFieldValidator>

        </div>
        <br />

        <div>
            Enrollment No:
            <asp:TextBox ID="txtEnrollment" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvEnrollment"
                runat="server"
                ControlToValidate="txtEnrollment"
                ErrorMessage="Enter enrollment number"
                ForeColor="Red">
            </asp:RequiredFieldValidator>

        </div>
        <br />

        <div>
            Class:
            <asp:TextBox ID="txtClass" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvClass"
                runat="server"
                ControlToValidate="txtClass"
                ErrorMessage="Enter class"
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>

        <br />

        <div>
            Email:
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvEmail"
                runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="Enter email"
                ForeColor="Red">
            </asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator
                ID="revEmail"
                runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="Enter valid email"
                ForeColor="Red"
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$">
            </asp:RegularExpressionValidator>

        </div>
        <br />

        <div>

            Mobile No:

            <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvMobile"
                runat="server"
                ControlToValidate="txtMobile"
                ErrorMessage="Enter mobile number"
                ForeColor="Red">
            </asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator
                ID="revMobile"
                runat="server"
                ControlToValidate="txtMobile"
                ErrorMessage="Enter 10 digit number"
                ForeColor="Red"
                ValidationExpression="^[0-9]{10}$">
            </asp:RegularExpressionValidator>

        </div>

        <br />

        <div>
            Gender:
            <asp:RadioButtonList
                ID="rblGender"
                runat="server"
                RepeatDirection="Horizontal">

                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>

            </asp:RadioButtonList>
            <asp:RequiredFieldValidator
                ID="rfvGender"
                runat="server"
                ControlToValidate="rblGender"
                ErrorMessage="Select gender"
                ForeColor="Red">
            </asp:RequiredFieldValidator>

        </div>
        <br />

        <div>
            Select Events:
            <br />
            <asp:CheckBox
                ID="chkQuiz"
                runat="server"
                Text="Technical Quiz" />
            <br />

            <asp:CheckBox
                ID="chkHackathon"
                runat="server"
                Text="Hackathon" />
            <br />

            <asp:CheckBox
                ID="chkCultural"
                runat="server"
                Text="Cultural Event" />
            <br />

            <asp:CheckBox
                ID="chkSports"
                runat="server"
                Text="Sports Event" />
            <br />

            <asp:CustomValidator
                ID="cvEvents"
                runat="server"
                ErrorMessage="Select at least one event"
                ForeColor="Red"
                OnServerValidate="cvEvents_ServerValidate">
            </asp:CustomValidator>
        </div>

        <br />
        <asp:Button
            ID="btnSubmit"
            runat="server"
            Text="Submit"
            OnClick="btnSubmit_Click" />

        <asp:Button
            ID="btnCancel"
            runat="server"
            Text="Cancel"
            CausesValidation="false"
            OnClick="btnCancel_Click" />

        <br />
        <br />
        <asp:Panel
            ID="pnlResult"
            runat="server"
            Visible="false">

            <h3>Registration Details</h3>

            <asp:Label
                ID="lblResult"
                runat="server">
            </asp:Label>
        </asp:Panel>
    </div>
</form>
</body>
</html>
