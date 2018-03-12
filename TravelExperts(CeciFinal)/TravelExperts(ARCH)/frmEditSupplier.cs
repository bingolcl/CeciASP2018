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
//Assisted: Cecilia Zhang
namespace TravelExperts_fileVersion_
{
    public partial class frmEditSupplier : Form
    {
        //new supplier object
        Supplier es = new Supplier();
        public frmEditSupplier()
        {
            InitializeComponent();
        }

        //load old supplier into edited supplier (es), show form, return edited supplier when done
        public Supplier GetEditSupplier(Supplier os)
        {
            es.SupplierId = os.SupplierId;
            es.SupName = os.SupName;
            this.ShowDialog();
            return es;
        }

        //load name of edited supplier to textbox, select the textbox
        private void frmEditSupplier_Load(object sender, EventArgs e)
        {
            txtEditSupplier.Text = es.SupName.ToString();
            txtEditSupplier.Select();
        }

        //take user input and save as the name of the edited supplier
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtEditSupplier,"Supplier Name"))
            {
                es.SupName = txtEditSupplier.Text;
                this.Close();
            }
        }

        //close the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
