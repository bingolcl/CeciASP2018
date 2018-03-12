using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Helpers;
//Author: Riley Hobberstad
//Assisted: Harpreet Parmar

namespace TravelExperts_ASP
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerId"] == null)//check login
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!IsPostBack)//load the customer information
                {
                    int CustomerId = (int) Session["CustomerId"];
                    CustomerAccount ca = new CustomerAccount();
                    ca = CustomerAccountDB.GetAccountByID(CustomerId);

                    txtUsername.Text = ca.CustUserName;
                    txtFirstName.Text = ca.CustFirstName;
                    txtLastName.Text = ca.CustLastName;
                    txtAddress.Text = ca.CustAddress;
                    txtCity.Text = ca.CustCity;
                    ddlProvince.SelectedValue = ca.CustProv;
                    txtPostal.Text = ca.CustPostal;
                    txtCountry.Text = ca.CustCountry;
                    txtHomePhone.Text = ca.CustHomePhone;
                    txtBusPhone.Text = ca.CustBusPhone;
                    txtEmail.Text = ca.CustEmail;
                }
            }
        }
        protected void UpdateUser(object sender, EventArgs e)
        {
            if((txtConfirmPassword.Text.Length == 0 && txtPassword.Text.Length != 0))//check password matching
            {
                lblComfirmPasswordError.ForeColor = System.Drawing.Color.Red;
                lblComfirmPasswordError.Text = "Passwords do not match";
                txtPassword.Focus();
            }
            else
            {
                lblComfirmPasswordError.Text = "";
                int userId = 0;
                CustomerAccount ca = new CustomerAccount();
                ca.CustomerId = (int)Session["CustomerId"];
                ca.CustFirstName = txtFirstName.Text.Trim();
                ca.CustLastName = txtLastName.Text.Trim();
                ca.CustAddress = txtAddress.Text.Trim();
                ca.CustCity = txtCity.Text.Trim();
                ca.CustProv = ddlProvince.SelectedValue;
                ca.CustPostal = txtPostal.Text.Trim();
                ca.CustCountry = txtCountry.Text.Trim();
                ca.CustHomePhone = txtHomePhone.Text.Trim();
                ca.CustBusPhone = txtBusPhone.Text.Trim();
                ca.CustEmail = txtEmail.Text.Trim();
                ca.CustUserName = txtUsername.Text.Trim();
                if(txtPassword.Text.Length != 0)
                { 
                    string hashedPassword = Crypto.HashPassword(txtPassword.Text.Trim());
                    ca.CustPassword = hashedPassword;//get hashed Password value 
                
                }
                else
                {
                    string hashedPassword = Crypto.HashPassword(Session["CustPassword"].ToString());
                    ca.CustPassword = hashedPassword;
                }

                userId = CustomerAccountDB.UpdateAccount(ca);//save the updates into database            
            
                string message = string.Empty;
                if (userId != 0)
                {
                    message = "Information update successfully";
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                }
                else
                {
                    message = "Error occured while updating.";
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);

                }
            }
        }

        protected void Cancel(object sender, EventArgs e)//redirect to home page for cancel button
        {
            Response.Redirect("Home.aspx");
        }

    }
}