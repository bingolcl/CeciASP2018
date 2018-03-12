using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
//Author: Mohammad Adam Butt

namespace TravelExperts_ASP.App_Code
{
    [DataObject(true)]
    public static class BookingDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Booking> GetBookings(int CustomerId)
        {
            List<Booking> bookings = new List<Booking>(); // make an empty list
            Booking book; // reference to new state object
            // create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // create select command
            string selectString = "select b.[BookingId],[BookingNo],[BookingDate]," +
                                  "isnull([PkgName],'not selected') as 'PackageName',[TTName] as 'TripType',[TravelerCount]," +
                                  "CAST(isnull([PkgBasePrice],0) AS DECIMAL(10,2)) as 'PackagePrice'," +
                                  "[BasePrice] as 'ServicePrice'," +
                                  "CAST(isnull([PkgBasePrice], 0) * [TravelerCount] + [BasePrice] AS DECIMAL(10,2)) as 'Total' " +
                                  "from [Bookings] b " +
                                  "inner join [TripTypes] t " +
                                  "on t.TripTypeId = b.TripTypeId " +
                                  "left join [Packages] pkg " +
                                  "on pkg.PackageId = b.PackageId " +
                                  "inner join [BookingDetails] d " +
                                  "on b.[BookingId] = d.[BookingId] " +
                                  "where[CustomerId] = @CustomerId " +
                                  "order by[BookingDate] desc";
            SqlCommand selectCommand = new SqlCommand(selectString, connection);
            selectCommand.Parameters.AddWithValue("@CustomerId", CustomerId);
            try
            {
                // open connection
                connection.Open();
                // run the select command and process the results adding states to the list
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())// process next row
                {
                    book = new Booking();
                    book.BookingId = (int)reader["BookingId"];
                    book.BookingNo = reader["BookingNo"].ToString();
                    book.PackageName = reader["PackageName"].ToString();
                    book.TripType = reader["TripType"].ToString();
                    book.TravelerCount = (double)reader["TravelerCount"];
                    book.BookingDate = (DateTime)reader["BookingDate"];
                    book.PackagePrice = (decimal)reader["PackagePrice"];
                    book.ServicePrice = (decimal)reader["ServicePrice"];
                    book.Total = (decimal)reader["Total"];

                    bookings.Add(book);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex; // throw it to the form to handle
            }
            finally
            {
                connection.Close();
            }
            return bookings;
        }
    }
}