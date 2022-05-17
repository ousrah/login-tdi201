using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace WebApplication11
{
    public partial class login : System.Web.UI.Page
    {
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);



        public string getMac()
        {

            try
            {
                string userip = Request.UserHostAddress;
                string strClientIP = Request.UserHostAddress.ToString().Trim();
                Int32 ldest = inet_addr(strClientIP);
                Int32 lhost = inet_addr("");
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);
                string mac_src = macinfo.ToString("X");
                if (mac_src == "0")
                {
                    if (userip == "127.0.0.1")
                        Response.Write("visited Localhost!");
                    else
                        Response.Write("the IP from" + userip + "" + "<br>");
                    return "";
                }

                while (mac_src.Length < 12)
                {
                    mac_src = mac_src.Insert(0, "0");
                }

                string mac_dest = "";

                for (int i = 0; i < 11; i++)
                {
                    if (0 == (i % 2))
                    {
                        if (i == 10)
                        {
                            mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                        else
                        {
                            mac_dest = "-" + mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                    }
                }

                return mac_dest;

            }
            catch (Exception err)
            {
                return "";
            }
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            string login="", pwd = "", mac = "";
            HttpCookie c = Request.Cookies["ismo"];
            if(c!=null)
            {
                login =  myLib.DecryptSym(System.Convert.FromBase64String(c["a"]), myLib.cle, myLib.iv);
               
                pwd = myLib.DecryptSym(System.Convert.FromBase64String(c["b"]), myLib.cle, myLib.iv);
               mac = myLib.DecryptSym(System.Convert.FromBase64String(c["c"]), myLib.cle, myLib.iv);
                bool flag = connexion(login, pwd);
                if(flag && mac==getMac())
                {
                    Session["passport"] = "ok";
                    Response.Redirect("default.aspx");
                }

            }



        }


        private bool connexion(string login, string pwd)
        {
            SqlConnection cn = new SqlConnection(@"data source=.\sqlexpress;initial catalog=librairie;user id=sa; password=P@ssw0rd");
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from [user] where valide=1 and email = @email", cn);
            cmd.Parameters.AddWithValue("@email", login);
            SqlDataReader dr = cmd.ExecuteReader();
            bool flag = false;
            if (dr.Read())
                if (dr["password"].ToString() == pwd)
                    flag = true;


            dr.Close();
            dr = null;
            cmd = null;
            cn.Close();
            cn = null;

            return flag;
        }

        protected void btnConnection_Click(object sender, EventArgs e)
        {

            bool flag = connexion(txtLogin.Text, txtPwd.Text);

            if (flag)
            {

                Session["passport"] = "ok";
                if(chkConnexion.Checked)
                {
                    HttpCookie c = new HttpCookie("ismo");
                    
                    string login =Convert.ToBase64String(myLib.EncryptSym(txtLogin.Text, myLib.cle, myLib.iv));
                    string pwd = Convert.ToBase64String(myLib.EncryptSym(txtPwd.Text, myLib.cle, myLib.iv));
                    string mac = Convert.ToBase64String(myLib.EncryptSym(getMac(), myLib.cle, myLib.iv));


                    c["a"] = login;
                    c["b"] = pwd;
                    c["c"] = mac;
                    c.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(c);


                }



                Response.Redirect("default.aspx");

            }
            else
                lblErrConnection.Visible = true;


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(getMac());
        }
    }
}