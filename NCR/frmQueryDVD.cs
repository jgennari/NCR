using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NCR
{
    public partial class frmQueryDVD : Form
    {
        public frmQueryDVD()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnName_TextChanged(object sender, EventArgs e)
        {
            btnClose.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnName.Text = "";
            this.Close();
        }
    }
}
