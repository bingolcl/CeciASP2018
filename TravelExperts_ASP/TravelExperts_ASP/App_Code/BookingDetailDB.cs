using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
//Author: Mohammad Adam Butt

namespace TravelExperts_ASP.App_Code
{
    [DataObject(true)]
    public static class BookingDetailDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<BookingDetail> GetBookingDetails(int BookingId)
        {
            List<BookingDetail> bookingDetails = new List<BookingDetail>(); // make an empty list
            BookingDetail bd; // reference to new state object
            // create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // create select command
            string selectString = "select b.[BookingId],[ItineraryNo],[TripStart],[TripEnd],[PkgName] as 'PackageName',[RegionName],[Description],[Destination]," +
                "[ClassName],[ProdName] as 'ProductName',[SupName] as 'SupplierName',[BasePrice] as 'ServicePrice',[PkgBasePrice] as 'PackagePrice'," +
                "CAST(isnull([PkgBasePrice], 0) * [TravelerCount] + [BasePrice] AS DECIMAL(10,2)) as 'Total' " +
                "from [Bookings] b " +
                "inner join [BookingDetails] d " +
                "on b.[BookingId] = d.[BookingId] " +
                "inner join [Products_Suppliers] ps " +
                "on ps.[ProductSupplierId] = d.[ProductSupplierId] " +
                "inner join [Products] p " +
                "on p.[ProductId] = ps.ProductId " +
                "inner join [Suppliers] s " +
                "on s.SupplierId = ps.SupplierId " +
                "inner join [Regions] r " +
                "on r.RegionId = d.[RegionId] " +
                "inner join [Classes] c " +
                "on c.ClassId = d.ClassId " +
                "left join [Packages] pkg " +
                "on pkg.PackageId = b.PackageId " +
                "where b.[BookingId] = @BookingId " +
                "order by[ProdName]";

            
            SqlCommand selectCommand = new SqlCommand(selectString, connection);
            selectCommand.Parameters.AddWithValue("@BookingId", BookingId);
            try
            {
                // open connection
                connection.Open();
                // run the select command and process the results adding states to the list
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())// process next row
                {
                    bd = new BookingDetail();
                    bd.BookingId = (int)reader["BookingId"];
                    bd.ItineraryNo = (double)reader["ItineraryNo"];
                    bd.TripStart = (DateTime)reader["TripStart"];
                    bd.TripEnd = (DateTime)reader["TripEnd"];
                    bd.PackageName = reader["PackageName"].ToString();
                    bd.RegionName = reader["RegionName"].ToString();
                    bd.Description = reader["Description"].ToString();
                    bd.Destination = reader["Destination"].ToString();
                    bd.ClassName = reader["ClassName"].ToString();
                    bd.ProductName = reader["ProductName"].ToString();
                    bd.SupplierName = reader["SupplierName"].ToString();
                    bd.PackagePrice = (decimal)reader["PackagePrice"];
                    bd.ServicePrice = (decimal)reader["ServicePrice"];
                    bd.Total = (decimal)reader["Total"];                   

                    bookingDetails.Add(bd);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex; // throw it to the form to handle
            }
            finally
            {
                connection.Close();
            }
            return bookingDetails;
        }

    }
}