<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="ElectricityBillproject.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Login Page</title>
</head>
<body>
    <p>
        <br />
    </p>
    <form id="form1" runat="server">
         
        <div>
            <h2> Welcome To Login Page</h2>
           
            <br />
            Username : &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp; 
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Password: &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="btnLogin_Click"
                Style="background-color:lightskyblue"/>
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="lblmessage" ForeColor="Red"></asp:Label>
            <br />
        </div>
       


    </form>
</body>
</html>
