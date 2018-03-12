<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TravelExperts_ASP.Login" MasterPageFile="TESite.Master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="jumbotron">
        <table class="w-100">
            <tr>
                <td>
                    <h1 class="text-left FormPaddingLeft"><strong>Login</strong></h1>
                </td>

            </tr>
            <tr>
                <td ></td>
            </tr>
            <tr>
                <td class="FormPaddingLeft">
                        <label class="col-form-label" for="inputDefault">Username:</label>
                        <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="UserName" Width="30%"></asp:TextBox>                        
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtUserName" ErrorMessage="Please Enter Your Username"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr>
                <td class="FormPaddingLeft">
                    <label>Password:</label>
                        <asp:TextBox ID="txtPassword" class="form-control" TextMode="Password" placeholder="Password" runat="server" Width="30%"></asp:TextBox>                        
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtPassword" ErrorMessage="Please Enter Your Password"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="FormPaddingLeft">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="FormPaddingLeft">
                    <div class="form-text text-muted" >&nbsp;<asp:Button ID="btnLogin" class="btn btn-success" runat="server" Text="Log In" OnClick="Submit_Click"/>
                    &nbsp;&nbsp; Do not have an account yet?
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Register.aspx">Register</asp:HyperLink>
                    &nbsp;now!</div>
                </td>
            </tr>
            <tr>
                <td class="loginBotPadding"></td>
            </tr>
        </table>
    </div>
</asp:Content>




