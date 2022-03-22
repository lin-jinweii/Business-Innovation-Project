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
    public partial class Home_Transactions : System.Web.UI.Page
    {
        Bank_Transactions aBankTransactions = new Bank_Transactions();
        Budgets aBudget = new Budgets();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bank_Transactions aBankTransactions = new Bank_Transactions();
                decimal totalamt = aBankTransactions.getTotalAmt()[0];
                lbltotalamt.Text = totalamt.ToString();
                BindTransaction_Cat();
                bind();

                Budgets budgetList = new Budgets();
                decimal budgetamt = aBudget.getBudget()[0];
                string month = DateTime.Now.Month.ToString();
                int result = 0;
                Budgets budget = new Budgets();
                result = budget.ActualTotalUpdate(month, budgetamt, totalamt);
                lblBudgetAmt.Text = budgetamt.ToString("C");

                calendarPopup.Visible = false;

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

        protected void btnAddCash_Click(object sender, EventArgs e)
        {
            pnlAddCash.Visible = true;
            LoadData2();
        }

        protected void imgbtnClose_Click(object sender, EventArgs e)
        {
            pnlAddCash.Visible = false;
            LoadData2();
        }

        protected void calendar_Click(object sender, ImageClickEventArgs e)
        {
            if (calendarPopup.Visible == false)
            {
                calendarPopup.Visible = true;
            }
            else
            {
                calendarPopup.Visible = false;
            }
        }

        protected void calendarPopup_SelectionChanged(object sender, EventArgs e)
        {
            tb_Date.Text = calendarPopup.SelectedDate.ToString("yyyy/MM/dd");
            calendarPopup.Visible = false;
        }

        protected void btn_AddCash_Click(object sender, EventArgs e)
        {
            int result = 0;

            Bank_Transactions abank = new Bank_Transactions("Cash", tb_TransactionName.Text, Convert.ToDecimal(tb_Amount.Text), ddl_Category.Text, tb_Date.Text, "Cash");
            result = abank.TransactionInsert();

            if (result > 0)
            {
                pnlAddCash.Visible = false;
                Response.Redirect("Home_Transactions.aspx");
            }

            else
            {
                Response.Write("<script>alert('Sudden Error');</script>");
            }
        }

        protected void calendarPopup_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Today)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void BindTransaction_Cat()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDBContext"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select DISTINCT bt.Transaction_Cat FROM Bank_Transactions As bt INNER JOIN Cards As c on bt.Card_No IN(c.Card_No) WHERE MONTH(Transaction_Date) = MONTH(CURRENT_TIMESTAMP)", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                ddlCat.DataSource = dt;
                ddlCat.DataTextField = "Transaction_Cat";
                ddlCat.DataValueField = "Transaction_Cat";
                ddlCat.DataBind();
                ddlCat.Items.Insert(0, new ListItem("All", ""));
                LoadData2();
            }
        }

        protected void ddlCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCat.SelectedItem.Text == "All")
            {
                string mainconn = ConfigurationManager.ConnectionStrings["MainDBContext"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "Select bt.* FROM Bank_Transactions As bt INNER JOIN Cards As c on bt.Card_No IN(c.Card_No) WHERE MONTH(Transaction_Date) = MONTH(CURRENT_TIMESTAMP)";
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                this.gvTransactions.DataSource = null;
                gvTransactions.DataSource = dt;
                gvTransactions.DataBind();
                sqlconn.Close();
                LoadData2();
            }

            else
            {
                string mainconn = ConfigurationManager.ConnectionStrings["MainDBContext"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "Select bt.* FROM Bank_Transactions As bt INNER JOIN Cards As c on bt.Card_No IN(c.Card_No) WHERE Transaction_Cat = '" + ddlCat.SelectedItem.Text + "' AND MONTH(Transaction_Date) = MONTH(CURRENT_TIMESTAMP)";
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvTransactions.DataSource = dt;
                gvTransactions.DataBind();
                sqlconn.Close();
                LoadData2();
            }

        }
    }
}