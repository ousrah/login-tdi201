using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class TestCookies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie c = new HttpCookie("maCookie");
            c["nom"] = TextBox1.Text;
            c["prennom"] = "qlq";
            c["age"] = "21";
            c.Expires = DateTime.Now.AddDays(365*7);
            Response.Cookies.Add(c);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HttpCookie c = Request.Cookies["maCookie"];
            if (c != null)
                if (c["nom"] != null)
                    Label1.Text = c["nom"];
                else
                    Label1.Text = "la variable nom n'existe pas dans la cookie (maCookie)";
            else
                Label1.Text = "la cookie (maCookie) n'existe pas";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            HttpCookie c = Request.Cookies["maCookie"];
           c.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(c);
        }
    }
}