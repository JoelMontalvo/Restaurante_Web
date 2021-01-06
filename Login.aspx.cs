using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using CapaDatos;

namespace Restaurante_Web
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //public string encryption(String password)
        //{
        //    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        //    byte[] encrypt;
        //    UTF8Encoding encode = new UTF8Encoding();
        //    encrypt the given password string into Encrypted data
        //    encrypt = md5.ComputeHash(encode.GetBytes(password));
        //    StringBuilder encryptdata = new StringBuilder();
        //    Create a new string by using the encrypted data
        //    for (int i = 0; i < encrypt.Length; i++)
        //    {
        //        encryptdata.Append(encrypt[i].ToString());
        //    }
        //    return encryptdata.ToString();
        //}

        //private bool IsvalidUser(string NombreUsuario, string PasswUsuario)
        //{
        //    CD_ConexionDataContext context = new CD_ConexionDataContext();

        //    String password = txtContra.Text;
        //    encripación de la contraseña
        //    string passwords = encryption(password);

        //    var q = from p in context.TblUsuarios
        //            where p.NombreUsuario == txtUsuario.Text
        //            && p.PasswUsuario == passwords
        //            && p.TipoUsuario == "Admin"
        //            select p;

        //    if (q.Any())
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int intentos;
            if (txtUsuario.Text != "" && txtContra.Text != "")
            {
                String username = txtUsuario.Text.ToString();
                String password = txtContra.Text;
                SqlConnection con = new SqlConnection("Server = MSI; " +
                "DataBase= BdRestauranteWeb; Integrated Security = true");
                con.Open();
                //encripación de la contraseña
                //string passwords = encryption(password);
                SqlCommand cmd = new SqlCommand("select * from TblUsuarios where NombreUsuario=@username and PasswUsuario=@password", con);
                SqlCommand cmd1 = new SqlCommand("select NombreUsuario, PasswUsuario from TblUsuarios", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dtb = new DataTable();
                DataTable dt1 = new DataTable();
                sda.Fill(dtb);
                sda1.Fill(dt1);

                if (dtb.Rows.Count == 1)
                {
                    if (dtb.Rows[0]["TipoUsuario"].ToString() == "Admin")
                        Response.Redirect("WebPrincipal.aspx");
                    else
                        Response.Redirect("WebForm1.aspx");
                }
                else if (dt1.Rows[0][0].ToString() == txtUsuario.Text)
                {
                    //intentos=intentos + 1;
                    lblMensaje.Text = "Contraseña incorrecta. \n" +
                        "Intento #: " /*+ intentos*/;
                    txtContra.Text = "";
                    txtContra.Focus();
                    //if (intentos >= 3)
                    //{
                    //    lblMensaje.Text = "Numero de intentos excedido\n";
                    //}
                }
                else
                {
                    lblMensaje.Text = "Usuario Inexistente";
                    txtUsuario.Text = "";
                    txtContra.Text = "";
                    txtUsuario.Focus();
                }
            }
            else
            {
                lblMensaje.Text = "Ingrese Datos";
            }


            //if (IsvalidUser(txtUsuario.Text, txtContra.Text))
            //{
            //    Response.Redirect("WebPrincipal.aspx");
            //}
            //else
            //{
            //    Response.Redirect("WebForm1.aspx");
            //}
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgetPassword.aspx");
        }
    }
}