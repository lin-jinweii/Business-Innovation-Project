using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BIPJ
{
    public class Bank_Cards
    {
        string _connStr = ConfigurationManager.ConnectionStrings["MainDBContext"].ConnectionString;
        private string _cardNo = null;
        private string _expiryDate = null;
        private int _cvc = 0;
        private string _bankName = null;

        public Bank_Cards()
        {
        }

        public Bank_Cards(string cardNo, string expiryDate, int cvc, string bankName)
        {
            _cardNo = cardNo;
            _expiryDate = expiryDate;
            _cvc = cvc;
            _bankName = bankName;
        }

        public Bank_Cards(string expiryDate, int cvc, string bankName) : this("", expiryDate, cvc, bankName)
        {

        }

        public Bank_Cards(string cardNo) : this(cardNo, "", 0, "")
        {

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

        public Bank_Cards getCardBankName(string cardNo)
        {
            Bank_Cards bankNameDetails = null;

            string expiryDate, bankName;
            int cvc;

            string queryStr = "SELECT * FROM Bank_Cards WHERE Card_No = @CardNo";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@CardNo", cardNo);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                expiryDate = dr["Expiry_Date"].ToString();
                cvc = int.Parse(dr["CVC"].ToString());
                bankName = dr["Bank_Name"].ToString();

                bankNameDetails = new Bank_Cards(cardNo, expiryDate, cvc, bankName);
            }

            else
            {
                bankNameDetails = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return bankNameDetails;
        }

    }
}