using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BIPJ
{
    public class Bank_Transactions
    {
        string _connStr = ConfigurationManager.ConnectionStrings["MainDBContext"].ConnectionString;
        private string _transactionID = null;
        private string _cardNo = null;
        private string _transactionName = null;
        private decimal _transactionAmt = 0;
        private string _transactionCat = null;
        private string _transactionDate = null;

        public Bank_Transactions()
        {
        }

        public Bank_Transactions(string transactionID, string cardNo, string transactionName, decimal transactionAmt, string transactionCat, string transactionDate)
        {
            _transactionID = transactionID;
            _cardNo = cardNo;
            _transactionName = transactionName;
            _transactionAmt = transactionAmt;
            _transactionCat = transactionCat;
            _transactionDate = transactionDate;
        }

        public Bank_Transactions(string cardNo, string transactionName, decimal transactionAmt, string transactionCat, string transactionDate) : this(null, cardNo, transactionName, transactionAmt, transactionCat, transactionDate)
        {

        }

        public Bank_Transactions(string transactionID) : this(transactionID, "", "", 0, "", "")
        {

        }

        public string Transaction_ID
        {
            get { return _transactionID; }
            set { _transactionID = value; }
        }
        public string Card_No
        {
            get { return _cardNo; }
            set { _cardNo = value; }
        }

        public string Transaction_Name
        {
            get { return _transactionName; }
            set { _transactionName = value; }
        }

        public decimal Transaction_Amt
        {
            get { return _transactionAmt; }
            set { _transactionAmt = value; }
        }

        public string Transaction_Cat
        {
            get { return _transactionCat; }
            set { _transactionCat = value; }
        }

        public string Transaction_Date
        {
            get { return _transactionDate; }
            set { _transactionDate = value; }
        }

        public Bank_Transactions getCardDetails(string cardNo)
        {
            Bank_Transactions cardDetails = null;

            string transactionID, transactionName, transactionCat, transactionDate;
            decimal transactionAmt;

            string queryStr = "SELECT * FROM Bank_Transactions WHERE Card_No = @CardNo ORDER BY Transaction_Date DESC";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@CardNo", cardNo);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                transactionID = dr["Transaction_ID"].ToString();
                transactionName = dr["Transaction_Name"].ToString();
                transactionAmt = decimal.Parse(dr["Transaction_Amt"].ToString());
                transactionCat = dr["Transaction_Cat"].ToString();
                transactionDate = dr["Transaction_Date"].ToString();

                cardDetails = new Bank_Transactions(transactionID, cardNo, transactionName, transactionAmt, transactionCat, transactionDate);
            }

            else
            {
                cardDetails = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return cardDetails;
        }

        public List<Bank_Transactions> getAllTransactions()
        {
            List<Bank_Transactions> transactionslist = new List<Bank_Transactions>();
            string transactionid, transactionName, transactionCat, transactionDate, cardNo;
            decimal transactionAmt;

            string queryStr = "Select bt.* FROM Bank_Transactions As bt INNER JOIN Cards As c on bt.Card_No = c.Card_No";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                transactionid = dr["Transaction_ID"].ToString();
                cardNo = dr["Card_No"].ToString();
                transactionName = dr["Transaction_Name"].ToString();
                transactionAmt = decimal.Parse(dr["Transaction_Amt"].ToString());
                transactionCat = dr["Transaction_Cat"].ToString();
                transactionDate = dr["Transaction_Date"].ToString();

                Bank_Transactions bt = new Bank_Transactions(transactionid, cardNo, transactionName, transactionAmt, transactionCat, transactionDate);
                transactionslist.Add(bt);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return transactionslist;
        }

        public List<decimal> getTotalAmt()
        {
            List<decimal> transactionlist = new List<decimal>();
            decimal transactionAmt;
            decimal totalamt = 0;

            string queryStr = "Select bt.Transaction_Amt FROM Bank_Transactions As bt INNER JOIN Cards As c on bt.Card_No = c.Card_No";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                transactionAmt = decimal.Parse(dr["Transaction_Amt"].ToString());
                totalamt += transactionAmt;
            }

            transactionlist.Add(totalamt);
            conn.Close();
            dr.Close();
            dr.Dispose();

            return transactionlist;

        }
    }
}