using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace WebApplication11
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConnection_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"data source=.\sqlexpress;initial catalog=librairie;user id=sa; password=P@ssw0rd");
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from [user] where email = @email", cn);
            cmd.Parameters.AddWithValue("@email", txtLogin.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            bool flag = false;
            if (dr.Read())
                if (dr["password"].ToString() == txtPwd.Text)
                    flag = true;


            dr.Close();
            dr = null;
            cmd = null;
            cn.Close();
            cn = null;


            if (flag)
            {

                Session["passport"] = "ok";
                Response.Redirect("default.aspx");

            }
            else
                lblErrConnection.Visible = true;


        }
    }
}