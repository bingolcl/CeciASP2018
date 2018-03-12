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
 * Purpose: add new package.
 */

namespace TravelExperts_fileVersion_
{
    public partial class frmAddPackages : Form
    {
        //create varibles for the new package data and nullable datatimes
        Package np = new Package();
        DateTime? nullableDateS = DateTime.Now;
        DateTime? nullableDateE = null;
        decimal? nullableCommission = null;


        public frmAddPackages()
        {
            InitializeComponent();
        }

        //return the new package when close th form
        public Package GetNewPackages()
        {
            this.ShowDialog();
            return np;
        }

        //initial setup as form load
        private void frmAddPackages_Load(object sender, EventArgs e)
        {
            txtPkgName.Select();
            ckbEDNull.Checked = true;

        }

        //store the data in the new package object
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (String.IsNullOrEmpty(txtCommission.Text))
                    nullableCommission = null;
                else
                    nullableCommission = Convert.ToDecimal(txtCommission.Text);
                np = new Package(txtPkgName.Text,
                              nullableDateS,
                              nullableDateE,
                              rtbDesc.Text,
                              Convert.ToDecimal(txtPrice.Text),
                              nullableCommission);

                this.Close();
            }

        }

        //set the new package to null and close the form(return null object)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            np = null;
            this.Close();
        }

        //validte the input data
        private bool ValidateInput()
        {
            if (!Validator.IsPresent(txtPkgName, "Package Name"))
            {
                txtPkgName.Select();
                return false;
            }
            else if (nullableDateS.Value.AddDays(-1) > nullableDateE)
            {
                MessageBox.Show("Package End Date must be later than Package Start Date", "Entry Error");
                dtpEnd.Select();
                return false;
            }
            else if (!Validator.IsPresent(rtbDesc, "Description"))
            {
                return false;
            }
            else if(!Validator.IsPresent(txtPrice, "Base Price"))
            {
                txtPrice.Select();
                return false;
            }
            else if (!Validator.IsNonNegative(txtPrice, "Base Price"))
            {
                txtPrice.Select();
                return false;
            }
            else if (!String.IsNullOrEmpty(txtCommission.Text))
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
                else
                    return true;
            }
            else
            {
                return true;
            }

        }

        //update the end date
        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {           
            nullableDateE = dtpEnd.Value;
        }

        //update the start date
        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            nullableDateS = dtpStart.Value;
        }

        //for nuallable start date checkbox
        private void ckbSDNull_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSDNull.Checked)
            {
                dtpStart.CustomFormat = " ";
                dtpStart.Format = DateTimePickerFormat.Custom;
                nullableDateS = null;                
            }
            else
            {
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
            }
            else
            {
                dtpEnd.Format = DateTimePickerFormat.Short;
                nullableDateE = dtpEnd.Value;
            }
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

        private void border_top_MouseUp(object sender, MouseEventArgs e)
        {
            togMove = 0;
        }

        private void border_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (togMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnCancel.PerformClick();
        }
    }
}
