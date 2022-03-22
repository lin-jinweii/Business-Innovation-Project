using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BIPJ
{
    public class Budgets
    {
        string _connStr = ConfigurationManager.ConnectionStrings["MainDBContext"].ConnectionString;
        private string _month = null;
        private decimal _budget = 0;
        private decimal _actualTotal = 0;

        public Budgets()
        {
        }

        public Budgets(string month, decimal budget, decimal actualTotal)
        {
            _month = month;
            _budget = budget;
            _actualTotal = actualTotal;
        }

        public Budgets(decimal budget, decimal actualTotal) : this("", budget, actualTotal)
        {
        }

        public Budgets(string month) : this(month, 0, 0)
        {
        }

        public string Month
        {
            get { return _month; }
            set { _month = value; }
        }

        public decimal Budget
        {
            get { return _budget; }
            set { _budget = value; }
        }

        public decimal Actual_Total
        {
            get { return _actualTotal; }
            set { _actualTotal = value; }
        }

        public List<decimal> getBudget()
        {
            List<decimal> list = new List<decimal>();
            decimal bbudget;

            string queryStr = "SELECT Budget FROM Budget WHERE MONTH(Month) = MONTH(CURRENT_TIMESTAMP)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                bbudget = decimal.Parse(dr["Budget"].ToString());
                list.Add(bbudget);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return list;
        }

        public int ActualTotalUpdate(string bmonth, decimal bbudget, decimal bactualamt)
        {
            string queryStr = "UPDATE Budget SET " + "Budget = @budget, " + "Actual_Total = @actualtotal " + "WHERE MONTH(Month) = @month";

            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);

                cmd.Parameters.AddWithValue("@month", bmonth);
                cmd.Parameters.AddWithValue("@budget", bbudget);
                cmd.Parameters.AddWithValue("@actualtotal", bactualamt);


                conn.Open();
                int nofRow = 0;
                nofRow = cmd.ExecuteNonQuery();

                conn.Close();

                return nofRow;

            }

            catch
            {
                return 0;
            }

        }

        public int BudgetUpdate(string bmonth, decimal bbudget, decimal bactualamt)
        {
            string queryStr = "UPDATE Budget SET " + "Budget = @budget, " + "Actual_Total = @actualtotal " + "WHERE LEFT(DATENAME(MONTH, Month), 3) = @month";

            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);

                cmd.Parameters.AddWithValue("@month", bmonth);
                cmd.Parameters.AddWithValue("@budget", bbudget);
                cmd.Parameters.AddWithValue("@actualtotal", bactualamt);


                conn.Open();
                int nofRow = 0;
                nofRow = cmd.ExecuteNonQuery();

                conn.Close();

                return nofRow;

            }

            catch
            {
                return 0;
            }

        }

    }
}