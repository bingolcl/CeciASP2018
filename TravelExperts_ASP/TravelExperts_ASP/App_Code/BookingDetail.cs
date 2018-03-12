using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Author: Mohammad Adam Butt

namespace TravelExperts_ASP.App_Code
{
    public class BookingDetail
    {
        public BookingDetail() { }

        public int BookingId { get; set; }

        public double ItineraryNo { get; set; }

        public DateTime TripStart { get; set; }

        public DateTime TripEnd { get; set; }

        public string PackageName { get; set; }

        public string RegionName { get; set; }

        public string Description { get; set; }

        public string Destination { get; set; }

        public string ClassName { get; set; }

        public string ProductName { get; set; }

        public string SupplierName { get; set; }

        public decimal ServicePrice { get; set; }

        public decimal PackagePrice { get; set; }

        public decimal Total { get; set; }
    }
}