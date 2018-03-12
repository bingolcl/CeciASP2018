using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExperts_fileVersion_
{
    public partial class TEContainer : Form
    {
        frmProduct newProductForm = null;
        frmSupplier newSupplierForm = null;
        frmPackage newPackageForm = null;
        public TEContainer()
        {
            InitializeComponent();
        }

        private void TEContainer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            frmCover newCoverForm = new frmCover();
            newCoverForm.MdiParent = this;
            newCoverForm.Show();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(newSupplierForm != null)
                newSupplierForm.Close();
            if (newPackageForm != null)
                newPackageForm.Close();
            newProductForm = new frmProduct();
            newProductForm.MdiParent = this;
            newProductForm.Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (newProductForm != null)
                newProductForm.Close();
            if (newPackageForm != null)
                newPackageForm.Close();
            newSupplierForm = new frmSupplier();
            newSupplierForm.MdiParent = this;            
            newSupplierForm.Show();
        }

        private void packageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (newProductForm != null)
                newProductForm.Close();
            if (newSupplierForm != null)
                newSupplierForm.Close();
            newPackageForm = new frmPackage();
            newPackageForm.MdiParent = this;           
            newPackageForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
