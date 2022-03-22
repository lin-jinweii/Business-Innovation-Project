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
        private string _cardName = null;

        public Bank_Transactions()
        {
        }

        public Bank_Transactions(string transactionID, string cardNo, string transactionName, decimal transactionAmt, string transactionCat, string transactionDate, string cardName)
        {
            _transactionID = transactionID;
            _cardNo = cardNo;
            _transactionName = transactionName;
            _transactionAmt = transactionAmt;
            _transactionCat = transactionCat;
            _transactionDate = transactionDate;
            _cardName = cardName;
        }

        public Bank_Transactions(string cardNo, string transactionName, decimal transactionAmt, string transactionCat, string transactionDate, string cardName) : this(null, cardNo, transactionName, transactionAmt, transactionCat, transactionDate, cardName)
        {

        }

        public Bank_Transactions(string transactionID) : this(transactionID, "", "", 0, "", "", "")
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
        public string Card_Name
        {
            get { return _cardName; }
            set { _cardName = value; }
        }

        public Bank_Transactions getCardDetails(string cardNo)
        {
            Bank_Transactions cardDetails = null;

            string transactionID, transactionName, transactionCat, transactionDate, cardName;
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
                cardName = dr["Card_Name"].ToString();

                cardDetails = new Bank_Transactions(transactionID, cardNo, transactionName, transactionAmt, transactionCat, transactionDate, cardName);
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
            string transactionid, transactionName, transactionCat, transactionDate, cardNo, cardName;
            decimal transactionAmt;

            string queryStr = "Select bt.* FROM Bank_Transactions As bt INNER JOIN Cards As c on bt.Card_No IN (c.Card_No) WHERE MONTH(bt.Transaction_Date) = MONTH(CURRENT_TIMESTAMP) ORDER BY bt.Transaction_Date DESC";

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
                cardName = dr["Card_Name"].ToString();

                Bank_Transactions bt = new Bank_Transactions(transactionid, cardNo, transactionName, transactionAmt, transactionCat, transactionDate, cardName);
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

            string queryStr = "Select bt.Transaction_Amt FROM Bank_Transactions As bt INNER JOIN Cards As c on bt.Card_No IN (c.Card_No) WHERE MONTH(bt.Transaction_Date) = MONTH(CURRENT_TIMESTAMP)";

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

        public List<string> getAllCat()
        {
            List<string> transactionlist = new List<string>();
            string transactionCat;

            string queryStr = "Select bt.Transaction_Cat FROM Bank_Transactions As bt INNER JOIN Cards As c on bt.Card_No IN (c.Card_No) WHERE MONTH(bt.Transaction_Date) = MONTH(CURRENT_TIMESTAMP)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                transactionCat = dr["Transaction_Cat"].ToString();
                transactionlist.Add(transactionCat);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return transactionlist;

        }

        public List<decimal> getCatAmt()
        {
            List<decimal> transactionlist = new List<decimal>();
            decimal transactionAmt;

            string queryStr = "Select SUM(bt.Transaction_Amt) FROM Bank_Transactions As bt INNER JOIN Cards As c on bt.Card_No IN (c.Card_No) WHERE MONTH(bt.Transaction_Date) = MONTH(CURRENT_TIMESTAMP) GROUP BY bt.Transaction_Cat";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                transactionAmt = decimal.Parse(dr["Transaction_Cat"].ToString());
                transactionlist.Add(transactionAmt);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return transactionlist;

        }

        public List<Bank_Transactions> getTransaction(string transactionDate)
        {
            List<Bank_Transactions> cardDetails = new List<Bank_Transactions>();

            string transactionID, cardNo, transactionName, transactionCat, cardName;
            decimal transactionAmt;

            string queryStr = "Select bt.* FROM Bank_Transactions As bt INNER JOIN Cards As c on bt.Card_No IN (c.Card_No) WHERE bt.Transaction_Date = @TransactionDate";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@TransactionDate", transactionDate);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                transactionID = dr["Transaction_ID"].ToString();
                cardNo = dr["Card_No"].ToString();
                transactionName = dr["Transaction_Name"].ToString();
                transactionAmt = decimal.Parse(dr["Transaction_Amt"].ToString());
                transactionCat = dr["Transaction_Cat"].ToString();
                cardName = dr["Card_Name"].ToString();

                Bank_Transactions bt = new Bank_Transactions(transactionID, cardNo, transactionName, transactionAmt, transactionCat, transactionDate, cardName);
                cardDetails.Add(bt);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return cardDetails;
        }

        public int TransactionInsert()
        {
            int result = 0;

            string queryStr = "INSERT INTO Bank_Transactions(Card_No, Transaction_Name, Transaction_Amt, Transaction_Cat, Transaction_Date, Card_Name)" + "values(@Card_No, @Transaction_Name, @Transaction_Amt, @Transaction_Cat, @Transaction_Date, @Card_Name)";

            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);

                cmd.Parameters.AddWithValue("@Card_No", this.Card_No);
                cmd.Parameters.AddWithValue("@Transaction_Name", this.Transaction_Name);
                cmd.Parameters.AddWithValue("@Transaction_Amt", this.Transaction_Amt);
                cmd.Parameters.AddWithValue("@Transaction_Cat", this.Transaction_Cat);
                cmd.Parameters.AddWithValue("@Transaction_Date", this.Transaction_Date);
                cmd.Parameters.AddWithValue("@Card_Name", this.Card_Name);

                conn.Open();
                result += cmd.ExecuteNonQuery();
                conn.Close();

                return result;
            }

            catch
            {
                return 0;
            }

        }
    }
}