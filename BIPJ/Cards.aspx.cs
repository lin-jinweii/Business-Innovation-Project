using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.Net.Mail;

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

            Bank_Cards bankcards = null;
            Bank_Cards aBankCards = new Bank_Cards();

            if (tbcardNo.Text.StartsWith(visa))
            {
                if (tbcardNo.Text.Length == 16)
                {
                    string first4 = tbcardNo.Text.Substring(tbcardNo.Text.Length - 4);
                    cardName = "VISA •••• " + first4;

                    bankcards = aBankCards.getCardDetails(tbcardNo.Text);
                    if (tbMMYY.Text == bankcards.Expiry_Date.ToString())
                    {
                        if (tbCVC.Text == bankcards.CVC.ToString())
                        {
                            Card card = new Card(tbcardNo.Text, tbMMYY.Text, int.Parse(tbCVC.Text), cardName, "visa.jpg");
                            result = card.CardInsert();

                            if (result > 0)
                            {
                                string from = "jedsmartfridge@gmail.com";
                                string password = "legendx34";

                                string from2 = "$Z@gmail.com";

                                MailMessage msg = new MailMessage();
                                msg.Subject = "[SECURITY] $Z Access to Your Card";
                                msg.From = new MailAddress(from2);
                                msg.IsBodyHtml = true;
                                msg.Body = "Dear Daryl, <br/> <br/>" + cardName + " was added into the $Z system. <br/> <br/> Yours Sincerely, <br/> $Z Team";
                                msg.To.Add(new MailAddress("jedsmartfridge@gmail.com"));

                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = "smtp.gmail.com";
                                smtp.Port = 587;
                                smtp.UseDefaultCredentials = false;
                                smtp.EnableSsl = true;
                                NetworkCredential nc = new NetworkCredential(from, password);
                                smtp.Credentials = nc;
                                smtp.Send(msg);

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
                            Response.Write("<script>alert('Wrong Card Details');</script>");
                        }

                    }

                    else
                    {
                        Response.Write("<script>alert('Wrong Card Details');</script>");
                    }
                }

                else
                {
                    Response.Write("<script>alert('Invalid card');</script>");
                }

            }

            else if (tbcardNo.Text.StartsWith(mastercard))
            {
                if (tbcardNo.Text.Length == 16)
                {
                    string first4 = tbcardNo.Text.Substring(tbcardNo.Text.Length - 4);
                    cardName = "MASTERCARD •••• " + first4;

                    bankcards = aBankCards.getCardDetails(tbcardNo.Text);
                    if (tbMMYY.Text == bankcards.Expiry_Date.ToString())
                    {
                        if (tbCVC.Text == bankcards.CVC.ToString())
                        {
                            Card card = new Card(tbcardNo.Text, tbMMYY.Text, int.Parse(tbCVC.Text), cardName, "mastercard.png");
                            result = card.CardInsert();

                            if (result > 0)
                            {
                                string from = "jedsmartfridge@gmail.com";
                                string password = "legendx34";

                                string from2 = "$Z@gmail.com";

                                MailMessage msg = new MailMessage();
                                msg.Subject = "[SECURITY] $Z Access to Your Card";
                                msg.From = new MailAddress(from2);
                                msg.IsBodyHtml = true;
                                msg.Body = "Dear Daryl, <br/> <br/>" + cardName + " was added into the $Z system. <br/> <br/> Yours Sincerely, <br/> $Z Team";
                                msg.To.Add(new MailAddress("jedsmartfridge@gmail.com"));

                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = "smtp.gmail.com";
                                smtp.Port = 587;
                                smtp.UseDefaultCredentials = false;
                                smtp.EnableSsl = true;
                                NetworkCredential nc = new NetworkCredential(from, password);
                                smtp.Credentials = nc;
                                smtp.Send(msg);

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
                            Response.Write("<script>alert('Wrong Card Details');</script>");
                        }

                    }

                    else
                    {
                        Response.Write("<script>alert('Wrong Card Details');</script>");
                    }
                }

                else
                {
                    Response.Write("<script>alert('Card type is not supported');</script>");
                }
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].Text.Equals("Cash")) {
                    e.Row.Visible = false;
                }
            }

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