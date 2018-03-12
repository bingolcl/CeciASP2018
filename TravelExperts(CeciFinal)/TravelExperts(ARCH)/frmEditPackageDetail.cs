using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Travel Experts
 * Date: Jan 22, 2017
 * Author: Cecilia Zhang
 * Purpose: add/remove products_suppliers for selected package.
 */

namespace TravelExperts_fileVersion_
{
    public partial class frmEditPackageDetail : Form
    {
        //create varibles for the new package data and nullable datatime
        List<PackageProductSupplier> details = new List<PackageProductSupplier>();
        Package selectedPackage = null;
        List<Package> packages = null;
        List<Product> products = null;
        List<Supplier> suppliers = null;

        public frmEditPackageDetail()
        {
            InitializeComponent();
        }

        //pass in the selected package and it's details list, return the list for details when the form closes
        public List<PackageProductSupplier> GetPackageDetail(Package sp, List<PackageProductSupplier> oppsl)
        {
            selectedPackage = sp;
            details = oppsl;
            this.ShowDialog();
            return details;
        }

        //display the selected package and it's details, setup the available products and suppliers in the combo box
        private void frmPackageDetail_Load(object sender, EventArgs e)
        {            

            try
            {
                details = PackageDB.GetProductSuppliersByPackage(selectedPackage);
                dgvPackageDetail.DataSource = details;
                frmPackage.PackageDetailFormat(dgvPackageDetail);                

                packages = PackageDB.GetAllPackages();
                cobPackages.DataSource = packages;
                cobPackages.DisplayMember = "PkgName";
                cobPackages.ValueMember = "PackageId";

                cobPackages.SelectedValue = selectedPackage.PackageId;
               
                products = ProductDB.GetAllProducts();
                cobProducts.DataSource = products;
                cobProducts.DisplayMember = "ProdName";
                cobProducts.ValueMember = "ProductId";

                int id;
                bool parseOK = Int32.TryParse(cobProducts.SelectedValue.ToString(), out id);
                Product p = ProductDB.GetProductById(id);
                suppliers = PackageDB.GetSuppliersByProductNotInDetails(p, selectedPackage);
                cobSuppliers.DataSource = suppliers;
                cobSuppliers.DisplayMember = "SupName";
                cobSuppliers.ValueMember = "SupplierId";

                cobPackages.Select();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }           
        }

        //update the datasource for each control, the sullier list is adjusted so that user would not insert duplicate data
        private void UpdateBinding()
        {
            dgvPackageDetail.DataSource = details;

            int id;
            bool parseOK = Int32.TryParse(cobProducts.SelectedValue.ToString(), out id);
            Product p = ProductDB.GetProductById(id);
            suppliers = PackageDB.GetSuppliersByProductNotInDetails(p, selectedPackage);

            if (suppliers.Count == 0)
            {
                cobSuppliers.Enabled = false;
                cobSuppliers.Text = "";
                btnAdd.Enabled = false;
            }
            else
            {
                cobSuppliers.Enabled = true;
                cobSuppliers.DataSource = suppliers;
                btnAdd.Enabled = true;
            }

        }

        //update the display when the package combobox selection changed
        private void cobPackages_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int id;
                bool parseOK = Int32.TryParse(cobPackages.SelectedValue.ToString(), out id);
                Package pkg = PackageDB.GetPackageById(id);
                details = PackageDB.GetProductSuppliersByPackage(pkg);
                dgvPackageDetail.DataSource = details;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        //update the supplier list when the product combobox selection changed 
        private void cobProducts_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateBinding();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        //add the selected product and supplier from combox to the detail list(Packages_Products_Suppliers table)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int pId;
                bool pOk = Int32.TryParse(cobProducts.SelectedValue.ToString(), out pId);
                Product p = ProductDB.GetProductById(pId);
                int sId;
                bool sOk = Int32.TryParse(cobSuppliers.SelectedValue.ToString(), out sId);
                Supplier s = SupplierDB.GetSupplierById(sId);
                int pkgId;
                bool pkgOK = Int32.TryParse(cobPackages.SelectedValue.ToString(), out pkgId);
                Package pkg = PackageDB.GetPackageById(pkgId);
                PackageDB.InsertDetail(p, s, pkg);
                details = PackageDB.GetProductSuppliersByPackage(pkg);                

                UpdateBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        //delete the selected product_supplier from the detail list(Packages_Products_Suppliers table)
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvPackageDetail.SelectedRows)
                {
                    Product p = ProductDB.GetProductByName(row.Cells[3].Value.ToString());
                    Supplier s = SupplierDB.GetSupplierByName(row.Cells[4].Value.ToString());
                    int pkgId;
                    bool pkgOK = Int32.TryParse(cobPackages.SelectedValue.ToString(), out pkgId);
                    Package pkg = PackageDB.GetPackageById(pkgId);

                    string message = "Are you sure you want to remove ["+ p.ProdName +" : "+s.SupName+"] from package ["+ pkg.PkgName +"]?";
                    DialogResult button = MessageBox.Show(message, "Confirm Delete",
                                          MessageBoxButtons.YesNo);
                    if (button == DialogResult.Yes)
                    {
                        ProductSupplier productSupplier = ProductSupplierDB.GetProductSupplierById(p.ProductId, s.SupplierId);
                        ProductSupplierDB.DeletePackageDetail(productSupplier, pkg);

                        details = PackageDB.GetProductSuppliersByPackage(pkg);
                    }
                }
                UpdateBinding();
                dgvPackageDetail.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        //return the selected pkgId and close the form
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool pkgOK = Int32.TryParse(cobPackages.SelectedValue.ToString(), out frmPackage.selectedId);            
            this.Close();
        }

        //boarder designs
        protected override void OnPaint(PaintEventArgs e)
        {
            Point[] points = {
                            new Point(240,0),
                            new Point(690,0),
                            new Point(680,10),
                            new Point(670,20),
                            new Point(260,20),
                            new Point(250,10),
                            };
            GraphicsPath poly = new GraphicsPath();
            poly.AddPolygon(points);
            border_top.Region = new Region(poly);

            Pen border = new Pen(Color.Silver, 3);
            e.Graphics.DrawPolygon(border, points);
        }

        //relocation features
        int togMove;
        int MValX;
        int MValY;
        private void border_top_MouseDown(object sender, MouseEventArgs e)
        {
            togMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void border_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (togMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void border_top_MouseUp(object sender, MouseEventArgs e)
        {
            togMove = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
