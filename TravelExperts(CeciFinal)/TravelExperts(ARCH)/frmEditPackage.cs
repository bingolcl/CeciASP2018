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
 * Purpose: Edit selected package.
 */


namespace TravelExperts_fileVersion_
{
    public partial class frmEditPackage : Form
    {
        //create varibles for the new package data and nullable datatimes
        Package ep;
        DateTime? nullableDateS = null;
        DateTime? nullableDateE = null;

        public frmEditPackage()
        {
            InitializeComponent();
        }
        
        //received the selected package data from parent form and return the new one when the form closes
        public Package GetEditPackage(Package op)
        {
            ep = op;
            this.ShowDialog();
            return ep;
        }

        //display the original packate data in the txtboxes as the page load
        private void frmEditPackage_Load(object sender, EventArgs e)
        {
            txtPkgName.Text = ep.PkgName.ToString();

            if(ep.PkgStartDate == null)
            {
                ckbSDNull.Checked = true;
            }
            else
            {
                dtpStart.Format = DateTimePickerFormat.Short;
                dtpStart.Value = Convert.ToDateTime(ep.PkgStartDate);
                nullableDateS = dtpStart.Value;
            }      
            
            if(ep.PkgEndDate == null)
            {
                ckbEDNull.Checked = true;
            }
            else
            {
                dtpEnd.Format = DateTimePickerFormat.Short;
                dtpEnd.Value = Convert.ToDateTime(ep.PkgEndDate);
                nullableDateE = dtpEnd.Value;
            }
            
            rtbDesc.Text = ep.PkgDesc;
            txtPrice.Text = ep.PkgBasePrice.ToString("c");

            if (ep.PkgAgencyCommission == null)
                txtCommission.Text = "";
            else
                txtCommission.Text = ep.PkgAgencyCommission.Value.ToString("c");

            txtPkgName.Select();

        }

        //update the package after vailidation
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                ep.PkgName = txtPkgName.Text;
                ep.PkgStartDate = nullableDateS;
                ep.PkgEndDate = nullableDateE;
                ep.PkgDesc = rtbDesc.Text;
                ep.PkgBasePrice = Convert.ToDecimal(txtPrice.Text.Trim('$'));
                if (String.IsNullOrEmpty(txtCommission.Text))
                {
                    ep.PkgAgencyCommission = null;
                }
                else
                    ep.PkgAgencyCommission = Convert.ToDecimal(txtCommission.Text.Trim('$'));
                this.Close();
            }
        }

        //close the form(with no change's been updated)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //validate the input data
        private bool ValidateInput()
        {
            if (!Validator.IsEditPresent(txtPkgName, "Package Name", ep.PkgName.ToString()))
            {
                return false;
            }
            if (nullableDateE != null && nullableDateS != null)
            {
                if (dtpStart.Value.AddDays(1) > dtpEnd.Value)
                {
                    MessageBox.Show("Package End Date must be later than Package Start Date", "Entry Error");
                    dtpEnd.Select();
                    return false;
                }
            }
            if (!Validator.IsEditPresent(rtbDesc, "Description", ep.PkgDesc))
            {
                return false;
            }
            if (!Validator.IsEditPresent(txtPrice, "Base Price",ep.PkgBasePrice.ToString("c")))
            {
                return false;
            }
            if (!Validator.IsNonNegative(txtPrice, "Base Price"))
            {
                return false;
            }
            if (!String.IsNullOrEmpty(txtCommission.Text))
            {
                if (!Validator.IsNonNegative(txtCommission, "Agency Commission"))
                {
                    return false;
                }
                else if (Convert.ToDecimal(txtCommission.Text.Trim('$')) > Convert.ToDecimal(txtPrice.Text.Trim('$')))
                {
                    MessageBox.Show("Agency Commission cannot be greater than the Base Price", "Entry Error");
                    txtCommission.Select();
                    return false;
                }
            }

            return true;

        }

        //for nuallable start date checkbox
        private void ckbSDNull_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSDNull.Checked)
            {
                dtpStart.CustomFormat = " ";
                dtpStart.Format = DateTimePickerFormat.Custom;
                dtpStart.Enabled = false;
                nullableDateS = null;               
            }
            else
            {
                dtpStart.Enabled = true;
                dtpStart.Format = DateTimePickerFormat.Short;
                nullableDateS = dtpStart.Value;
            }
        }

        //for nuallable end date checkbox
        private void ckbEDNull_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEDNull.Checked)
            {
                dtpEnd.CustomFormat = " ";
                dtpEnd.Format = DateTimePickerFormat.Custom;
                dtpEnd.Enabled = false;
                nullableDateE = null;
            }
            else
            {
                dtpEnd.Enabled = true;
                dtpEnd.Format = DateTimePickerFormat.Short;
                nullableDateE = dtpEnd.Value;
            }
        }

        //update the value for start date
        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            nullableDateS = dtpStart.Value;
        }

        //update the value for end date
        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            nullableDateE = dtpEnd.Value;
        }

        //boarder designs
        protected override void OnPaint(PaintEventArgs e)
        {
            Point[] points = {
                            new Point(200,0),
                            new Point(650,0),
                            new Point(640,10),
                            new Point(630,20),
                            new Point(220,20),
                            new Point(210,10),
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
