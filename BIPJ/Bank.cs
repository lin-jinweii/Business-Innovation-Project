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
    }
}