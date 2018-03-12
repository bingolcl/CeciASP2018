using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Auther name:Harpreet Parmar
 * Date:January17:January.2018
 * Purpose Of Application:Creating user friendy website for travel experts
 */

namespace TravelExperts_fileVersion_
{
    public partial class frmEditProductSuppliersForSelectedSupplier : Form
    {
        List<Product> editedProductSuppliers = new List<Product>();//for getting list of editedProductSuppliers
        List<Product> products = new List<Product>();//create empty  list
        private ProductSupplier productSupplier = null;//variable for holds null 
        private Product selectedProduct = null;//variable for holds null 
        private Supplier selectedSupplier = null;//variable for holds null 

        public frmEditProductSuppliersForSelectedSupplier()
        {
            InitializeComponent();
        }
        private void UpdateBinding()
        {
            dgvProducts.DataSource = products;//assign null to dgvProducts
            dgvProductSuppliers.DataSource = editedProductSuppliers;//dgvProductSuppliers equal to editedProductSuppliers
        }

        public List<Product> GetEditProductSuppliers(Supplier ss, List<Product> ospl)
        {
            selectedSupplier = ss;//selected supplier equal to ss
            editedProductSuppliers = ospl;//selected editedProductSuppliers equal to ospl
            this.ShowDialog();//show list
            return editedProductSuppliers;
        }

        private void frmEditProductSuppliersForSelectedSupplier_Load(object sender, EventArgs e)
        {
            txtSupName.Text = selectedSupplier.SupName;

            try
            {
                products = ProductDB.GetProductsNotInList(selectedSupplier);//function to call GetProductsNotInList
                products = ProductDB.GetProductsNotInList(selectedSupplier);//function to call  GetProductsNotInList
                UpdateBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());//show exception if there any
            }

            frmProduct.ProductListFormat(dgvProducts);//function to call ProductListFormat
            frmProduct.ProductListFormat(dgvProductSuppliers);//function to call ProductListFormat

            txtPName.Select();//move cursor to textbox
        }

        private void txtPName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPName.Text != "")//check if text s name empty
                {
                    products = ProductDB.GetProductsByName(txtPName.Text);//function to call GetProductsByName
                    UpdateBinding();
                }
                else
                {
                    products = ProductDB.GetAllProducts();//function to call GetAllProducts
                    UpdateBinding();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());//show exception if there any
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                products = ProductDB.GetAllProducts();//function to call GetAllProducts
                UpdateBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());//show exception if there any
            }

            txtPName.Clear();
            txtPName.Select();
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvProducts.SelectedRows)//get each row from dgvProducts
                {
                    selectedProduct = new Product(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                                    row.Cells[1].Value.ToString());//get value from row and assign it to  selectedProduct
                    productSupplier = new ProductSupplier(selectedProduct.ProductId, selectedSupplier.SupplierId);//get value from row and assign it to  productSupplier
                    ProductSupplierDB.InsertProductSupplier(productSupplier);//function to call InsertProductSupplier
                    editedProductSuppliers = SupplierDB.GetProductSuppliersBySupplier(selectedSupplier);//function to call GetProductSuppliersBySupplier
                    products = ProductDB.GetProductsNotInList(selectedSupplier);//function to call GetProductsNotInList
                }

                UpdateBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());//show exception if there any
            }
            // only select the last row
            dgvProductSuppliers.ClearSelection();
            int index = editedProductSuppliers.Count - 1;
            dgvProductSuppliers.Rows[index].Selected = true;
            txtPName.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvProductSuppliers.SelectedRows)//get each row from dgvProductSuppliers
                {
                    selectedProduct = new Product(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                                    row.Cells[1].Value.ToString());//get value from row and assign it to  selectedProduct
                    productSupplier = new ProductSupplier(selectedProduct.ProductId, selectedSupplier.SupplierId);//get value from row and assign it to  ProductSupplier
                    ProductSupplierDB.DeleteProductSupplier(productSupplier);//function to call DeleteProductSupplier
                    editedProductSuppliers = SupplierDB.GetProductSuppliersBySupplier(selectedSupplier);//function to call GetProductSuppliersBySupplier
                    products = ProductDB.GetProductsNotInList(selectedSupplier);//function to call GetProductsNotInList
                }
                UpdateBinding();
                dgvProductSuppliers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deleting this product will cause you to lose a record in your booking history. \nThe delete action has been suspended. \nPlease contact DBA.");//show exception if there any
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();//close the form
        }
    }
}
