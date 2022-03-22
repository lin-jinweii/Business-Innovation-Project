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
    public partial class Budget1 : System.Web.UI.Page
    {
        Bank_Transactions aBankTransactions = new Bank_Transactions();
        Budgets aBudget = new Budgets();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                BindTransaction_Cat();
                decimal budgetamt = aBudget.getBudget()[0];
                decimal expenseamt = aBankTransactions.getTotalAmt()[0];
                lblMth.Text = "(" + DateTime.Now.ToString("MMM") + ")";
                lblMth2.Text = "(" + DateTime.Now.ToString("MMM") + ")";
                lblBudgetAmt.Text = budgetamt.ToString("C");
                lblExpenseAmt.Text = expenseamt.ToString("C");
                ddlBudget.SelectedValue = "Feb";
            }
        }

        void LoadData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDBContext"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select DATENAME(MONTH, Month), Budget, Actual_Total from Budget", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            int[] z = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
                z[i] = Convert.ToInt32(dt.Rows[i][2]);
            }

            BudgetChart.Series[0].Points.DataBindXY(x, y);
            BudgetChart.Series[1].Points.DataBindXY(x, z);

            BudgetChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            BudgetChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

        }

        protected void BindTransaction_Cat()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDBContext"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select LEFT(DATENAME(MONTH, Month), 3) As Mth from Budget ORDER BY (case LEFT(DATENAME(MONTH, Month), 3) when 'Jan' then 1 when 'Feb' then 2 when 'Mar' then 3 END)", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                ddlBudget.DataSource = dt;
                ddlBudget.DataTextField = "Mth";
                ddlBudget.DataValueField = "Mth";
                ddlBudget.DataBind();
                LoadData();
            }
        }

        protected void ddlBudget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBudget.SelectedItem.Text == "")
            {
                ddlBudget.SelectedItem.Text = DateTime.Now.ToString();
                LoadData();
            }

            else
            {
                string mainconn = ConfigurationManager.ConnectionStrings["MainDBContext"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "Select * from Budget WHERE LEFT(DATENAME(MONTH, Month), 3) = '" + ddlBudget.SelectedItem.Text + "'";
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sqlconn.Close();
                lblMth.Text = "(" + ddlBudget.SelectedItem.Text + ")";
                lblMth2.Text = "(" + ddlBudget.SelectedItem.Text + ")";

                foreach (DataRow row in dt.Rows)
                {
                    decimal budgetamt = Convert.ToDecimal(row["Budget"]);
                    lblBudgetAmt.Text = budgetamt.ToString("C");

                    if (budgetamt == 0)
                    {
                        lblBudgetAmt.Visible = false;
                        LBInsert.Visible = true;
                    }
                    
                    else
                    {
                        lblBudgetAmt.Visible = true;
                        LBInsert.Visible = false;
                    }

                    decimal expenseamt = Convert.ToDecimal(row["Actual_Total"]);
                    lblExpenseAmt.Text = expenseamt.ToString("C");
                }

                LoadData();
            }
        }

        protected void LBInsert_Click(object sender, EventArgs e)
        {
            pnlAddBudget.Visible = true;
            LoadData();
        }

        protected void imgbtnClose_Click(object sender, EventArgs e)
        {
            pnlAddBudget.Visible = false;
            LoadData();
        }

        protected void btn_AddBudget_Click(object sender, EventArgs e)
        {
            pnlAddBudget.Visible = false;
            pnlAddBudgetCfm.Visible = true;
            lblsure.Text = tb_Amount.Text;
            LoadData();
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            Bank_Transactions aBankTransactions = new Bank_Transactions();
            decimal totalamt = 0;
            decimal budgetamt = Convert.ToDecimal(tb_Amount.Text);
            string mth = ddlBudget.SelectedItem.Text;
            int result = 0;
            Budgets budget = new Budgets();
            result = budget.BudgetUpdate(mth, budgetamt, totalamt);
            pnlAddBudget.Visible = false;
            Response.Redirect("Budget.aspx");
            LoadData();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            pnlAddBudget.Visible = false;
            pnlAddBudgetCfm.Visible = false;
            LoadData();
        }
    }
}   