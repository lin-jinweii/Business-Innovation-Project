using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPJ
{
    public partial class Cards : System.Web.UI.Page
    {
        Card aCard = new Card();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        protected void bind()
        {
            List<Card> cardList = new List<Card>();
            cardList = aCard.getAllCards();
            gvAllCards.DataSource = cardList;
            gvAllCards.DataBind();
            gvAllCards.Columns[0].Visible = false;
        }

        protected void btnAddNewCard_Click(object sender, EventArgs e)
        {
            pnlAddNewCard.Visible = true;
        }

        protected void btnSaveCard_Click(object sender, EventArgs e)
        {
            int result = 0;

            string visa = "4";
            string mastercard = "5";

            string cardName = "";

            if (tbcardNo.Text.StartsWith(visa))
            {
                if (tbcardNo.Text.Length == 16) {
                    string first4 = tbcardNo.Text.Substring(tbcardNo.Text.Length - 4);
                    cardName = "VISA •••• " + first4;

                    Card card = new Card(tbcardNo.Text, tbMMYY.Text, int.Parse(tbCVC.Text), cardName, "visa.jpg");
                    result = card.CardInsert();

                    if (result > 0)
                    {
                        pnlAddNewCard.Visible = false;
                        pnlAddSuccess.Visible = true;
                    }

                    else
                    {
                        Response.Write("<script>alert('Invalid card or card is added already');</script>");
                    }
                }

                else
                {
                    Response.Write("<script>alert('Invalid card');</script>");
                }

            }

            else if (tbcardNo.Text.StartsWith(mastercard))
            {
                if (tbcardNo.Text.Length == 16) {
                    string first4 = tbcardNo.Text.Substring(tbcardNo.Text.Length - 4);
                    cardName = "MASTERCARD •••• " + first4;

                    Card card = new Card(tbcardNo.Text, tbMMYY.Text, int.Parse(tbCVC.Text), cardName, "mastercard.png");
                    result = card.CardInsert();

                    if (result > 0)
                    {
                        pnlAddNewCard.Visible = false;
                        pnlAddSuccess.Visible = true;
                    }

                    else
                    {
                        Response.Write("<script>alert('Invalid card or card is added already');</script>");
                    }
                }

                else
                {
                    Response.Write("<script>alert('Invalid card');</script>");
                }
                
            }

            else
            {
                Response.Write("<script>alert('Card type is not supported');</script>");
            }
            
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            pnlAddNewCard.Visible = false;
            pnlAddSuccess.Visible = false;
            Response.Redirect("Cards.aspx");
        }

        protected void imgbtnClose_Click(object sender, ImageClickEventArgs e)
        {
            pnlAddNewCard.Visible = false;
        }

        protected void imgbtnClose_ClickV2(object sender, ImageClickEventArgs e)
        {
            pnlAddSuccess.Visible = false;
        }

        protected void gvAllCard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell mycell in e.Row.Cells)
            {
                mycell.Width = 60;
            }
        }

        protected void gvAllCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvAllCards.SelectedRow;

            string Name = row.Cells[0].Text;

            Response.Redirect("CardDetails.aspx?Card_No=" + Name);

        }

        protected void gvAllCards_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Card card = new Card();
            string catID = gvAllCards.DataKeys[e.RowIndex].Value.ToString();
            result = card.CardDelete(catID);

            if (result > 0)
            {
                pnlDeleteSuccess.Visible = true;
            }

            else
            {
                Response.Write("<script>alert('Card cannot be deleted');</script>");
            }

        }
    }
}