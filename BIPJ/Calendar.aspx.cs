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
        Bank_Transactions banktransactions = new Bank_Transactions();
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
            lbldate.Text = calendartransaction.SelectedDate.ToString("yyyy/MM/dd");

            List<Bank_Transactions> cardList = new List<Bank_Transactions>();
            cardList = banktransactions.getTransaction(lbldate.Text);

            gvTransactionDate.DataSource = cardList;
            gvTransactionDate.DataBind();

            if (gvTransactionDate.Rows.Count < 1)
            {
                lblnotransaction.Text = "No Transactions";
            }
        }
    }
}