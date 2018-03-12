using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Author: Mohammad Adam Butt
//Assisted: Cecilia Zhang
namespace TravelExperts_ASP
{
    public partial class BookingHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //save the current URL before redirecting
            Session["prevUrl"] = Request.Url;

            //if customer ID is not logged in and accessing page directly, redirect to login
            if (Session["CustomerId"] == null)
            {
                Response.Redirect("Login.aspx");
                
            }

            //once page has loaded, select the first booking from the grid view, set fonts
            if (!IsPostBack)
            {
                gvbooking.SelectedIndex = 0;
                gvbooking.ControlStyle.Font.Size = 11;
                dvBookingDetails.ControlStyle.Font.Size = 10;
            }

        }
    }
}