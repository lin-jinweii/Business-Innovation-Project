using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPJ
{
    public partial class CardDetails : System.Web.UI.Page
    {
        Card card = null;
        Bank bank = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Card aCard = new Card();
            Bank aBank = new Bank();

            string cardNo = Request.QueryString["Card_No"];
            card = aCard.getCard(cardNo);
            bank = aBank.getCardDetails(cardNo);

            string transactionID = Request.QueryString["Transaction_ID"];

            ImgCard.ImageUrl = "~/assets/" + card.Card_Img.ToString();
            lblCardName.Text = card.Card_Name;

            ImgBankName.ImageUrl = "~/assets/" + bank.Bank_Name.ToString() + ".png";
            lblBankName.Text = bank.Bank_Name;

            lblTransactionsName.Text = bank.Transaction_Name;
            lblTransactionsDate.Text = bank.Transaction_Date;
            lblTransactionsAmt.Text = bank.Transaction_Amt.ToString();


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cards.aspx");
        }
    }
}