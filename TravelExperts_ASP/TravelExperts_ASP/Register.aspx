<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TravelExperts_ASP.Register" MasterPageFile="TESite.Master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="jumbotron">

     
    <table  class="table text-center">
        <tr>
            <td colspan="3" class="text-center">
                <h1>Registration</h1>

            </td>

        </tr>
            <tr>
                <td class="text-right">Username:</td>
                <td colspan="2">
             <asp:TextBox  class="form-control" for="inputDefault"  ID="txtUsername" runat="server" CausesValidation="True"/>
            </td>
            <td class="form-group has-danger text-left" style="width: 225px">
                <asp:RequiredFieldValidator class="form-control-label" ErrorMessage="Username is Required" ForeColor="Red" ControlToValidate="txtUsername"
                    runat="server" ID="RequiredFieldValidator2" />

                </td>
            </tr>
            <tr>
                <td class="text-right">Password:</td>
                  <td colspan="2">
                <asp:TextBox class="form-control" ID="txtPassword" runat="server" TextMode="Password" CausesValidation="True" />
            </td>
            <td class="form-group has-danger text-left" style="width: 225px; height: 28px;">
                <asp:RequiredFieldValidator class="form-control-label" ErrorMessage="Password is Required" ForeColor="Red" ControlToValidate="txtPassword"
                    runat="server" ID="RequiredFieldValidator1" />
            
                </td>
            </tr>
          <tr>
                <td class="text-right">Confirm Password:</td>
                 <td colspan="2">
                <asp:TextBox class="form-control" ID="txtConfirmPassword" runat="server" TextMode="Password" CausesValidation="True" />
            </td>
            <td class="form-group has-danger text-left" style="width: 225px">
                <asp:RequiredFieldValidator class="form-control-label" ErrorMessage="Confirm Password is Required" ForeColor="Red" ControlToValidate="txtConfirmPassword"
                    runat="server" ID="RequiredFieldValidator3" Display="Dynamic" />
                <asp:CompareValidator class="form-control-label" ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                    ControlToValidate="txtConfirmPassword" runat="server" ID="CompareValidator1" Display="Dynamic" />
            </td>
                
            </tr>
            <tr>
                <td colspan="3" class="text-center">
                    <h1>Personal Information</h1></td>
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
            <td class="form-group has-danger text-left"  style="width: 225px">
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
            </tr>
            <tr>
                <td class="text-right">Postal:</td>
                            <td colspan="2">
                <asp:TextBox class="form-control" ID="txtPostal" runat="server" CausesValidation="True" />
            </td>
            <td class="form-group has-danger text-left" style="width: 225px">
                   
            
                    <asp:RequiredFieldValidator ErrorMessage="Postal Required" Display="Dynamic" ForeColor="Red"
                        ControlToValidate="txtPostal" runat="server" ID="txtPostalRequired" />
                    <asp:RegularExpressionValidator ID="PostalMasked" runat="server" ControlToValidate="txtPostal"
                        Display="Dynamic" ForeColor="Red" ErrorMessage="Invalid postal code."
                        ValidationExpression="(\D{1}\d{1}\D{1}\-?\d{1}\D{1}\d{1})|(\D{1}\d{1}\D{1}\ ?\d{1}\D{1}\d{1})" />
                </td>
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
                    <asp:RequiredFieldValidator ErrorMessage="Home phone is Required" Display="Dynamic" ForeColor="Red"
                        ControlToValidate="txtHomePhone" runat="server" ID="txtHomePhoneRequired" />
                    <asp:RegularExpressionValidator ID="HomePhoneMasked" runat="server" ControlToValidate="txtHomePhone"
                        Display="Dynamic" ForeColor="Red" ErrorMessage="Invalid home phone number."
                        ValidationExpression="\(?\d{3}\)?-? *\d{3}-? *-?\d{4}" />
                </td>
            </tr>
            <tr>
                <td class="text-right">Work Phone:</td>
                 <td colspan="2">
                    <asp:TextBox class="form-control" ID="txtBusPhone" runat="server" TextMode="Phone" CausesValidation="True"></asp:TextBox>
                </td>
               <td class="form-group has-danger text-left" style="width: 225px">
                    <asp:RegularExpressionValidator ID="BusPhoneMasked" runat="server" ControlToValidate="txtBusPhone"
                        Display="Dynamic" ForeColor="Red" ErrorMessage="Invalid work phone number."
                        ValidationExpression="\(?\d{3}\)?-? *\d{3}-? *-?\d{4}" />
                </td>
            </tr>
            <tr>
                <td class="text-right">Email:</td>
                  <td colspan="2">
                    <asp:TextBox class="form-control" ID="txtEmail" runat="server" TextMode="Email" CausesValidation="True"></asp:TextBox>
                </td>
                 <td class="form-group has-danger text-left" style="width: 225px">
                    <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." ID="txtEmailRegularExpressionValidator" />
                </td>
            </tr>
            <tr>
                <td></td>
                 <td><asp:ValidationSummary ID="summary" ForeColor="Red" runat="server" DisplayMode="BulletList" /></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button class="btn btn-success" Text="Submit" runat="server" OnClick="RegisterUser" Height="35px" Width="148px" ID="btnSubmit" />
                </td>
                <td>
                    <asp:Button class="btn btn-secondary" Text="Reset" runat="server" OnClick="ClearInput" ID="btnReset" Height="36px" Width="148px" CausesValidation="False" />
                </td>

            </tr>
        </table>
    </div>
</asp:Content>
