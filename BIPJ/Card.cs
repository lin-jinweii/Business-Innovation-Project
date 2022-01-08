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
        private string _cardNo = null;
        private string _expiryDate = null;
        private int _cvc = 0;
        private string _cardName = null;
        private string _cardImg = null;

        public Card()
        {
        }

        public Card(string cardNo, string expiryDate, int cvc, string cardName, string cardImg)
        {
            _cardNo = cardNo;
            _expiryDate = expiryDate;
            _cvc = cvc;
            _cardName = cardName;
            _cardImg = cardImg;
        }

        public Card(string expiryDate, int cvc, string cardName, string cardImg) : this("", expiryDate, cvc, cardName, cardImg)
        {

        }

        public Card(string cardNo) : this(cardNo, "", 0, "", "")
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

                cmd.Parameters.AddWithValue("@Card_No", this.Card_No);
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

        public List<Card> getAllCards()
        {
            List<Card> cardList = new List<Card>();
            string cardNo, expiryDate, cardName, cardImg;
            int cvc;

            string queryStr = "SELECT * FROM Cards Order By Card_No";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cardNo = dr["Card_No"].ToString();
                expiryDate = dr["Expiry_Date"].ToString();
                cvc = int.Parse(dr["CVC"].ToString());
                cardName = dr["Card_Name"].ToString();
                cardImg = dr["Card_Img"].ToString();
                Card c = new Card(cardNo, expiryDate, cvc, cardName, cardImg);
                cardList.Add(c);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return cardList;
        }

        public Card getCard(string cardNo)
        {
            Card cardDetail = null;

            string expiryDate, cardName, cardImg;
            int cvc;

            string queryStr = "SELECT * FROM Cards WHERE Card_No = @CardNo";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@CardNo",cardNo);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                expiryDate = dr["Expiry_Date"].ToString();
                cvc = int.Parse(dr["CVC"].ToString());
                cardName = dr["Card_Name"].ToString();
                cardImg = dr["Card_Img"].ToString();

                cardDetail = new Card(cardNo, expiryDate, cvc, cardName, cardImg);
            }

            else
            {
                cardDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return cardDetail;
        }

        public int CardDelete(string cardNo)
        {
            string queryStr = "DELETE FROM Cards WHERE Card_No = @cardNo";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@cardNo", cardNo);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }
    }
}