using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Author Name: Harpreet Parmar
 * 
 */
namespace TravelExperts_fileVersion_
{
    public static class ProductSupplierDB
    {
        public static ProductSupplier GetProductSupplierById(int pId, int sId)//for getting product suppliers by id
        {
            ProductSupplier ps = new ProductSupplier();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();//for getting connection
            string sql =
                "SELECT ProductSupplierId, ProductId, SupplierId " +
                "FROM Products_Suppliers " +
               "WHERE ProductId = @pId and SupplierId =@sId";
            SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
            cmdSelect.Parameters.AddWithValue("@pId", pId);//assignd value with parameter
            cmdSelect.Parameters.AddWithValue("@sId", sId);//assign  with parameter
            try
            {
                dbConn.Open();
                SqlDataReader dbReader = cmdSelect.ExecuteReader();//read query
                while (dbReader.Read())//while reading product suppliers
                {
                    ps.ProductSupplierId = Convert.ToInt32(dbReader["ProductSupplierId"]);//convert product supplier id to int
                    ps.ProductId = Convert.ToInt32(dbReader["ProductId"]);//convert productid to int
                    ps.SupplierId = Convert.ToInt32(dbReader["SupplierId"]);//convert supplierid to int

                }
            }
            catch (SqlException ex)//throw exception
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();//closing connection
            }
            return ps;
        }
        public static void InsertProductSupplier(ProductSupplier nps)
        {
            SqlConnection dbConn = TravelExpertsDB.GetConnection();

            string sql = "INSERT Products_Suppliers (ProductId,SupplierId) " +
                        "VALUES (@npsPid, @npsSid)";
            SqlCommand cmdInsert = new SqlCommand(sql, dbConn);//get connection
            cmdInsert.Parameters.AddWithValue("@npsPid", nps.ProductId);//assign value with parameter
            cmdInsert.Parameters.AddWithValue("@npsSid", nps.SupplierId);//assign value with parameter
            try
            {
                dbConn.Open();//connection open
                cmdInsert.ExecuteNonQuery();//execute query
            }
            catch (SqlException ex)
            {
                throw ex;//throw exception
            }
            finally
            {
                dbConn.Close();//close connection
            }
        }

        public static void DeleteProductSupplier(ProductSupplier dps)
        {
            //DeletePackageDetailByProductSupplierId(dps);
            SqlConnection dbConn = TravelExpertsDB.GetConnection();//getting connection
            string sql =
                "DELETE FROM Products_Suppliers " +
                "WHERE ProductId = @pid and SupplierId = @sid";
            SqlCommand cmdDelete = new SqlCommand(sql, dbConn);
            cmdDelete.Parameters.AddWithValue("@pid", dps.ProductId.ToString());//assign value with parameter
            cmdDelete.Parameters.AddWithValue("@sid", dps.SupplierId.ToString());//assign value with parameter

            try
            {
                dbConn.Open();//open connection
                cmdDelete.ExecuteNonQuery();//execute query
            }
            catch (SqlException ex)
            {
                throw ex;//throw exception
            }
            finally
            {
                dbConn.Close();//close connection
            }
        }

        public static void DeletePackageDetail(ProductSupplier dps, Package pkg)
        {

            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "DELETE FROM Packages_Products_Suppliers " +
                "WHERE ProductSupplierId = @psid and PackageId = @sid";
            SqlCommand cmdDelete = new SqlCommand(sql, dbConn);
            cmdDelete.Parameters.AddWithValue("@psid", dps.ProductSupplierId);//assign value with parameter
            cmdDelete.Parameters.AddWithValue("@sid", pkg.PackageId);//assign value with parameter

            try
            {
                dbConn.Open();//open connection
                cmdDelete.ExecuteNonQuery();//execute  query
            }
            catch (SqlException ex)
            {
                throw ex;//throw exception
            }
            finally
            {
                dbConn.Close();//close connection
            }
        }
    }
}
