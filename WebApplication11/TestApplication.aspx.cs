using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class TestApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Application["nom"] = TextBox1.Text;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Application["nom"] != null)
                Label1.Text = Application["nom"].ToString();
            else
                Label1.Text = "La variable application nom n'existe pas";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Write("je peut ecrire dfans la page");
        }
    }
}