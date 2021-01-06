using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace Restaurante_Web
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string NombreUsuario = "";
            string PasswUsuario = "";
            SqlConnection con = new SqlConnection("Server = MSI; " + 
                "DataBase= BdRestauranteWeb; Integrated Security = true");
            SqlCommand cmd = new SqlCommand("select NombreUsuario, PasswUsuario from TblUsuarios where NombreUsuario=@username", con);
            cmd.Parameters.AddWithValue("@username", txtEmail.Text);
            con.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                if (sdr.Read())
                {
                    NombreUsuario = sdr["NombreUsuario"].ToString();
                    PasswUsuario = sdr["PasswUsuario"].ToString();
                }

            }
            con.Close();

            if (!string.IsNullOrEmpty(PasswUsuario))
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("adriantj1309@gmail.com");
                msg.To.Add(txtEmail.Text);
                msg.Subject = " Recover your Password";
                msg.Body = ("Your Username is:" + NombreUsuario + "<br/><br/>" + "Your Password is:" + PasswUsuario);
                msg.IsBodyHtml = true;

                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntwd = new NetworkCredential();
                ntwd.UserName = "adriantj1309@gmail.com"; //Your Email ID  
                ntwd.Password = "w123df55133sdf"; // Your Password  
                smt.UseDefaultCredentials = true;
                smt.Credentials = ntwd;
                smt.Port = 587;
                smt.EnableSsl = true;
                smt.Send(msg);
                lbmsg.Text = "Username and Password Sent Successfully";
                lbmsg.ForeColor = System.Drawing.Color.ForestGreen;
            }
        }   
    }
}

