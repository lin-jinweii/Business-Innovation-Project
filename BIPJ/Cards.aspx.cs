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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNewCard_Click(object sender, EventArgs e)
        {
            pnlAddNewCard.Visible = true;
        }

        protected void btnSaveCard_Click(object sender, EventArgs e)
        {
            int result = 0;

            Card card = new Card(Int32.Parse(tbcardNo.Text), tbMMYY.Text, int.Parse(tbCVC.Text), "", "");
            result = card.CardInsert();

            if (result > 0)
            {
                pnlAddNewCard.Visible = false;
                pnlAddSuccess.Visible = true;
            }

            else
            {
                Response.Write("<script>alert('Insert NOT successful');</script>");
            }
            
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            pnlAddNewCard.Visible = false;
            pnlAddSuccess.Visible = false;
        }

        protected void imgbtnClose_Click(object sender, ImageClickEventArgs e)
        {
            pnlAddNewCard.Visible = false;
        }

        protected void imgbtnClose_ClickV2(object sender, ImageClickEventArgs e)
        {
            pnlAddSuccess.Visible = false;
        }
    }
}