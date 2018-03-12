using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Author: Mohammad Adam Butt

namespace TravelExperts_ASP.App_Code
{
    public class Booking
    {
        public Booking() { }

        public int BookingId { get; set; }
       
        public string BookingNo { get; set; }

        public DateTime BookingDate { get; set; }

        public string PackageName { get; set; }

        public string TripType { get; set; }

        public double TravelerCount { get; set; }

        public decimal PackagePrice { get; set; }

        public decimal ServicePrice { get; set; }

        public decimal Total { get; set; }
        
    }
}