using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trademarks
{
    public partial class Companies : Form
    {
        public Companies()
        {
            InitializeComponent();
        }
                
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void tsmiUpd_Click(object sender, EventArgs e)
        {

        }

        private void tsmiDel_Click(object sender, EventArgs e)
        {

        }

        private void dgvComRecs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvComRecs.HitTest(e.X, e.Y);
                if (hti.RowIndex < 0)
                {
                    return;
                }
                dgvComRecs.Rows[hti.RowIndex].Selected = true;
            }
        }
    }
}
