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
        string _connStr = ConfigurationManager.ConnectionStrings["MainDBContext"].ConnectionString;
        private string _transactionID = null;
        private string _cardNo = null;
        private string _expiryDate = null;
        private int _cvc = 0;
        private string _bankName = null;
        private string _transactionName = null;
        private decimal _transactionAmt = 0;
        private string _transactionCat = null;
        private string _transactionDate = null;


        public Bank()
        {
        }

        public Bank(string transactionID, string cardNo, string expiryDate, int cvc, string bankName, string transactionName, decimal transactionAmt, string transactionCat, string transactionDate)
        {
            _transactionID = transactionID;
            _cardNo = cardNo;
            _expiryDate = expiryDate;
            _cvc = cvc;
            _bankName = bankName;
            _transactionName = transactionName;
            _transactionAmt = transactionAmt;
            _transactionCat = transactionCat;
            _transactionDate = transactionDate;
        }

        public Bank (string cardNo, string expiryDate, int cvc, string bankName, string transactionName, decimal transactionAmt, string transactionCat, string transactionDate) : this(null, cardNo, expiryDate, cvc, bankName, transactionName, transactionAmt, transactionCat, transactionDate)
        {

        }

        public Bank (string transactionID): this(transactionID, "", "", 0, "", "", 0, "", "") 
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

        public string Expiry_Date
        {
            get { return _expiryDate; }
            set { _expiryDate = value; }
        }

        public int CVC
        {
            get { return _cvc; }
            set { _cvc = value; }
        }

        public string Bank_Name
        {
            get { return _bankName; }
            set { _bankName = value; }
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

        public Bank getCardDetails(string cardNo)
        {
            Bank cardDetails = null;

            string transactionID, expiryDate, bankName, transactionName, transactionCat, transactionDate;
            decimal transactionAmt;
            int cvc;

            string queryStr = "SELECT * FROM Bank WHERE Card_No = @CardNo ORDER BY Transaction_Date DESC";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@CardNo", cardNo);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                transactionID = dr["Transaction_ID"].ToString();
                expiryDate = dr["Expiry_Date"].ToString();
                cvc = int.Parse(dr["CVC"].ToString());
                bankName = dr["Bank_Name"].ToString();
                transactionName = dr["Transaction_Name"].ToString();
                transactionAmt = decimal.Parse(dr["Transaction_Amt"].ToString());
                transactionCat = dr["Transaction_Cat"].ToString();
                transactionDate = dr["Transaction_Date"].ToString();

                cardDetails = new Bank(transactionID, cardNo, expiryDate, cvc, bankName, transactionName, transactionAmt, transactionCat, transactionDate);
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
    }
}