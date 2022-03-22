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
        Bank_Transactions banktransactions = null;
        Bank_Cards bankcards = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Card aCard = new Card();
            Bank_Transactions aBankTransactions = new Bank_Transactions();
            Bank_Cards aBankCards = new Bank_Cards();

            string cardNo = Request.QueryString["Card_No"];
            card = aCard.getCard(cardNo);
            banktransactions = aBankTransactions.getCardDetails(cardNo);
            bankcards = aBankCards.getCardDetails(cardNo);

            string transactionID = Request.QueryString["Transaction_ID"];

            ImgCard.ImageUrl = "~/assets/" + card.Card_Img.ToString();
            lblCardName.Text = card.Card_Name;

            ImgBankName.ImageUrl = "~/assets/" + bankcards.Bank_Name.ToString() + ".png";
            lblBankName.Text = bankcards.Bank_Name;

            lblTransactionsName.Text = banktransactions.Transaction_Name;
            lblTransactionsDate.Text = banktransactions.Transaction_Date;
            lblTransactionsAmt.Text = banktransactions.Transaction_Amt.ToString();


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cards.aspx");
        }
    }
}