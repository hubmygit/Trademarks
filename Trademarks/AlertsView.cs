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
    public partial class AlertsView : Form
    {
        public AlertsView()
        {
            InitializeComponent();

            //SELECT A.Id, A.IsActive, A.NotificationDate, A.NotificationSent, E.Name as EventType, 'Period' as ToDo2, A.TrademarksId,
            //       T.TMNo, T.TMName, T.DepositDt, T.RenewalDt, N.Name as NationalPower, C.Name as Company, L.FullName as ResponsibleLawyer
            //FROM [dbo].[Tasks] A left outer join 
            //     [dbo].[TempRecords] T on A.TrademarksId = T.Id left outer join 
            //	   [dbo].[EventTypes] E on A.EventTypesId = E.Id left outer join 
            //	   [dbo].[NationalPower] N on T.NationalPowerId = N.Id left outer join 
            //	   [dbo].[Company] C on T.CompanyId = C.Id left outer join 
            //	   [dbo].[Responsible] L on T.ResponsibleLawyerId = L.Id

        }
    }
}
