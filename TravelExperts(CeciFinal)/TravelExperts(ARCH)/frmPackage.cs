using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Travel Experts
 * Date: Jan 22, 2017
 * Author: Cecilia Zhang
 * Purpose: Display/Add/Edit Packages, display Package Details.
 */

namespace TravelExperts_fileVersion_
{
    public partial class frmPackage : Form
    {
        //create lists and variables to store data
        List<Package> packages = new List<Package>();
        List<PackageProductSupplier> ppss = new List<PackageProductSupplier>();
        Package newPackage = new Package();
        PackageProductSupplier pps = null;
        public static int selectedId = 0;
        
        public frmPackage()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;//maximized window size
        }

        private void PackageForm_Load(object sender, EventArgs e)
        {
            //turn off the form border control 
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //display all packages data in the datagridview
            try
            {
                packages = PackageDB.GetAllPackages();
                UpdateBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            //format the datagirdviews
            PackageListFormat(dgvPackages);
            PackageDetailFormat(dgvPackageDetail);

            txtPkgName.Select();
        }

        //bind datasource for each datagridview
        private void UpdateBinding()
        {
            dgvPackages.DataSource = packages;
            dgvPackageDetail.DataSource = ppss;
        }

        //datagridview format for packages
        public static void PackageListFormat(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[1].HeaderText = "Name";
            dgv.Columns[2].HeaderText = "Start Date";
            dgv.Columns[2].DefaultCellStyle.Format = "d";
            dgv.Columns[3].HeaderText = "End Date";
            dgv.Columns[3].DefaultCellStyle.Format = "d";
            dgv.Columns[4].HeaderText = "Description";
            dgv.Columns[4].Width=400;
            dgv.Columns[5].HeaderText = "Base Price";
            dgv.Columns[5].DefaultCellStyle.Format = "c";
            dgv.Columns[6].HeaderText = "Commission";
            dgv.Columns[6].DefaultCellStyle.Format = "c";
            dgv.Columns[0].Width = 50;
        }

        //datagridview format for the details
        public static void PackageDetailFormat(DataGridView dgv)
        {
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].Visible = false;
            dgv.Columns[3].Width = 150;
            dgv.Columns[3].HeaderText = "Product Name";
            dgv.Columns[4].HeaderText = "Supplier Name";
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        //display the details whenever the selection changed on the packages
        private void dgvPackages_SelectionChanged(object sender, EventArgs e)
        {
            Package selectedPackage = null;
            try
            {
                foreach (DataGridViewRow row in dgvPackages.SelectedRows)
                {
                    selectedPackage = new Package(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                      row.Cells[1].Value.ToString(),
                                      (DateTime?)(row.Cells[2].Value),
                                      (DateTime?)(row.Cells[3].Value),
                                      row.Cells[4].Value.ToString(),
                                      Convert.ToDecimal(row.Cells[5].Value.ToString()),
                                      (decimal?)(row.Cells[6].Value));                    
                }
                if (ppss == null)
                {
                    ppss = PackageDB.GetProductSuppliersByPackage(selectedPackage);
                    UpdateBinding();
                    PackageDetailFormat(dgvPackageDetail);
                }
                else
                {
                    ppss = PackageDB.GetProductSuppliersByPackage(selectedPackage);
                    UpdateBinding();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        //search and display pkg by name
        private void txtPkgName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                packages = PackageDB.GetPackageByName(txtPkgName.Text);
                UpdateBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        //reset the page to page load
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                packages = PackageDB.GetAllPackages();
                UpdateBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            txtPkgName.Clear();
            txtPkgName.Select();
        }

        //open a new window that allows the uer to add a new package
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddPackages newForm = new frmAddPackages();
            newPackage = newForm.GetNewPackages();

            try
            {
                if (newPackage != null)
                {

                    PackageDB.InsertPackage(newPackage);
                    packages = PackageDB.GetAllPackages();
                    UpdateBinding();
                    //select on the last row of the list
                    dgvPackages.ClearSelection();
                    int rowIndex = dgvPackages.Rows.Count - 1;
                    dgvPackages.Rows[rowIndex].Selected = true;
                    //scroll down as well
                    dgvPackages.FirstDisplayedScrollingRowIndex = rowIndex;
                }               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            txtPkgName.Clear();

        }

        //open a knew window that allow the user to edit the selected package
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Package editedPackage = null;
            Package oldPackage = null;
            foreach (DataGridViewRow row in dgvPackages.SelectedRows)
            {
                editedPackage = new Package(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                      row.Cells[1].Value.ToString(),
                                      (DateTime?)row.Cells[2].Value,
                                      (DateTime?)row.Cells[3].Value,
                                      row.Cells[4].Value.ToString(),
                                      Convert.ToDecimal(row.Cells[5].Value.ToString()),
                                      (decimal?)(row.Cells[6].Value));                
            }

            frmEditPackage newForm = new frmEditPackage();
            oldPackage = (Package)editedPackage.Clone();
            editedPackage = newForm.GetEditPackage(editedPackage);


            try
            {
                if (!PackageDB.UpdatePackage(oldPackage, editedPackage))
                {
                    MessageBox.Show("Another user has updated or " +
                                "deleted that customer.", "Database Error");
                }
                else
                {
                    selectedId = editedPackage.PackageId;
                    packages = PackageDB.GetAllPackages();
                    UpdateBinding();
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            txtPkgName.Clear();

            //set the modified row to be selected
            dgvPackages.ClearSelection();
            int rowIndex = -1;
            foreach (DataGridViewRow row in dgvPackages.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(selectedId.ToString()))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            dgvPackages.Rows[rowIndex].Selected = true;
            dgvPackages.FirstDisplayedScrollingRowIndex = rowIndex;

        }

        //delete the selected package and it's references
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Package selectedPackage = null;
                foreach (DataGridViewRow row in dgvPackages.SelectedRows)
                {
                    selectedPackage = new Package(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                      row.Cells[1].Value.ToString(),
                                      (DateTime?)(row.Cells[2].Value),
                                      (DateTime?)(row.Cells[3].Value),
                                      row.Cells[4].Value.ToString(),
                                      Convert.ToDecimal(row.Cells[5].Value.ToString()),
                                      (decimal?)(row.Cells[6].Value));
                    string message = "Are you sure you want to delete " +
                                      selectedPackage.PkgName +"?";
                    DialogResult button = MessageBox.Show(message, "Confirm Delete",
                                          MessageBoxButtons.YesNo);
                    if (button == DialogResult.Yes)
                    {
                        PackageDB.DeletePackage(selectedPackage);
                        packages = PackageDB.GetAllPackages();
                    }
                }
                UpdateBinding();
                txtPkgName.Clear();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deleting this package will cause you to lose records in your booking history. \nThe delete action has been suspended. \nPlease contact DBA.");
            }
        }

        //open a new window that allow user to add/remove products/suppliers for the selected package
        private void btnDetail_Click(object sender, EventArgs e)
        {
            Package editedPackage = null;
            foreach (DataGridViewRow row in dgvPackages.SelectedRows)
            {
                editedPackage = new Package(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                      row.Cells[1].Value.ToString(),
                                      (DateTime?)(row.Cells[2].Value),
                                      (DateTime?)(row.Cells[3].Value),
                                      row.Cells[4].Value.ToString(),
                                      Convert.ToDecimal(row.Cells[5].Value.ToString()),
                                      (decimal?)(row.Cells[6].Value));

            }

            frmEditPackageDetail newForm = new frmEditPackageDetail();
            selectedId = editedPackage.PackageId;
            ppss = newForm.GetPackageDetail(editedPackage, ppss);            

            UpdateBinding();


            //set the modified row to be selected
            dgvPackages.ClearSelection();
            int rowIndex = -1;
            foreach (DataGridViewRow row in dgvPackages.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(selectedId.ToString()))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            dgvPackages.Rows[rowIndex].Selected = true;
            dgvPackages.FirstDisplayedScrollingRowIndex = rowIndex;

        }

        //close the form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //double click on package data will trigger the edit button
        private void dgvPackages_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }

        //double click on package  detail data will trigger the edit detail button
        private void dgvPackageDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDetail.PerformClick();
        }
    }
}
