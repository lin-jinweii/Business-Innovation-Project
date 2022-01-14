using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace BIPJ
{
    public partial class Home_Summary : System.Web.UI.Page
    {
        Bank_Transactions aBankTransactions = new Bank_Transactions();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bank_Transactions aBankTransactions = new Bank_Transactions();
                decimal totalamt = aBankTransactions.getTotalAmt()[0];
                lbltotalamt.Text = totalamt.ToString();
                LoadData();
                lblMth.Text = DateTime.Now.ToString("MMM");
                lblYear.Text = DateTime.Now.Year.ToString();
                bind();
            }
        }

        void LoadData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDBContext"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select bt.Transaction_Cat, sum(bt.Transaction_Amt) as TotalAmt from Bank_Transactions As bt INNER JOIN Cards As c on bt.Card_No = c.Card_No group by bt.Transaction_Cat", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }

            SummaryChart.Series[0].Points.DataBindXY(x, y);
            SummaryChart.Series[0].ChartType = SeriesChartType.Pie;
            SummaryChart.Series[0].LegendText = "#VALX";

            foreach (DataPoint p in SummaryChart.Series["Series1"].Points)
            {
                p.Label = "#VALX\n#PERCENT";
            }
        }

        protected void bind()
        {
            List<Bank_Transactions> transactionList = new List<Bank_Transactions>();
            transactionList = aBankTransactions.getAllTransactions();
            gvCatAmt.DataSource = transactionList;
            gvCatAmt.DataBind();
        }
    }
}