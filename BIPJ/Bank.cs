using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace BIPJ
{
    public class Bank
    {
        string _connStr = ConfigurationManager.ConnectionStrings["BankDBContext"].ConnectionString;
        private string _transactionID = null;
        private string _transactionName = null;
        private string _cardtype = null;
        private decimal _amount = 0;
        private string _category = null;
        private string _date = null;

        public Bank()
        {
        }

        public Bank(string transactionID, string transactionName, string cardtype, decimal amount, string category, string date)
        {
            _transactionID = transactionID;
            _transactionName = transactionName;
            _cardtype = cardtype;
            _amount = amount;
            _category = category;
            _date = date;
        }

        public Bank (string transactionName, string cardtype, decimal amount, string category, string date): this(null, transactionName, cardtype, amount, category, date)
        {

        }

        public Bank (string transactionID): this(transactionID, "", "", 0, "", "") 
        { 

        }

        public string Transaction_ID
        {
            get { return _transactionID; }
            set { _transactionID = value; }
        }

        public string Transaction_Name
        {
            get { return _transactionName; }
            set { _transactionName = value; }
        }

        public string Card_Type
        {
            get { return _cardtype; }
            set { _cardtype = value; }
        }

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public List<Bank> getTransactionsAll()
        {
            List<Bank> transactionlist = new List<Bank>();
            string transactionName, cardType, category, transactionID, date;
            decimal amount;

            string queryStr = "SELECT * FROM Bank Order By Date";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                transactionID = dr["Transaction_ID"].ToString();
                transactionName = dr["Transaction_Name"].ToString();
                cardType = dr["Card_Type"].ToString();
                amount = decimal.Parse(dr["Amount"].ToString());
                category = dr["Category"].ToString();
                date = dr["Date"].ToString();
                Bank a = new Bank(transactionID, transactionName, cardType, amount, category, date);
                transactionlist.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return transactionlist;
        }

        protected void getTotalAmount()
        {
        }
    }
}