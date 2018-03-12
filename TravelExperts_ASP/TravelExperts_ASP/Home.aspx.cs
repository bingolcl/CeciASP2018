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
 * Purpose: Home page with greeting banner
 */

namespace TravelExperts_ASP
{
    public partial class Home : System.Web.UI.Page
    {
        //set up the greeting banner based on the login status
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerId"] != null)
            {
                lblName.Text = " " + Session["CustFirstName"].ToString();
            }
            else
            {
                lblName.Text = " Everyone";
            }

        }
        
    }
}