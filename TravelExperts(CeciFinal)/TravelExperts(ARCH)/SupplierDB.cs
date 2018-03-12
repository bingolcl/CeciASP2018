using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author: Mohammad Adam Butt

namespace TravelExperts_fileVersion_
{
    public static class SupplierDB
    {
        //receives all suppliers and returns a list
        public static List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "SELECT SupplierId, SupName " +
                "FROM Suppliers " +
                "ORDER BY SupplierId";
            SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
            try
            {
                dbConn.Open();
                SqlDataReader dbReader = cmdSelect.ExecuteReader();
                while (dbReader.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SupplierId = Convert.ToInt32(dbReader["SupplierId"]);
                    supplier.SupName = Convert.ToString(dbReader["SupName"]);
                    suppliers.Add(supplier);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return suppliers;
        }

        //receives product and returns a list of suppliers that are not in the current dgv
        public static List<Supplier> GetSuppliersNotInList(Product p)
        {
            List<Supplier> suppliers = new List<Supplier>();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "SELECT [SupplierId], [SupName] " +
                "FROM[Suppliers] s " +
                "where s.SupplierId " +
                "not in" +
                "(SELECT s.SupplierId " +
                "FROM Suppliers " +
                "inner join Products_Suppliers ps " +
                "ON s.SupplierId = ps.SupplierId " +
                "inner join Products p " +
                "on p.ProductId = ps.ProductId " +
                "where p.ProductId = @ProductId)"; 
            SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
            cmdSelect.Parameters.AddWithValue("@ProductId", p.ProductId);
            try
            {
                dbConn.Open();
                SqlDataReader dbReader = cmdSelect.ExecuteReader();
                while (dbReader.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SupplierId = Convert.ToInt32(dbReader["SupplierId"]);
                    supplier.SupName = Convert.ToString(dbReader["SupName"]);
                    suppliers.Add(supplier);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return suppliers;
        }

        //search through suppliers given search string, returns list of suppliers
        public static List<Supplier> GetSuppliersByName(string suppName)
        {
            List<Supplier> suppliers = new List<Supplier>();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "SELECT SupplierId, SupName " +
                "FROM Suppliers " +
                "WHERE SupName LIKE '%" + suppName + "%' ";
            SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
            try
            {
                dbConn.Open();
                SqlDataReader dbReader = cmdSelect.ExecuteReader();
                while (dbReader.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SupplierId = Convert.ToInt32(dbReader["SupplierId"]);
                    supplier.SupName = Convert.ToString(dbReader["SupName"]);
                    suppliers.Add(supplier);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return suppliers;
        }

        //receives supplier id and provides the supplier object
        public static Supplier GetSupplierById(int id)
        {
            Supplier supplier = new Supplier();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "SELECT SupplierId, SupName " +
                "FROM Suppliers " +
               "WHERE SupplierID = @SupplierID";
            SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
            cmdSelect.Parameters.AddWithValue("@SupplierID", id);
            try
            {
                dbConn.Open();
                SqlDataReader dbReader = cmdSelect.ExecuteReader();
                while (dbReader.Read())
                {
                    supplier.SupplierId = Convert.ToInt32(dbReader["SupplierId"]);
                    supplier.SupName = Convert.ToString(dbReader["SupName"]);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return supplier;
        }

        //find supplier by name returns supplier object
        public static Supplier GetSupplierByName(string n)
        {
            Supplier supplier = new Supplier();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "SELECT SupplierId, SupName " +
                "FROM Suppliers " +
               "WHERE SupName = @SupName";
            SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
            cmdSelect.Parameters.AddWithValue("@SupName", n);
            try
            {
                dbConn.Open();
                SqlDataReader dbReader = cmdSelect.ExecuteReader();
                while (dbReader.Read())
                {
                    supplier.SupplierId = Convert.ToInt32(dbReader["SupplierId"]);
                    supplier.SupName = Convert.ToString(dbReader["SupName"]);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return supplier;
        }

        //receives supplier object and inserts record into supplier table
        public static void InsertSupplier(Supplier ns)
        {
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql = "INSERT Suppliers (SupName) " +
                        "VALUES(@SupName)";
            SqlCommand cmdInsert = new SqlCommand(sql, dbConn);
            cmdInsert.Parameters.AddWithValue("@SupName", ns.SupName);
            try
            {
                dbConn.Open();
                cmdInsert.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        //receives old and new supplier object, updates a supplier record
        public static void UpdateSupplier(Supplier old_Supplier, Supplier new_Supplier)
        {
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql = "UPDATE Suppliers SET " +
                         " SupName = @NewSupName " +
                         "WHERE SupplierID = @SupplierID " +
                         " AND SupName = @OldSupName";   //concurrency checking
            SqlCommand cmdUpdate = new SqlCommand(sql, dbConn);
            cmdUpdate.Parameters.AddWithValue("@NewSupName", new_Supplier.SupName);
            cmdUpdate.Parameters.AddWithValue("@SupplierID", new_Supplier.SupplierId);
            cmdUpdate.Parameters.AddWithValue("@OldSupName", old_Supplier.SupName);
            try
            {
                dbConn.Open();
                cmdUpdate.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        //receives supplier object, deletes supplier record
        public static void DeleteSupplier(Supplier ds)
        {
            DeleteSupplierContactsBySupplier(ds);
            DeleteProductSuppliersBySupplier(ds); // Delete links first
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "DELETE FROM Suppliers " +
                "WHERE SupplierID = @SupplierID " +
                " AND SupName = @SupName"; //concurrency checking
            SqlCommand cmdDelete = new SqlCommand(sql, dbConn);
            cmdDelete.Parameters.AddWithValue("@SupplierID", ds.SupplierId);
            cmdDelete.Parameters.AddWithValue("@SupName", ds.SupName);
            try
            {
                dbConn.Open();
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        //receives supplier object and deletes supplier contact record
        public static void DeleteProductSuppliersBySupplier(Supplier s)
        {            
            DeletePackageProductSuppliersBySupplier(s);// Delete links first
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "DELETE FROM Products_Suppliers " +
                "WHERE SupplierId = @SupplierID";
            SqlCommand cmdDelete = new SqlCommand(sql, dbConn);
            cmdDelete.Parameters.AddWithValue("@SupplierID", s.SupplierId);

            try
            {
                dbConn.Open();
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }
        //delete supplier contacts given supplier ID, needs to be deleted before supplier can be removed
        public static void DeleteSupplierContactsBySupplier(Supplier s)
        {            
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "DELETE FROM SupplierContacts " +
                "WHERE SupplierId = @SupplierID";
            SqlCommand cmdDelete = new SqlCommand(sql, dbConn);
            cmdDelete.Parameters.AddWithValue("@SupplierID", s.SupplierId);

            try
            {
                dbConn.Open();
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        //receives supplier object, deletes record in pps table 
        public static void DeletePackageProductSuppliersBySupplier(Supplier s)
        {
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "DELETE pps " +
                "FROM " +
                "[Packages_Products_Suppliers] pps " +
                "inner join[Products_Suppliers] ps " +
                "ON pps.ProductSupplierId = ps.ProductSupplierId " +
                "INNER JOIN[Suppliers] s " +
                "ON s.SupplierId = ps.SupplierId " +
                "WHERE ps.SupplierId = @SupplierID";
            SqlCommand cmdDelete = new SqlCommand(sql, dbConn);
            cmdDelete.Parameters.AddWithValue("@SupplierID", s.SupplierId);

            try
            {
                dbConn.Open();
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        //receives supplier object, returns corresponding list of products
        public static List<Product> GetProductSuppliersBySupplier(Supplier s)
        {
            if (s == null)
                //throw new Exception("null passed to supplier");
                return null;
            else
            {
                List<Product> products = new List<Product>();
                SqlConnection dbConn = TravelExpertsDB.GetConnection();
                string sql =
                    "SELECT p.ProductId, p.ProdName " +
                    "FROM Products p " +
                    "inner join Products_Suppliers ps " +
                    "ON p.ProductId = ps.ProductId " +
                    "inner join Suppliers s " +
                    "ON s.SupplierId = ps.SupplierId " +
                    "WHERE s.SupplierId = @SupplierID ";
                SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
                cmdSelect.Parameters.AddWithValue("@SupplierID", s.SupplierId);
                try
                {
                    dbConn.Open();
                    SqlDataReader dbReader = cmdSelect.ExecuteReader();
                    while (dbReader.Read())
                    {
                        Product product = new Product();
                        product.ProductId = Convert.ToInt32(dbReader["ProductId"]);
                        product.ProdName = Convert.ToString(dbReader["ProdName"]);
                        products.Add(product);
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    dbConn.Close();
                }
                return products;
            }
        }


    }
}
