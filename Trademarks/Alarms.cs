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
    public partial class Alarms : Form
    {
        public Alarms()
        {
            InitializeComponent();
        }

        private void Alarms_Load(object sender, EventArgs e)
        {
            dgvAlarms.ClearSelection();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
