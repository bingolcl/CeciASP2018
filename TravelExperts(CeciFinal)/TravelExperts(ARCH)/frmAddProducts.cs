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
//Assited: Mohammad Adam Butt

namespace TravelExperts_fileVersion_
{
    public partial class frmAddProducts : Form
    {
        List<Product> newProducts = new List<Product>();//create an empty list for the products
        private Product np = null;
        public frmAddProducts()
        {
            InitializeComponent();
        }

        public List<Product> GetNewProducts()//
        {
            this.ShowDialog();
            return newProducts;
        }
        private void AddProducts_Load(object sender, EventArgs e)
        {
            txtNewProdcut.Select(); //foucs on the new product textbox
        }

        private void btnAddOne_Click(object sender, EventArgs e)//on click, add new product
        {
            if (Validator.IsPresent(txtNewProdcut, "new product name"))
            {
                np = new Product(txtNewProdcut.Text);//take the new products
                newProducts.Add(np);//compile them
                lstNewProducts.Items.Add(np);//put them in the list
                txtNewProdcut.Clear(); //clear and reset the text box
                txtNewProdcut.Select();
            }
        }

        private bool IsValidData()//validate the new product
        {

            return Validator.IsListPresent(lstNewProducts, "new product");
        }

        private void btnSave_Click(object sender, EventArgs e) //save if is valid
        {
            if (Validator.IsListPresent(lstNewProducts, "new products"))
            {

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            newProducts = null; //nothing goes into the new products
            this.Close(); //close the pop up
        }
    }
}
