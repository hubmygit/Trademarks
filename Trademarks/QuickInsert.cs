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
    public partial class QuickInsert : Form
    {
        public QuickInsert()
        {
            InitializeComponent();

            txtTMId.Text = "246883";
            dtpDepositDt.Value = new DateTime(2017, 12, 21);
            dtpDepositTime.Value = new DateTime(1900, 1, 1, 12, 33, 0);
            txtCompany.Text = "PEAK CHARM HOLDINGS LIMITED";
            txtLawyerFullname.Text = "ΤΖΑΝΕΡΡΙΚΟΥ ΙΩΑΝΝΑ";
            chlbTMType.SetItemChecked(0, true);
            chlbTMType.SetItemChecked(1, true);
            chlbTMType.SetItemChecked(5, true);
            txtTMName.Text = "XIOSBANK";
            txtDecisionNo.Text = "ΕΞ 1627 /30-03-2018";
            dtpPublicationDate.Value = new DateTime(2018, 3, 30);
            dtpFinalization.Value = new DateTime(2018, 6, 30);
            chlbClasses.SetItemChecked(34, true);
            chlbClasses.SetItemChecked(35, true);
            txtFees.Text = "181122029958 0220 0052, 181132490958 0220 0073.";
            txtDescription.Text = "Όλα εντάξει!";
            pbTMPic.Image = Image.FromFile(@"C:\Repos\Trademarks\Files\246883.jpg");
        }

        private void QuickInsert_Load(object sender, EventArgs e)
        {

        }

        private void chlbClasses_MouseHover(object sender, EventArgs e)
        {
            Point point = chlbClasses.PointToClient(Cursor.Position);
            int index = chlbClasses.IndexFromPoint(point);
            if (index < 0) return;
            
            //ToDo...
            ToolTip aaa = new ToolTip();
            aaa.SetToolTip(chlbClasses, "Κλάση " + index.ToString() + ": Testing Class.");


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //ToDo...
        }

        private void btnAddTMPic_Click(object sender, EventArgs e)
        {
            //ToDo...
        }
    }
}
