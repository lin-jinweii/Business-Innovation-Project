using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPJ
{
    public partial class Calendar1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            calendartransaction.SelectedDate = DateTime.Today;
        }

        protected void calendartransaction_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
            {
                e.Cell.Controls.Clear();
                e.Cell.Text = string.Empty;
            }
        }
    }
}