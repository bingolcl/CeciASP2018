
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Author Riley Hobberstad

namespace TravelExperts_fileVersion_
{
    public static class ProductDB
    {
        public static List<Product> GetAllProducts()
        {//load all products from database
            List<Product> products = new List<Product>();//set up a list
            SqlConnection dbConn = TravelExpertsDB.GetConnection(); //get database connection
            string sql =
                "SELECT ProductId, ProdName " +
                "FROM Products " +
                "ORDER BY ProductId"; //get products and product ids
            SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
            try
            {
                dbConn.Open();
                SqlDataReader dbReader = cmdSelect.ExecuteReader();
                while (dbReader.Read())
                {
                    Product product = new Product();//make them readable adn set them in the list
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

        public static List<Product> GetProductsByName(string prodName)
        {//load all products by name from database
            List<Product> products = new List<Product>();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "SELECT ProductId, ProdName " +
                "FROM Products " +
                "WHERE ProdName LIKE '%" + prodName + "%' ";
            SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
            try
            {
                dbConn.Open();
                SqlDataReader dbReader = cmdSelect.ExecuteReader();
                while (dbReader.Read())
                {
                    Product product = new Product();//make them readable and set them in the list
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

        public static Product GetProductById(int id)
        {// load all products by name from database
            Product product = new Product();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "SELECT ProductId, ProdName " +
                "FROM Products " +
                "WHERE ProductId = @ProductId";
            SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
            cmdSelect.Parameters.AddWithValue("@ProductId", id);
            try
            {
                dbConn.Open();
                SqlDataReader dbReader = cmdSelect.ExecuteReader();
                while (dbReader.Read())
                {//make them readable and set them in the list
                    product.ProductId = Convert.ToInt32(dbReader["ProductId"]);
                    product.ProdName = Convert.ToString(dbReader["ProdName"]);
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
            return product;
        }

        public static Product GetProductByName(string n)
        {//load all products by name from database
            Product product = new Product();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "SELECT ProductId, ProdName " +
                "FROM Products " +
                "WHERE ProdName = @ProdName";
            SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
            cmdSelect.Parameters.AddWithValue("@ProdName", n);
            try
            {
                dbConn.Open();
                SqlDataReader dbReader = cmdSelect.ExecuteReader();
                while (dbReader.Read())
                {//make them readable and set them in the list
                    product.ProductId = Convert.ToInt32(dbReader["ProductId"]);
                    product.ProdName = Convert.ToString(dbReader["ProdName"]);
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
            return product;
        }

        public static void InsertProduct(Product np)
        {//load all products by name from database
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql = "INSERT Products (ProdName) " +
                         "VALUES (@ProdName)";
            SqlCommand cmdInsert = new SqlCommand(sql, dbConn);//insert values 
            cmdInsert.Parameters.AddWithValue("@ProdName", np.ProdName);

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

        public static void UpdateProduct(Product ep, Product op)
        {
            //load all products by name from database
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql = "UPDATE Products " +
                          "SET ProdName = @nProdName " +
                         "WHERE ProductId = @ProductId " +
                         "AND ProdName = @OldProdName";//update the products where the ID is the same
            SqlCommand cmdUpdate = new SqlCommand(sql, dbConn);
            cmdUpdate.Parameters.AddWithValue("@nProdName", ep.ProdName);
            cmdUpdate.Parameters.AddWithValue("@OldProdName", op.ProdName);
            cmdUpdate.Parameters.AddWithValue("@ProductID", op.ProductId);
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

        public static void DeleteProduct(Product dp)
        {
            DeleteProductSuppliersByProduct(dp); // Delete links first
            //load all products by name from database
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "DELETE FROM Products " +
                "WHERE ProductId = @ProductID " +
                "AND ProdName = @ProdName"; //delete the products withe the same ID
            SqlCommand cmdDelete = new SqlCommand(sql, dbConn);
            cmdDelete.Parameters.AddWithValue("@ProductID", dp.ProductId);
            cmdDelete.Parameters.AddWithValue("@ProdName", dp.ProdName);

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

        public static void DeleteProductSuppliersByProduct(Product p)
        {
            DeletePackageProductSuppliersByProduct(p); // Delete links first
            //load all products by name from database
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "DELETE FROM Products_Suppliers " +
                "WHERE ProductId = @ProductId ";//delete the product from the supplier
            SqlCommand cmdDelete = new SqlCommand(sql, dbConn);
            cmdDelete.Parameters.AddWithValue("@ProductId", p.ProductId);
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

        public static void DeletePackageProductSuppliersByProduct(Product p)
        {//load all products by name from database
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "DELETE pps " +
                "FROM " +
                "[Packages_Products_Suppliers] pps " +
                "inner join[Products_Suppliers] ps " +
                "ON pps.ProductSupplierId = ps.ProductSupplierId " +
                "INNER JOIN[Suppliers] s " +
                "ON s.SupplierId = ps.SupplierId " +
                "WHERE ps.ProductId = @ProductId";//delete the product package supplier
            SqlCommand cmdDelete = new SqlCommand(sql, dbConn);
            cmdDelete.Parameters.AddWithValue("@ProductId", p.ProductId);

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

        public static List<Supplier> GetProductSuppliersByProduct(Product p)
        {
            if (p == null)
                return null;
            else
            {//call the suppliers list
                List<Supplier> suppliers = new List<Supplier>();
                SqlConnection dbConn = TravelExpertsDB.GetConnection();
                string sql =
                    "SELECT s.SupplierId, s.SupName " +
                    "FROM Suppliers s " +
                    "inner join Products_Suppliers ps " +
                    "ON s.SupplierId = ps.SupplierId " +
                    "inner join Products p " +
                    "ON p.ProductId = ps.ProductId " +
                    "WHERE p.ProductId = @ProductId";//get teh suppliers that carry the product by id
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
        }

        public static List<Product> GetProductsNotInList(Supplier s)
        {//load products from database
            List<Product> products = new List<Product>();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "SELECT [ProductId], [ProdName] " +
                "FROM[Products] p " +
                "where p.ProductId " +
                "not in " +
                "(SELECT p.ProductId " +
                "FROM Products " +
                "inner join Products_Suppliers ps " +
                "ON p.ProductId = ps.ProductId " +
                "inner join Suppliers s " +
                "ON s.SupplierId = ps.SupplierId " +
                "WHERE s.SupplierId = @SupplierId)";//find a product that doesn't have a supplier
            SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
            cmdSelect.Parameters.AddWithValue("@SupplierId", s.SupplierId);
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