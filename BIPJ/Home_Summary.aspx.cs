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
        Budgets aBudget = new Budgets();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                decimal totalamt = aBankTransactions.getTotalAmt()[0];
                lbltotalamt.Text = totalamt.ToString();
                LoadData();
                lblMth.Text = DateTime.Now.ToString("MMM");
                lblYear.Text = DateTime.Now.Year.ToString();
                bind();

                Budgets budgetList = new Budgets();
                decimal budgetamt = aBudget.getBudget()[0];
                string month = DateTime.Now.Month.ToString();
                int result = 0;
                Budgets budget = new Budgets();
                result = budget.ActualTotalUpdate(month, budgetamt, totalamt);
                lblBudgetAmt.Text = budgetamt.ToString("C");

                LoadData2();

            }
        }

        void LoadData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDBContext"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select bt.Transaction_Cat, sum(bt.Transaction_Amt) as TotalAmt from Bank_Transactions As bt INNER JOIN Cards As c on bt.Card_No IN ('Cash', c.Card_No) group by bt.Transaction_Cat", con);
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

            foreach (DataPoint p in SummaryChart.Series["Series1"].Points)
            {
                p.Label = "#VALX\n#PERCENT";
            }
        }

        void LoadData2()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDBContext"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Budget, Actual_Total from Budget WHERE MONTH(Month) = MONTH(CURRENT_TIMESTAMP)", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }

            string[] x = new string[dt.Rows.Count];
            string[] y = new string[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = dt.Rows[i][1].ToString();
            }

            Chart1.Series["Series1"].Points.AddXY("Hm", x);
            Chart1.Series["Series2"].Points.AddXY("Hm", y);
            Chart1.Series[0].ChartType = SeriesChartType.StackedBar;

            Chart1.Series["Series1"].Color = System.Drawing.Color.Gray;
            Chart1.Series["Series2"].Color = System.Drawing.Color.Green;

            Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
            Chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

            Chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Enabled = false;
            Chart1.ChartAreas["ChartArea1"].AxisY.MajorTickMark.Enabled = false;

            Chart1.ChartAreas["ChartArea1"].AxisX.MinorTickMark.Enabled = false;
            Chart1.ChartAreas["ChartArea1"].AxisY.MinorTickMark.Enabled = false;

            Chart1.ChartAreas["ChartArea1"].AxisX.LineWidth = 0;
            Chart1.ChartAreas["ChartArea1"].AxisY.LineWidth = 0;

        }

        protected void bind()
        {
            List<Bank_Transactions> transactionList = new List<Bank_Transactions>();
            transactionList = aBankTransactions.getAllTransactions();
            this.gvCatAmt.DataSource = null;
            gvCatAmt.DataSource = transactionList;
            gvCatAmt.DataBind();
        }
    }
}