using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace WebApplication11
{
    public partial class validationInscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string email = Request.QueryString["email"].ToString();
            string hash = Request.QueryString["hash"].ToString();

            string req = "update [user] set valide=1 where email = @email and hash=@hash ";


            SqlConnection cn = new SqlConnection(@"data source=.\sqlexpress;initial catalog=librairie;user id=sa; password=P@ssw0rd");
            cn.Open();
            SqlCommand cmd = new SqlCommand(req, cn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@hash", hash);
            cmd.ExecuteNonQuery();
            cmd = null;
            cn.Close();
            cn = null;

            Response.Redirect("login.aspx");
        }
    }
}