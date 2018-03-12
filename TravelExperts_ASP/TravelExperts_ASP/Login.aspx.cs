using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Helpers;


/*
 * Travel Experts
 * Date: Jan 22, 2017
 * Author: Cecilia Zhang
 * Purpose: Verify user info and then change login status.
 */

namespace TravelExperts_ASP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //verify the input username and password(with the hashedpassword)
        protected void Submit_Click(object sender, EventArgs e)
        {
            var verify = false;

            CustomerAccount Cust = new CustomerAccount();
                
            Cust.CustUserName = txtUserName.Text;
            Cust = CustomerAccountDB.UserChecker(Cust);

            if (Cust.CustomerId != 0)
            {
                verify = Crypto.VerifyHashedPassword(Cust.CustPassword, txtPassword.Text); 
                if( verify == true)
                {
                    Session["CustomerId"] = Cust.CustomerId;
                    Session["CustFirstName"] = Cust.CustFirstName;
                    Session["CustPassword"] = txtPassword.Text;
                    if (Session["prevUrl"] != null)
                    {
                        Response.Redirect(Session["prevUrl"].ToString());
                    }
                    else
                    {
                        Response.Redirect("Home.aspx");
                    }

                }
                else
                {
                    lblMessage.Text = "Username or Password is incorrect";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                
            }
            else
            {
                lblMessage.Text = "Username or Password is incorrect";
                lblMessage.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
}