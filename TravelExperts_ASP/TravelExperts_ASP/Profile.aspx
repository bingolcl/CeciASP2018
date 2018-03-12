<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TravelExperts_ASP.Profile" MasterPageFile="TESite.Master" %>


<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<div class="jumbotron">
    

    <table  class="table text-center">
        <tr>
            <td colspan="3" class="text-center">
                <h1>Account Information</h1>
            </td>
        </tr>                       

        <tr>
            <td class="text-right">Username:</td>
            <td colspan="2">
                <asp:TextBox  class="form-control" for="inputDefault"  ID="txtUsername" runat="server" CausesValidation="True"  ReadOnly="True"/>
            </td>
            <td class="form-group has-danger text-left" style="width: 225px">
                <asp:RequiredFieldValidator class="form-control-label" ErrorMessage="Username is Required" ForeColor="Red" ControlToValidate="txtUsername"
                    runat="server" ID="RequiredFieldValidator1" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="text-right">New Password:</td>
            <td colspan="2">
                <asp:TextBox class="form-control" ID="txtPassword" runat="server" TextMode="Password" CausesValidation="True" />
            </td>
            <td class="form-group has-danger text-left" style="width: 225px; height: 28px;">                
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="text-right">Confirm Password:</td>
            <td colspan="2">
                <asp:TextBox class="form-control" ID="txtConfirmPassword" runat="server" TextMode="Password" CausesValidation="True" />
            </td>
            <td class="form-group has-danger text-left" style="width: 225px">
                <asp:CompareValidator class="form-control-label" ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                    ControlToValidate="txtConfirmPassword" runat="server" ID="CompareValidator1" />
                <asp:Label ID="lblComfirmPasswordError" runat="server"></asp:Label>
            </td>
            <td></td>
        </tr>
         <tr>
            <td colspan="3" class="text-center">
                <h1>Personal Information</h1>
            <td></td>
        </tr>
        <tr>
            <td class="text-right">First Name:</td>
            <td colspan="2">
                <asp:TextBox class="form-control" ID="txtFirstName" runat="server" CausesValidation="True" />
            </td>
            <td class="form-group has-danger text-left" style="width: 225px">
                <asp:RequiredFieldValidator class="form-control-label" ErrorMessage="First Name is Required" Display="Dynamic" ForeColor="Red"
                    ControlToValidate="txtFirstName" runat="server" ID="txtFirstNameRequired" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right">Last Name:</td>
            <td colspan="2">
                <asp:TextBox class="form-control" ID="txtLastName" runat="server" CausesValidation="True" />
            </td>
            <td class="form-group has-danger text-left" style="width: 225px">
                <asp:RequiredFieldValidator class="form-control-label" ErrorMessage="Last Name is Required" Display="Dynamic" ForeColor="Red"
                    ControlToValidate="txtLastName" runat="server" ID="txtLastNameRequired" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right">Address:</td>
            <td colspan="2">
                <asp:TextBox class="form-control" ID="txtAddress" runat="server" CausesValidation="True" />
            </td>
            <td class="form-group has-danger text-left" style="width: 225px">
                <asp:RequiredFieldValidator class="form-control-label" ErrorMessage="Address is Required" Display="Dynamic" ForeColor="Red"
                    ControlToValidate="txtAddress" runat="server" ID="txtAddressRequired" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="text-right">City:</td>
            <td colspan="2">
                <asp:TextBox class="form-control" ID="txtCity" runat="server" CausesValidation="True" />
            </td>
            <td class="form-group has-danger text-left" style="width: 225px">
                <asp:RequiredFieldValidator class="form-control-label" ErrorMessage="City is Required" Display="Dynamic" ForeColor="Red"
                    ControlToValidate="txtCity" runat="server" ID="txtCityRequired" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="text-right">Province:</td>
            <td class="form-group" colspan="2">
                <asp:DropDownList class="custom-select" ID="ddlProvince" runat="server" CausesValidation="True">
                    <asp:ListItem Value="AB">Alberta</asp:ListItem>
                    <asp:ListItem Value="BC">British Columbia</asp:ListItem>
                    <asp:ListItem Value="MB">Manitoba</asp:ListItem>
                    <asp:ListItem Value="NB">New Brunswick</asp:ListItem>
                    <asp:ListItem Value="NL">Newfoundland and Labrador</asp:ListItem>
                    <asp:ListItem Value="NS">Nova Scotia</asp:ListItem>
                    <asp:ListItem Value="ON">Ontario</asp:ListItem>
                    <asp:ListItem Value="PE">Prince Edward Island</asp:ListItem>
                    <asp:ListItem Value="QC">Quebec</asp:ListItem>
                    <asp:ListItem Value="SK">Saskatchewan</asp:ListItem>
                    <asp:ListItem Value="NT">Northwest Territories</asp:ListItem>
                    <asp:ListItem Value="NU">Nunavut</asp:ListItem>
                    <asp:ListItem Value="YT">Yukon</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>                
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="text-right">Postal:</td>
            <td colspan="2">
                <asp:TextBox class="form-control" ID="txtPostal" runat="server" CausesValidation="True" />
            </td>
            <td class="form-group has-danger text-left" style="width: 225px">
                <asp:RequiredFieldValidator class="form-control-label" ErrorMessage="Postal Code is Required" Display="Dynamic" ForeColor="Red"
                    ControlToValidate="txtPostal" runat="server" ID="txtPostalRequired" />
                <asp:RegularExpressionValidator class="form-control-label" ID="PostalMasked" runat="server" ControlToValidate="txtPostal"
                    Display="Dynamic" ForeColor="Red" ErrorMessage="Invalid postal code."
                    ValidationExpression="(\D{1}\d{1}\D{1}\-?\d{1}\D{1}\d{1})|(\D{1}\d{1}\D{1}\ ?\d{1}\D{1}\d{1})"/>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="text-right">Country:</td>
            <td colspan="2">
                <asp:TextBox class="form-control" ID="txtCountry" runat="server" ReadOnly="True" CausesValidation="True">Canada</asp:TextBox>
            </td>
            <td class="form-group has-danger text-left" style="width: 225px">
                <asp:RequiredFieldValidator class="form-control-label" ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                    ControlToValidate="txtCountry" runat="server" ID="txtCountryRequired" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="text-right">Home Phone:</td>
            <td colspan="2">
                <asp:TextBox class="form-control" ID="txtHomePhone" runat="server" TextMode="Phone" CausesValidation="True"></asp:TextBox>
            </td>
            <td class="form-group has-danger text-left" style="width: 225px">
                <asp:RequiredFieldValidator class="form-control-label" ErrorMessage="Home Phone is Required" Display="Dynamic" ForeColor="Red"
                    ControlToValidate="txtHomePhone" runat="server" ID="txtHomePhoneRequired" />
                <asp:RegularExpressionValidator class="form-control-label" ID="HomePhoneMasked" runat="server" ControlToValidate="txtHomePhone"
                    Display="Dynamic" ForeColor="Red" ErrorMessage="Invalid home phone number."
                    ValidationExpression="\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"/>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="text-right">Work Phone:</td>
            <td colspan="2">
                <asp:TextBox class="form-control" ID="txtBusPhone" runat="server" TextMode="Phone" CausesValidation="True"></asp:TextBox>
            </td>
            <td class="form-group has-danger text-left" style="width: 225px">
                <asp:RegularExpressionValidator class="form-control-label" ID="BusPhoneMasked" runat="server" ControlToValidate="txtBusPhone"
                    Display="Dynamic" ForeColor="Red" ErrorMessage="Invalid work phone number."
                    ValidationExpression="\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"/>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="text-right">Email:</td>
            <td colspan="2">
                <asp:TextBox class="form-control" ID="txtEmail" runat="server" TextMode="Email" CausesValidation="True"></asp:TextBox>
            </td>
            <td class="form-group has-danger text-left" style="width: 225px">
                <asp:RegularExpressionValidator class="form-control-label" runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." ID="txtEmailRegularExpressionValidator" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:ValidationSummary ID="summary" ForeColor="Red" runat="server" DisplayMode="BulletList" /></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button class="btn btn-success" Text="Save" runat="server" OnClick="UpdateUser" Height="35px" Width="148px" ID="Button1"/>
            </td>
            <td>
                <asp:Button class="btn btn-secondary" Text="Cancel" runat="server" OnClick="Cancel" ID="btnCancel" Height="36px" Width="148px" CausesValidation="False"/>
            </td>
            <td>
                
            </td>
            <td></td>
        </tr>
    </table>
    </div>
</asp:Content>
