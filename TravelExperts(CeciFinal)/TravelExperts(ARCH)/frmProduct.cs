using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Author Riley Hobberstad

namespace TravelExperts_fileVersion_
{
    public partial class frmProduct : Form
    {

        List<Product> products = new List<Product>(); //call the list of products
        List<Supplier> productSuppliers = new List<Supplier>(); //call the list of product suppliers
        public frmProduct()
        {
            InitializeComponent();
        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;//formating the form
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            try
            {
                // load the products table data 
                products = ProductDB.GetAllProducts();
                UpdateBinding();
            }
            catch (Exception ex)
            {//if there was an error loading, give message
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            //if there isn't an error, place the information in the data views
            frmProduct.ProductListFormat(dgvProduct);
            frmSupplier.SuppliersListFormat(dgvSuppliers);

            txtProdName.Select(); //focus on the search text box


        }

        private void UpdateBinding()
        {//update the products if there are new ones
            dgvProduct.DataSource = products;
            dgvSuppliers.DataSource = productSuppliers;

        }

        public static void ProductListFormat(DataGridView dgv)
        {//formatting the list
            dgv.Columns[0].HeaderText = "ID"; //name the first column id
            dgv.Columns[1].HeaderText = "Name";//name the second column name
            dgv.Columns[0].Width = 50;           //set the width to 50px  
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = System.Drawing.SystemColors.Control;

        }

        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {//when the produst is selected, change the supplier info
            Product selectedProduct = null;
            try
            {
                foreach (DataGridViewRow row in dgvProduct.SelectedRows)
                {//connect to the database
                    selectedProduct = new Product(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                                   row.Cells[1].Value.ToString());
                    //products[dgvProduct.CurrentCell.RowIndex]
                }
                if (productSuppliers == null)
                { //update the suppliers
                    productSuppliers = ProductDB.GetProductSuppliersByProduct(selectedProduct);
                    UpdateBinding();
                    ProductListFormat(dgvSuppliers);
                }
                else
                {//put the product supplers on the list that match the products
                    productSuppliers = ProductDB.GetProductSuppliersByProduct(selectedProduct);
                    UpdateBinding();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void txtProdName_TextChanged(object sender, EventArgs e)
        {
            try
            {//search for products
                products = ProductDB.GetProductsByName(txtProdName.Text);
                UpdateBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {//clear the contents from search text box
                products = ProductDB.GetAllProducts();
                UpdateBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            txtProdName.Clear();
            txtProdName.Select();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {//bring up add product form 
            frmAddProducts newForm = new frmAddProducts();
            List<Product> newProducts = null;
            newProducts = newForm.GetNewProducts();


            try
            {
                if (newProducts != null)
                {
                    foreach (Product np in newProducts)
                    {
                        ProductDB.InsertProduct(np);
                    }//add new products
                    products = ProductDB.GetAllProducts();
                    UpdateBinding();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            txtProdName.Clear();
            //select on the last row of the list
            dgvProduct.ClearSelection();
            int rowIndex = dgvProduct.Rows.Count - 1;
            dgvProduct.Rows[rowIndex].Selected = true;
            //scroll down as well
            dgvProduct.FirstDisplayedScrollingRowIndex = rowIndex;


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            Product ep = new Product();//new edited product
            Product op = null; //old product 

            foreach (DataGridViewRow row in dgvProduct.SelectedRows)
            { //get the old data
                op = new Product(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                                    row.Cells[1].Value.ToString());
            }

            frmEditProduct newForm = new frmEditProduct();


            ep = newForm.GetEditProduct(op);
            //get the edited prodict



            try
            {//put new information into the old spot
                ProductDB.UpdateProduct(ep, op);
                products = ProductDB.GetAllProducts();
                UpdateBinding();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            txtProdName.Clear();

            //set the modified row to be selected
            dgvProduct.ClearSelection();
            int rowIndex = -1;
            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(ep.ProductId.ToString()))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            dgvProduct.Rows[rowIndex].Selected = true;
            dgvProduct.FirstDisplayedScrollingRowIndex = rowIndex;
            //focus on the last entry

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {//delete product from supplier
                Product selectedProduct = null;
                foreach (DataGridViewRow row in dgvProduct.SelectedRows)
                {//get the product that is selected
                    selectedProduct = new Product(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                                   row.Cells[1].Value.ToString());
                    string message = "Are you sure you want to delete " +
                                      selectedProduct.ProdName +
                                      " ?";//make sure they want to delete the product
                    DialogResult button = MessageBox.Show(message, "Confirm Delete",
                                          MessageBoxButtons.YesNo);
                    if (button == DialogResult.Yes)
                    {
                        ProductDB.DeleteProduct(selectedProduct);//delete the product
                        products = ProductDB.GetAllProducts();
                        UpdateBinding();//save the delete
                        txtProdName.Clear();
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, ex.GetType().ToString());
                MessageBox.Show("Deleting this supplier will cause you to lose a record in your booking history. \nThe delete action has been suspended. \nPlease contact DBA.");
            }
        }


        private void btnEditSuppliers_Click(object sender, EventArgs e)
        {
            Product editedProduct = null;//edit suppliers
            foreach (DataGridViewRow row in dgvProduct.SelectedRows)
            { //set the variable for the edited supplier
                editedProduct = new Product(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                                    row.Cells[1].Value.ToString());

            }
            //load the edit form
            frmEditProductSuppliersForSelectedProduct newForm = new frmEditProductSuppliersForSelectedProduct();
            productSuppliers = newForm.GetEditProductSuppliers(editedProduct, productSuppliers);

            UpdateBinding();

        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void dgvSuppliers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditSuppliers.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
