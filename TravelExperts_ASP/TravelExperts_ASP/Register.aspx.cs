using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Helpers;
/*Author Name: Harpreet Parmar
 * //Assisted: Riley Hobberstad 
 * 
 */

namespace TravelExperts_ASP
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();//focus on userName
        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            int userId = 0;//variable for hold userId
            CustomerAccount ca = new CustomerAccount();
            ca.CustFirstName = txtFirstName.Text.Trim();//get firstname value from form
            ca.CustLastName = txtLastName.Text.Trim();//get LastName value from form
            ca.CustAddress = txtAddress.Text.Trim();//get Address value from form
            ca.CustCity = txtCity.Text.Trim();//get City value from form
            ca.CustProv = ddlProvince.SelectedValue;//get Province value from form
            ca.CustPostal = txtPostal.Text.Trim();//get Postal value from form
            ca.CustCountry = txtCountry.Text.Trim();//get Country value from form
            ca.CustHomePhone = txtHomePhone.Text.Trim();//get HomePhone value from form
            ca.CustBusPhone = txtBusPhone.Text.Trim();//get BusPhone value from form
            ca.CustEmail = txtEmail.Text.Trim();//get Email value from form
            ca.CustUserName = txtUsername.Text.Trim();//get Username value from form

            string hashedPassword = Crypto.HashPassword(txtPassword.Text.Trim());

            ca.CustPassword = hashedPassword;//get Password value from form


            userId = CustomerAccountDB.InsertNewAccount(ca);

            string message = string.Empty;
            if (userId == -1)//checks if the user  id is wrong
            {
                message = "Username already exists.\\nPlease choose a different username.";
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
            else
            {
                Session["CustomerId"] = userId;//save  userid
                Session["CustFirstName"] = ca.CustFirstName;//save customer name
                Session["CustPassword"] = ca.CustPassword;//save customer password
                message = "Registration successful.\\nRedirecting to Home page..";//display message
                Response.Write("<script language='javascript'>alert('" + message + "');</script>");
                Server.Transfer("Home.aspx", true);
            }
        }

        protected void ClearInput(object sender, EventArgs e)
        {
            txtFirstName.Text = "";//reset first name
            txtLastName.Text = "";//reset last name
            txtAddress.Text = "";//reset address
            txtCity.Text = "";//reset city
            txtPostal.Text = "";//reset postal
            txtCountry.Text = "";//reset country
            txtHomePhone.Text = "";//reset home phone
            txtBusPhone.Text = "";//reset Bus phone
            txtEmail.Text = "";//reset email
            txtUsername.Text = "";//reset username
            txtPassword.Text = "";//reset password
            txtConfirmPassword.Text = "";//reset confirm password
            ddlProvince.ClearSelection();//reset province
        }
    }
}