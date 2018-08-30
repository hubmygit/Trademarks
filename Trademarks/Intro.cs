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
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();

            lblLogin.AutoSize = false;
            lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblLogin.Dock = DockStyle.Fill;
        }

        public void setLoginLabel(string givenText)
        {
            lblLogin.Text = givenText;
            lblLogin.Refresh();
        }

        public void closeForm()
        {
            while (Opacity > 0.1)
            {
                Opacity -= 0.1;
            }

            Close();
        }
    }
}
