using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Author: Mohammad Adam Butt

namespace TravelExperts_fileVersion_
{
    public partial class frmSupplier : Form
    {
        //creating new supplier and productsupplier lists for this form
        List<Supplier> suppliers = new List<Supplier>();
        List<Product> productSuppliers = new List<Product>();
        public frmSupplier()
        {
            InitializeComponent();
            UpdateBinding();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            try
            {
                // load the products table data 
                suppliers = SupplierDB.GetAllSuppliers();
                UpdateBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            SuppliersListFormat(dgvSuppliers);
            frmProduct.ProductListFormat(dgvProducts);

            txtSuppName.Select();
        }
        //updates binding for both dgv's
        private void UpdateBinding()
        {
            dgvSuppliers.DataSource = suppliers;
            dgvProducts.DataSource = productSuppliers;

        }

        //formats dgv
        public static void SuppliersListFormat(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "ID";

            dgv.Columns[1].HeaderText = "Name";
            dgv.Columns[0].Width = 50;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = System.Drawing.SystemColors.Control;

        }

        //on selection change, updates dgvProducts to show corresponding products for this supplier
        private void dgvSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            Supplier selectedSupplier = null;
            try
            {
                foreach (DataGridViewRow row in dgvSuppliers.SelectedRows)
                {
                    selectedSupplier = new Supplier(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                                   row.Cells[1].Value.ToString());
                }
                if (productSuppliers == null)
                {
                    productSuppliers = SupplierDB.GetProductSuppliersBySupplier(selectedSupplier);
                    UpdateBinding();
                    frmProduct.ProductListFormat(dgvProducts);
                }
                else
                {
                    productSuppliers = SupplierDB.GetProductSuppliersBySupplier(selectedSupplier);
                    UpdateBinding();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }

        //as user enters search string, corresponding suppliers are displayed as text is entered
        private void txtSuppName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                suppliers = SupplierDB.GetSuppliersByName(txtSuppName.Text);
                UpdateBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        //resets everything to default
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                suppliers = SupplierDB.GetAllSuppliers();
                UpdateBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            txtSuppName.Clear();
            txtSuppName.Select();
        }

        //opens AddSupplier form, receives newly added suppliers, inserts to DB and updates dgv, scrolls down to latest new supplier added
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddSuppliers newForm = new frmAddSuppliers();
            List<Supplier> newSuppliers = newForm.GetNewSuppliers();

            try
            {
                if (newSuppliers != null)
                {
                    foreach (Supplier ns in newSuppliers)
                    {
                        SupplierDB.InsertSupplier(ns);
                    }
                }
                suppliers = SupplierDB.GetAllSuppliers();
                UpdateBinding();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            txtSuppName.Clear();
            //select on the last row of the list
            dgvSuppliers.ClearSelection();
            int rowIndex = dgvSuppliers.Rows.Count - 1;
            dgvSuppliers.Rows[rowIndex].Selected = true;
            //scroll down as well
            dgvSuppliers.FirstDisplayedScrollingRowIndex = rowIndex;
        }

        //opens EditSupplier form, receives edited supplier, updates DB, selects edited supplier in dgv
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Supplier editedSupplier = null;
            Supplier newSupplier = null;
            foreach (DataGridViewRow row in dgvSuppliers.SelectedRows)
            {
                editedSupplier = new Supplier(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                                    row.Cells[1].Value.ToString());
            }

            frmEditSupplier newForm = new frmEditSupplier();
            //this.Hide();

            newSupplier = newForm.GetEditSupplier(editedSupplier);

            //this.Show();

            try
            {
                SupplierDB.UpdateSupplier(editedSupplier, newSupplier);
                suppliers = SupplierDB.GetAllSuppliers();
                UpdateBinding();
                txtSuppName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            //set the modified row to be selected
            dgvSuppliers.ClearSelection();
            int rowIndex = -1;
            foreach (DataGridViewRow row in dgvSuppliers.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(editedSupplier.SupplierId.ToString()))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            dgvSuppliers.Rows[rowIndex].Selected = true;
            dgvSuppliers.FirstDisplayedScrollingRowIndex = rowIndex;
        }

        //deletes selected supplier in DB, updates dgv
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier selectedSupplier = null;
                foreach (DataGridViewRow row in dgvSuppliers.SelectedRows)
                {
                    selectedSupplier = new Supplier(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                                   row.Cells[1].Value.ToString());
                    string message = "Are you sure you want to delete " +
                                      selectedSupplier.SupName +
                                      " ?";
                    DialogResult button = MessageBox.Show(message, "Confirm Delete",
                                          MessageBoxButtons.YesNo);
                    if (button == DialogResult.Yes)
                    {
                        SupplierDB.DeleteSupplier(selectedSupplier);
                        suppliers = SupplierDB.GetAllSuppliers();
                        UpdateBinding();
                        txtSuppName.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, ex.GetType().ToString());
                MessageBox.Show("Deleting this supplier will cause you to lose a record in your booking history. \nThe delete action has been suspended. \nPlease contact DBA.");
            }
        }

        //opens form for editing supplier products, updates binding
        private void btnEditProducts_Click(object sender, EventArgs e)
        {
            Supplier editedSupplier = null;
            foreach (DataGridViewRow row in dgvSuppliers.SelectedRows)
            {
                editedSupplier = new Supplier(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                                    row.Cells[1].Value.ToString());

            }

            frmEditProductSuppliersForSelectedSupplier newForm = new frmEditProductSuppliersForSelectedSupplier();
            productSuppliers = newForm.GetEditProductSuppliers(editedSupplier, productSuppliers);

            UpdateBinding();

        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSuppliers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }
    }
}
