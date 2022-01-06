using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BIPJ
{
    public class Card
    {
        string _connStr = ConfigurationManager.ConnectionStrings["BankDBContext"].ConnectionString;
        private int _cardNo = 0;
        private string _expiryDate = null;
        private int _cvc = 0;
        private string _cardName = null;
        private string _cardImg = null;

        public Card()
        {
        }

        public Card(int cardNo, string expiryDate, int cvc, string cardName, string cardImg)
        {
            _cardNo = cardNo;
            _expiryDate = expiryDate;
            _cvc = cvc;
            _cardName = cardName;
            _cardImg = cardImg;
        }

        public Card(string expiryDate, int cvc, string cardName, string cardImg) : this(0, expiryDate, cvc, cardName, cardImg)
        {

        }

        public Card(int cardNo) : this(cardNo, "", 0, "", "")
        {

        }

        public int CardNo
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

        public string Card_Name
        {
            get { return _cardName; }
            set { _cardName = value; }
        }

        public string Card_Img
        {
            get { return _cardImg; }
            set { _cardImg = value; }
        }

        public int CardInsert()
        {
            int result = 0;

            string queryStr = "INSERT INTO Cards(Card_No, Expiry_Date, CVC, Card_Name, Card_Img)" + "values(@Card_No, @Expiry_Date, @CVC, @Card_Name, @Card_Img)";

            try {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);

                cmd.Parameters.AddWithValue("@Card_No", this.CardNo);
                cmd.Parameters.AddWithValue("@Expiry_Date", this.Expiry_Date);
                cmd.Parameters.AddWithValue("@CVC", this.CVC);
                cmd.Parameters.AddWithValue("@Card_Name", this.Card_Name);
                cmd.Parameters.AddWithValue("@Card_Img", this.Card_Img);

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