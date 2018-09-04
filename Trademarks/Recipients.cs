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
    public partial class Recipients : Form
    {
        public Recipients()
        {
            InitializeComponent();
        }

        private void Recipients_Load(object sender, EventArgs e)
        {
            dgvRecipients.ClearSelection();
        }
    }
}
