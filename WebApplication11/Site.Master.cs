using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["passport"] != null)
            {
                if (Session["passport"].ToString() != "ok")
                    Response.Redirect("login.aspx");
            }
            else
                Response.Redirect("login.aspx");
        } 
    }
}