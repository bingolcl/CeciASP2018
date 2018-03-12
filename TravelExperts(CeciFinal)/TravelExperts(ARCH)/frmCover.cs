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
 * Purpose: Display a coverpage when application start.
 */

namespace TravelExperts_fileVersion_
{
    public partial class frmCover : Form
    {
        public frmCover()
        {
            InitializeComponent();
        }

        private void frmCover_Load(object sender, EventArgs e)
        {           
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
        }
    }
}
