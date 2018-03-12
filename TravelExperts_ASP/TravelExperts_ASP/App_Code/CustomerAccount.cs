using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*Author Name: Cecilia*/


namespace TravelExperts_ASP
{
    public class CustomerAccount
    {
        public CustomerAccount() { }

        public int CustomerId { get; set; } //getter and setter for CustomerId

        public string CustFirstName { get; set; }//getter and setter for CustFirstName

        public string CustLastName { get; set; }//getter and setter for CustLastName

        public string CustAddress { get; set; }//getter and setter for CustAddress

        public string CustCity { get; set; }//getter and setter for CustCity

        public string CustProv { get; set; } //getter and setter for CustProv

        public string CustPostal { get; set; } //getter and setter for CustPostal

        public string CustCountry { get; set; } //getter and setter for CustCountry

        public string CustHomePhone { get; set; }//getter and setter for CustHomePhone

        public string CustBusPhone { get; set; }//getter and setter for CustBusPhone

        public string CustEmail { get; set; }//getter and setter for CustEmail

        public string CustUserName { get; set; }//getter and setter for CustUserName

        public string CustPassword { get; set; }//getter and setter for CustPassword

    }
}