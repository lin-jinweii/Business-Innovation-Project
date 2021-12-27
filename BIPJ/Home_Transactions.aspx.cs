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
        Bank aBank = new Bank();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        protected void bind()
        {
            List<Bank> transactionlist = new List<Bank>();
            transactionlist = aBank.getTransactionsAll();
            gvTransactions.DataSource = transactionlist;
            gvTransactions.DataBind();
        }
    }
}