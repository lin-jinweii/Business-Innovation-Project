using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPJ
{
    public partial class Home_Transactions : System.Web.UI.Page
    {
        Bank_Transactions aBankTransactions = new Bank_Transactions();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bank_Transactions aBankTransactions = new Bank_Transactions();
                decimal totalamt = aBankTransactions.getTotalAmt()[0];
                lbltotalamt.Text = totalamt.ToString();
                bind();
            }
        }

        protected void bind()
        {
            List<Bank_Transactions> transactionList = new List<Bank_Transactions>();
            transactionList = aBankTransactions.getAllTransactions();
            gvTransactions.DataSource = transactionList;
            gvTransactions.DataBind();
            gvTransactions.Columns[0].Visible = false;
        }
    }
}