using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Author Name: Harpreet Parmar
 * Date: 15 January.2018
 * Purpose Of Application:Creating user friendy website for travel experts
 */

namespace TravelExperts_fileVersion_
{
    public partial class frmEditProductSuppliersForSelectedProduct : Form
    {
        List<Supplier> editedProductSuppliers = new List<Supplier>();//for getting list of product suppliers
        List<Supplier> suppliers = new List<Supplier>();//create empty list
        private ProductSupplier productSupplier = null;//variable for hold null 
        private Product selectedProduct = null;   //variable for hold null      
        private Supplier selectedSupplier = null;//variable for hold null 

        public frmEditProductSuppliersForSelectedProduct()
        {
            InitializeComponent();
        }
        private void UpdateBinding()
        {
            dgvSuppliers.DataSource = null;     //assign null to dgvSuppliers
            dgvSuppliers.DataSource = suppliers;//dgvSuliers equal to suppliers
            frmSupplier.SuppliersListFormat(dgvSuppliers);//function call to SuppliersListFormat
            dgvProductSuppliers.DataSource = null;//assign dgv product suppliers to null
            dgvProductSuppliers.DataSource = editedProductSuppliers;////sgvProductSuppliers equal to editProductSuppliers
            frmSupplier.SuppliersListFormat(dgvProductSuppliers);//function call to suppliersListFormat

        }

        public List<Supplier> GetEditProductSuppliers(Product sp, List<Supplier> opsl)//for getting list of edit product suppliers
        {
            selectedProduct = sp;//selected product equal to sp(product)
            editedProductSuppliers = opsl;//edit product suppliers equal to opsl suppliers list
            this.ShowDialog();  //show list
            return editedProductSuppliers;
        }

        private void EditProductSuppliers_Load(object sender, EventArgs e)
        {
            txtProdName.Text = selectedProduct.ProdName;

            try
            {
                suppliers = SupplierDB.GetSuppliersNotInList(selectedProduct);//function call to GetSuppliersNotInList
                UpdateBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }


            frmSupplier.SuppliersListFormat(dgvSuppliers);//function calls to suppliersListFormat
            frmSupplier.SuppliersListFormat(dgvProductSuppliers);//function call to SupplierListFormat

            txtSName.Select();//move cursor to textbox

        }

        private void txtSName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSName.Text != "")//check if text s name empty
                {
                    suppliers = SupplierDB.GetSuppliersByName(txtSName.Text);//function call to GetSupplierByName
                    UpdateBinding();
                }
                else
                {
                    suppliers = SupplierDB.GetAllSuppliers();//function calls to GetAllSuppliers
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
                suppliers = SupplierDB.GetAllSuppliers();//call function to get all suppliers
                UpdateBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());//show exception if there any
            }

            txtSName.Clear();//for clear textBox
            txtSName.Select();
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvSuppliers.SelectedRows)//get each row from dgvSuppliers
                {
                    selectedSupplier = new Supplier(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                                    row.Cells[1].Value.ToString());//get value from row and assign it to selected supplier
                    productSupplier = new ProductSupplier(selectedProduct.ProductId, selectedSupplier.SupplierId);//get value from row and assign it to selected product supplier
                    ProductSupplierDB.InsertProductSupplier(productSupplier);//call insertProductSupplier
                    editedProductSuppliers = ProductDB.GetProductSuppliersByProduct(selectedProduct);//call GetProductSupplierByProduct
                    //suppliers.Remove(selectedSupplier);
                    suppliers = SupplierDB.GetSuppliersNotInList(selectedProduct);//call GetSupplierNotInList function
                }

                UpdateBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());//show exception if there any
            }
            // only select the last row
            dgvProductSuppliers.ClearSelection();//clear dgvProductSuppliers
            int index = editedProductSuppliers.Count - 1;
            dgvProductSuppliers.Rows[index].Selected = true;
            txtSName.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvProductSuppliers.SelectedRows)//get each row from dgvProductSuppliers
                {
                    selectedSupplier = new Supplier(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                                   row.Cells[1].Value.ToString());//get value from row and assign it to selected supplier
                    productSupplier = new ProductSupplier(selectedProduct.ProductId, selectedSupplier.SupplierId);//get value from row and assign it to selected product
                    ProductSupplierDB.DeleteProductSupplier(productSupplier);//call DeleteProductSupplier
                    editedProductSuppliers = ProductDB.GetProductSuppliersByProduct(selectedProduct);//call GetProductSuppliersByProduct function
                    suppliers = SupplierDB.GetSuppliersNotInList(selectedProduct);//call GetSuppliersNotInList function
                }
                UpdateBinding();
                dgvProductSuppliers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deleting this supplier will cause you to lose a record in your booking history. \nThe delete action has been suspended. \nPlease contact DBA.");//show exception if there any
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();//close form
        }


    }
}
