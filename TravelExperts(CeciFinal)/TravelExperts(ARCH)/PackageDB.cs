using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Travel Experts
 * Date: Jan 22, 2017
 * Author: Cecilia Zhang
 * Purpose: Define packageDB methods.
 */

namespace TravelExperts_fileVersion_
{
    public static class PackageDB
    {
        //return a list of all package data from packages table in the database
        public static List<Package> GetAllPackages()
        {
            List<Package> packages = new List<Package>();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "SELECT PackageId, PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission " +
                "FROM Packages " +
                "ORDER BY PackageId";
            SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
            try
            {
                dbConn.Open();
                SqlDataReader dbReader = cmdSelect.ExecuteReader();
                while (dbReader.Read())
                {
                    Package package = new Package();
                    package.PackageId = Convert.ToInt32(dbReader["PackageId"]);
                    package.PkgName = Convert.ToString(dbReader["PkgName"]);
                    package.PkgStartDate = dbReader["PkgStartDate"] == DBNull.Value ? null : (DateTime?)dbReader["PkgStartDate"];
                    package.PkgEndDate = dbReader["PkgEndDate"] == DBNull.Value ? null : (DateTime?)(dbReader["PkgEndDate"]);
                    package.PkgDesc = Convert.ToString(dbReader["PkgDesc"] == DBNull.Value ? null : dbReader["PkgDesc"]);
                    package.PkgBasePrice = Convert.ToDecimal(dbReader["PkgBasePrice"]);
                    package.PkgAgencyCommission = dbReader["PkgAgencyCommission"] == DBNull.Value ? null : (decimal?) dbReader["PkgAgencyCommission"];
                    packages.Add(package);
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
            return packages;
        }

        //return a list of PackageProductSupplier data for the given package
        public static List<PackageProductSupplier> GetProductSuppliersByPackage(Package pkg)
        {
            if (pkg == null)
                return null;
            else
            {
                List<PackageProductSupplier> ppss = new List<PackageProductSupplier>();
                SqlConnection dbConn = TravelExpertsDB.GetConnection();
                string sql =
                    "SELECT pk.PackageId, pk.PkgName, pps.ProductSupplierId, p.ProdName, s.SupName " +
                    "FROM Packages pk " +
                    "inner join Packages_Products_Suppliers pps " +
                    "ON pps.PackageId = pk.PackageId " +
                    "inner join Products_Suppliers ps " +
                    "ON pps.ProductSupplierId = ps.ProductSupplierId " +
                    "inner join Products p " +
                    "ON p.ProductId = ps.ProductId " +
                    "inner join Suppliers s " +
                    "ON s.SupplierId = ps.SupplierId " +
                    "WHERE pk.PackageId = @Package " +
                    "ORDER BY p.ProdName";
                SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
                cmdSelect.Parameters.AddWithValue("@Package", pkg.PackageId);
                try
                {
                    dbConn.Open();
                    SqlDataReader dbReader = cmdSelect.ExecuteReader();
                    while (dbReader.Read())
                    {
                        PackageProductSupplier pps = new PackageProductSupplier();
                        pps.PackageId = Convert.ToInt32(dbReader["PackageId"]);
                        pps.ProductSupplierId = Convert.ToInt32(dbReader["ProductSupplierId"]);
                        pps.PkgName = Convert.ToString(dbReader["PkgName"]);
                        pps.ProdName = Convert.ToString(dbReader["ProdName"]);
                        pps.SupName = Convert.ToString(dbReader["SupName"]);

                        ppss.Add(pps);
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
                return ppss;
            }
        }

        //find all packages that pkgName has the given string 
        public static List<Package> GetPackageByName(string pkgName)
        {
            List<Package> packages = new List<Package>();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "SELECT PackageId, PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission " +
                "FROM Packages " +
                "WHERE PkgName LIKE '%" + pkgName + "%' ";
            SqlCommand cmdSelect = new SqlCommand(sql, dbConn);            
            try
            {
                dbConn.Open();
                SqlDataReader dbReader = cmdSelect.ExecuteReader();
                while (dbReader.Read())
                {
                    Package package = new Package();
                    package.PackageId = Convert.ToInt32(dbReader["PackageId"]);
                    package.PkgName = Convert.ToString(dbReader["PkgName"]);
                    package.PkgStartDate = dbReader["PkgStartDate"] == DBNull.Value ? null : (DateTime?)dbReader["PkgStartDate"];
                    package.PkgEndDate = dbReader["PkgEndDate"] == DBNull.Value ? null : (DateTime?)(dbReader["PkgEndDate"]);
                    package.PkgDesc = Convert.ToString(dbReader["PkgDesc"] == DBNull.Value ? null : dbReader["PkgDesc"]);
                    package.PkgBasePrice = Convert.ToDecimal(dbReader["PkgBasePrice"]);
                    package.PkgAgencyCommission = dbReader["PkgAgencyCommission"] == DBNull.Value ? null : (decimal?)dbReader["PkgAgencyCommission"];
                    packages.Add(package);
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
            return packages;
        }

        //find package by the given id
        public static Package GetPackageById(int id)
        {
            Package package = new Package();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "SELECT PackageId, PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission " +
                "FROM Packages " +
                "WHERE PackageId = @ID ";
            SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                dbConn.Open();
                SqlDataReader dbReader = cmdSelect.ExecuteReader();
                while (dbReader.Read())
                {
                    package.PackageId = Convert.ToInt32(dbReader["PackageId"]);
                    package.PkgName = Convert.ToString(dbReader["PkgName"]);
                    package.PkgStartDate = dbReader["PkgStartDate"] == DBNull.Value ? null : (DateTime?)dbReader["PkgStartDate"];
                    package.PkgEndDate = dbReader["PkgEndDate"] == DBNull.Value ? null : (DateTime?)(dbReader["PkgEndDate"]);
                    package.PkgDesc = Convert.ToString(dbReader["PkgDesc"] == DBNull.Value ? null : dbReader["PkgDesc"]);
                    package.PkgBasePrice = Convert.ToDecimal(dbReader["PkgBasePrice"]);
                    package.PkgAgencyCommission = dbReader["PkgAgencyCommission"] == DBNull.Value ? null : (decimal?)dbReader["PkgAgencyCommission"];
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
            return package;
        }

        //Insert a new package record into the package table
        public static void InsertPackage(Package np)
        {
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql = "INSERT Packages (PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission) " +
                         "VALUES (@PkgName, @PkgStartDate, @PkgEndDate, @PkgDesc, @PkgBasePrice, @PkgAgencyCommission)";
            SqlCommand cmdInsert = new SqlCommand(sql, dbConn);
            cmdInsert.Parameters.AddWithValue("@PkgName", np.PkgName);
            cmdInsert.Parameters.AddWithValue("@PkgStartDate", (object)np.PkgStartDate ?? DBNull.Value);
            cmdInsert.Parameters.AddWithValue("@PkgEndDate", (object)np.PkgEndDate ?? DBNull.Value);
            cmdInsert.Parameters.AddWithValue("@PkgDesc", (object)np.PkgDesc ?? DBNull.Value);
            cmdInsert.Parameters.AddWithValue("@PkgBasePrice", np.PkgBasePrice);
            cmdInsert.Parameters.AddWithValue("@PkgAgencyCommission", (object)np.PkgAgencyCommission ?? DBNull.Value);
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

        //insert a new record into the Packages_Products_Suppliers table
        public static void InsertDetail(Product p, Supplier s, Package pkg)
        {
            SqlConnection dbConn = TravelExpertsDB.GetConnection();            
            string sql = "INSERT INTO [Packages_Products_Suppliers] " +
                         "([PackageId], [ProductSupplierId]) " +
                         "VALUES (@PackageID, (SELECT [ProductSupplierId] " +
                         "FROM [Products_Suppliers] " +
                         "WHERE [ProductId] = @ProductID AND [SupplierId] = @SupplierID))";
            SqlCommand cmdInsert = new SqlCommand(sql, dbConn);
            cmdInsert.Parameters.AddWithValue("@ProductID", p.ProductId);
            cmdInsert.Parameters.AddWithValue("@SupplierID", s.SupplierId);
            cmdInsert.Parameters.AddWithValue("@PackageID", pkg.PackageId);

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

        //update the package data with concurrency check
        public static bool UpdatePackage(Package op, Package np)
        {
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql = "UPDATE Packages " +
                         "SET PkgName = @nPkgName" +
                         ", PkgStartDate = @nPkgStartDate" +
                         ", PkgEndDate = @nPkgEndDate" +
                         ", PkgDesc = @nPkgDesc" +
                         ", PkgBasePrice = @nPkgBasePrice" +
                         ", PkgAgencyCommission = @nPkgAgencyCommission " +
                         "WHERE PackageId = @oPackageId " +
                         "AND PkgName = @oPkgName " + //check concurrency
                         "AND (PkgStartDate = @oPkgStartDate OR " +
                         "PkgStartDate IS NULL AND @oPkgStartDate IS NULL) " +
                         "AND (PkgEndDate = @oPkgEndDate OR " +
                         "PkgEndDate IS NULL AND @oPkgEndDate IS NULL) " +
                         "AND (PkgDesc = @oPkgDesc OR " +
                         "PkgDesc IS NULL AND @oPkgDesc IS NULL) " +
                         "AND PkgBasePrice = @oPkgBasePrice " +
                         "AND (PkgAgencyCommission = @oPkgAgencyCommission OR " +
                         "PkgAgencyCommission IS NULL AND @oPkgAgencyCommission IS NULL)";

            SqlCommand cmdUpdate = new SqlCommand(sql, dbConn);
            cmdUpdate.Parameters.AddWithValue("@nPkgName", np.PkgName);
            cmdUpdate.Parameters.AddWithValue("@nPkgStartDate", (object)np.PkgStartDate ?? DBNull.Value);
            cmdUpdate.Parameters.AddWithValue("@nPkgEndDate", (object)np.PkgEndDate ?? DBNull.Value);
            cmdUpdate.Parameters.AddWithValue("@nPkgDesc", (object)np.PkgDesc ?? DBNull.Value);
            cmdUpdate.Parameters.AddWithValue("@nPkgBasePrice", np.PkgBasePrice);
            cmdUpdate.Parameters.AddWithValue("@nPkgAgencyCommission", (object)np.PkgAgencyCommission ?? DBNull.Value);
            cmdUpdate.Parameters.AddWithValue("@oPackageId", op.PackageId);
            cmdUpdate.Parameters.AddWithValue("@oPkgName", op.PkgName);
            cmdUpdate.Parameters.AddWithValue("@oPkgStartDate", (object)op.PkgStartDate ?? DBNull.Value);
            cmdUpdate.Parameters.AddWithValue("@oPkgEndDate", (object)op.PkgEndDate ?? DBNull.Value);
            cmdUpdate.Parameters.AddWithValue("@oPkgDesc", (object)op.PkgDesc ?? DBNull.Value);
            cmdUpdate.Parameters.AddWithValue("@oPkgBasePrice", op.PkgBasePrice);
            cmdUpdate.Parameters.AddWithValue("@oPkgAgencyCommission", (object)op.PkgAgencyCommission ?? DBNull.Value);

            try
            {
                dbConn.Open();
                int count = cmdUpdate.ExecuteNonQuery(); // returns number of rows effected
                if (count > 0)
                    return true;
                else
                    return false;
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

        //delete the package record from package table
        public static void DeletePackage(Package dp)
        {
            DeletePackagesProductsSuppliersByPackage(dp); // Delete links first
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "DELETE FROM Packages " +
                "WHERE PackageId = @PackageId " +
                "AND PkgName = @oPkgName " + //check concurrency
                "AND (PkgStartDate = @oPkgStartDate OR " +
                "PkgStartDate IS NULL AND @oPkgStartDate IS NULL) " +
                "AND (PkgEndDate = @oPkgEndDate OR " +
                "PkgEndDate IS NULL AND @oPkgEndDate IS NULL) " +
                "AND (PkgDesc = @oPkgDesc OR " +
                "PkgDesc IS NULL AND @oPkgDesc IS NULL) " +
                "AND PkgBasePrice = @oPkgBasePrice " +
                "AND (PkgAgencyCommission = @oPkgAgencyCommission OR " +
                "PkgAgencyCommission IS NULL AND @oPkgAgencyCommission IS NULL)";
            SqlCommand cmdDelete = new SqlCommand(sql, dbConn);
            cmdDelete.Parameters.AddWithValue("@PackageId", dp.PackageId);
            cmdDelete.Parameters.AddWithValue("@oPkgName", dp.PkgName);
            cmdDelete.Parameters.AddWithValue("@oPkgStartDate", (object)dp.PkgStartDate ?? DBNull.Value);
            cmdDelete.Parameters.AddWithValue("@oPkgEndDate", (object)dp.PkgEndDate ?? DBNull.Value);
            cmdDelete.Parameters.AddWithValue("@oPkgDesc", (object)dp.PkgDesc ?? DBNull.Value);
            cmdDelete.Parameters.AddWithValue("@oPkgBasePrice", dp.PkgBasePrice);
            cmdDelete.Parameters.AddWithValue("@oPkgAgencyCommission", (object)dp.PkgAgencyCommission ?? DBNull.Value);
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

        //delete data from Packages_Products_Suppliers for the given package
        public static void DeletePackagesProductsSuppliersByPackage(Package p)
        {
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "DELETE FROM Packages_Products_Suppliers " +
                "WHERE PackageId = @PackageId";
            SqlCommand cmdDelete = new SqlCommand(sql, dbConn);
            cmdDelete.Parameters.AddWithValue("@PackageId", p.PackageId);

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

        //find and return a list of prodcuts that is not in the Packages_Products_Suppliers table for the given package
        public static List<Product> GetProductsNotInDetails(Package pkg)
        {
            List<Product> products = new List<Product>();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string sql =
                "SELECT[ProductId], [ProdName] " +
                "FROM[Products] " +
                "where ProductId " +
                "not in " +
                "(SELECT p.ProductId " +
                "FROM Packages pk " +
                "inner join Packages_Products_Suppliers pps " +
                "ON pps.PackageId = pk.PackageId " +
                "inner join Products_Suppliers ps " +
                "ON pps.ProductSupplierId = ps.ProductSupplierId " +
                "inner join Products p " +
                "ON p.ProductId = ps.ProductId " +
                "inner join Suppliers s " +
                "ON s.SupplierId = ps.SupplierId " +
                "WHERE pk.PackageId = @PackageId)";
            SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
            cmdSelect.Parameters.AddWithValue("@PackageId", pkg.PackageId);
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

        //find and return a list of suppliers that is not in the Packages_Products_Suppliers table for the given package and the given product
        public static List<Supplier> GetSuppliersByProductNotInDetails(Product p, Package pkg)
        {
            if (p == null)
                //throw new Exception("null passed to supplier");
                return null;
            else
            {
                List<Supplier> suppliers = new List<Supplier>();
                SqlConnection dbConn = TravelExpertsDB.GetConnection();
                string sql =
                    "SELECT s.SupplierId, s.SupName " +
                    "FROM Suppliers s " +
                    "inner join Products_Suppliers ps " +
                    "on ps.SupplierId = s.SupplierId " +
                    "WHERE ps.ProductId = @ProductId " +
                    "and s.SupplierId " +
                    "not in " +
                    "(SELECT s.SupplierId " +
                    "FROM Packages pk " +
                    "inner join Packages_Products_Suppliers pps " +
                    "ON pps.PackageId = pk.PackageId " +
                    "inner join Products_Suppliers ps " +
                    "ON pps.ProductSupplierId = ps.ProductSupplierId " +
                    "inner join Products p " +
                    "ON p.ProductId = ps.ProductId " +
                    "inner join Suppliers s " +
                    "ON s.SupplierId = ps.SupplierId " +
                    "WHERE pk.PackageId = @PackageId " +
                    "and p.ProductId = @ProductId)";
                SqlCommand cmdSelect = new SqlCommand(sql, dbConn);
                cmdSelect.Parameters.AddWithValue("@PackageId", pkg.PackageId);
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
    }
}
