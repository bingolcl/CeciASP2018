

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/*Author Name:Harpreet Parmar,Cecilia, Riley
 *Date:20 January.2018
 * Purpose Of Application: Create a user registration form for users
 */


namespace TravelExperts_ASP
{
    [DataObject(true)]
    public static class CustomerAccountDB
    {
        [DataObjectMethod(DataObjectMethodType.Insert)]

        public static int InsertNewAccount(CustomerAccount newAccount)//for insert new Customers
        {
            int userId = 0;//Variable for hold userId
            using (SqlConnection dbConn = TravelExpertsDB.GetConnection())//for getting connection
            {
                using (SqlCommand cmd = new SqlCommand("Insert_CustomerAccount"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustFirstName", newAccount.CustFirstName);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustLastName", newAccount.CustLastName);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustAddress", newAccount.CustAddress);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustCity", newAccount.CustCity);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustProv", newAccount.CustProv);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustPostal", newAccount.CustPostal);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustCountry", newAccount.CustCountry);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustHomePhone", newAccount.CustHomePhone);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustBusPhone", newAccount.CustBusPhone);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustEmail", newAccount.CustEmail);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustUserName", newAccount.CustUserName);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustPassword", newAccount.CustPassword);//assign value to parameter

                        cmd.Connection = dbConn;
                        dbConn.Open();//open connection
                        userId = Convert.ToInt32(cmd.ExecuteScalar());//convert userId to int
                        dbConn.Close();//close connection
                    }
                }

                return userId;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static CustomerAccount GetAccountByID(int CustID)
        {
            CustomerAccount ca = new CustomerAccount();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();//for getting connection
            string sql = "select * from CustomerAccounts where CustomerId = @CustomerId";
            SqlCommand cmd = new SqlCommand(sql, dbConn);//creating connection
            cmd.Parameters.AddWithValue("CustomerId", CustID);//assign value to parameter
            dbConn.Open();
            SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (dbReader.Read())
            {
                ca.CustUserName = Convert.ToString(dbReader["CustUserName"]); //convert user name to string
                ca.CustFirstName = Convert.ToString(dbReader["CustFirstName"]);//convert CustFirstName to string
                ca.CustLastName = Convert.ToString(dbReader["CustLastName"]);//convert CustLastName to string
                ca.CustAddress = Convert.ToString(dbReader["CustAddress"]);//convert CustAddress to string
                ca.CustCity = Convert.ToString(dbReader["CustCity"]);//convert CustCity to string
                ca.CustProv = Convert.ToString(dbReader["CustProv"]);//convert CustProv to string
                ca.CustPostal = Convert.ToString(dbReader["CustPostal"]);//convert CustPostal to string
                ca.CustCountry = Convert.ToString(dbReader["CustCountry"]);//convert CustCountry to string
                ca.CustHomePhone = Convert.ToString(dbReader["CustHomePhone"]);//convert CustHomePhone to string
                ca.CustBusPhone = Convert.ToString(dbReader["CustBusPhone"]);//convert CustBusPhone to string
                ca.CustEmail = Convert.ToString(dbReader["CustEmail"]);//convert CustEmail to string
            }
            dbConn.Close();

            return ca;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]

        public static int UpdateAccount(CustomerAccount ca)
        {
            int userId = 0;//variable for hold userid
            using (SqlConnection dbConn = TravelExpertsDB.GetConnection())//getting connection
            {
                using (SqlCommand cmd = new SqlCommand("Update_CustomerAccount"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", ca.CustomerId);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustFirstName", ca.CustFirstName);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustLastName", ca.CustLastName);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustAddress", ca.CustAddress);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustCity", ca.CustCity);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustProv", ca.CustProv);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustPostal", ca.CustPostal);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustCountry", ca.CustCountry);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustHomePhone", ca.CustHomePhone);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustBusPhone", ca.CustBusPhone);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustEmail", ca.CustEmail);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustUserName", ca.CustUserName);//assign value to parameter
                        cmd.Parameters.AddWithValue("@CustPassword", ca.CustPassword);//assign value to parameter

                        cmd.Connection = dbConn;
                        dbConn.Open();//open connection
                        userId = Convert.ToInt32(cmd.ExecuteScalar());//convert userid to int
                        dbConn.Close();//close connection
                    }
                }

                return userId;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static CustomerAccount UserChecker(CustomerAccount Cust)
        {
            CustomerAccount ca = new CustomerAccount();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();//get connection
            string sql = "select * from CustomerAccounts where CustUserName=@username";
            SqlCommand cmd = new SqlCommand(sql, dbConn);
            cmd.Parameters.AddWithValue("@username", Cust.CustUserName);//assign value to parameter
            dbConn.Open();
            SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (dbReader.Read())
            {
                if (dbReader["CustomerId"] != null)//checks if there any value
                {
                    ca.CustFirstName = Convert.ToString(dbReader["CustFirstName"]);//convert CustFirstName to string
                    ca.CustomerId = Convert.ToInt32(dbReader["CustomerId"]);//convert CustId to int
                    ca.CustPassword = Convert.ToString(dbReader["CustPassword"]);
                }
            }
            dbConn.Close();//close connection

            return ca;
        }


    }
}