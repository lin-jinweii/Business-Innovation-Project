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
        protected void Page_Load(object sender, EventArgs e)
        {
            Card aCard = new Card();

            string cardNo = Request.QueryString["Card_No"];
            card = aCard.getCard(cardNo);

            lblCardName.Text = card.Card_Name;
        }
    }
}