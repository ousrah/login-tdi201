using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;


namespace WebApplication11
{
    public partial class inscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        protected void btnInscription_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"data source=.\sqlexpress;initial catalog=librairie;user id=sa; password=P@ssw0rd");
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from [user] where email = @email", cn);
            cmd.Parameters.AddWithValue("@email", txtLogin.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            bool flag = false;
            if (dr.Read())
                   flag = true;

            dr.Close();
            dr = null;

            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(DateTime.Now.ToString()))
                sb.Append(b.ToString("X2"));
            string hash = sb.ToString();


            if (flag)
            {
                lblErrExist.Visible = true;
                cmd = null;
                cn.Close();
                cn = null;
            }
            else
            {
                cmd.CommandText = "insert into [user] (email, nom, password,valide, hash) values (@email, @nom,@password,0,@hash)";
                cmd.Parameters.AddWithValue("@nom", txtnom.Text);
                cmd.Parameters.AddWithValue("@password", txtpwd1.Text);
                cmd.Parameters.AddWithValue("@hash", hash);
                cmd.ExecuteNonQuery();
                cmd = null;
                cn.Close();
                cn = null;


                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("ismotdi202@outlook.com");
                mail.Subject = "inscription ismo tétouan";
                mail.Body = "votre inscription à <b> ismo.ma</b> à été effectuée avec succés, cliquez sur le lien suivant pour valider votre inscription <br /><br /><a href = 'https://localhost:44325/validationInscription.aspx?email=" + txtLogin.Text  + "&hash="+hash+"' > https://localhost:44325/validationInscription.aspx?email=" + txtLogin.Text+ "&hash=" + hash + "</ a > ";


                mail.IsBodyHtml = true;


                mail.To.Add(txtLogin.Text);

                SmtpClient smtp = new SmtpClient("smtp.outlook.com", 587);

                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("ismotdi202@outlook.com", "ISMO@2022");

                try
                {
                    smtp.Send(mail);
                    Response.Redirect("Inscriptioneffectuee.aspx");

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }



                Response.Redirect("login.aspx");

            }

          


        }
    }
}