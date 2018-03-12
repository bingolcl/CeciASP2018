using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Travel Experts
 * Date: Jan 22, 2017
 * Author: Cecilia Zhang
 * Purpose: Set up the navbar and footer for all pages
 */

namespace TravelExperts_ASP
{ 

    public partial class TESite : System.Web.UI.MasterPage
    {
        //find the currentYear for the footer
        private string currentYear = DateTime.Today.Year.ToString();

        //display currentYear and set up the navbar links based on the login status
        protected void Page_Load(object sender, EventArgs e)
        {
            lblYear.Text = currentYear;

            if (Session["CustomerId"] != null)
            {
                lbtLogin.Visible = false;
                lbtLogout.Visible = true;
                lbtInfo.Visible = true;
                lbtRegister.Visible = false;

            }
            else
            {
                lbtLogin.Visible = true;
                lbtLogout.Visible = false;
                lbtInfo.Visible = false;
                lbtRegister.Visible = true;

            }
        }

        //set up the redirect url for each link
        protected void Home(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Home.aspx");
        }
        protected void Login(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void Register(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void lbtInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
        protected void BookingHistory(object sender, EventArgs e)
        {
            Response.Redirect("BookingHistory.aspx");
        }

        
    }
}