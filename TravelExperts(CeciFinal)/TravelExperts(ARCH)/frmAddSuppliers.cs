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
    public partial class frmAddSuppliers : Form
    {
        List<Supplier> newSuppliers = new List<Supplier>();
        private Supplier ns = null;
        public frmAddSuppliers()
        {
            InitializeComponent();
        }

        public List<Supplier> GetNewSuppliers()
        {
            this.ShowDialog();
            return newSuppliers;
        }

        private void AddSuppliers_Load(object sender, EventArgs e)
        {
            txtNewSupplier.Select();
        }

        private void btnAddOne_Click(object sender, EventArgs e)
        {
            if(Validator.IsPresent(txtNewSupplier, "new supplier name"))
            { 
                ns = new Supplier(txtNewSupplier.Text);
                newSuppliers.Add(ns);
                lstNewSuppliers.Items.Add(ns);
                txtNewSupplier.Clear();
                txtNewSupplier.Select();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validator.IsListPresent(lstNewSuppliers, "new suppliers"))
            {

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            newSuppliers = null;
            this.Close();
        }
    }
}
