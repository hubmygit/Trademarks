using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Trademarks
{
    public partial class Report_TmBasic : DevExpress.XtraReports.UI.XtraReport
    {
        public Report_TmBasic()
        {
            InitializeComponent();
        }

        public Report_TmBasic(BindingList<Trademark_Full> TmFull_BList)
        {
            InitializeComponent();

            DataSource = TmFull_BList;
        }

    }
}
