using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Author: Riley Hobberstad
//Assisted: Mohammad Adam Butt
namespace TravelExperts_fileVersion_
{
    public partial class frmEditProduct : Form
    {
        Product ep = new Product();//setting up edited product
        public frmEditProduct()
        {
            InitializeComponent();
        }
        public Product GetEditProduct(Product op) //getting the edited products
        {
            ep.ProdName = op.ProdName; //new name replaces old name 
            ep.ProductId = op.ProductId;//new ID redplaces old ID
            this.ShowDialog();         //Display 
            return ep;                 //these are the new values
        }
        private void EditProduct_Load(object sender, EventArgs e)
        {
            txtEditProduct.Text = ep.ProdName.ToString();//getting the new name
            txtEditProduct.Select();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtEditProduct, "Product Name"))//making sure there are characters in the textbox
            {
                ep.ProdName = txtEditProduct.Text; //getting the new name
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); this.Close(); //close form
        }
    }
}
