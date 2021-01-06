using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using CapaNegocio;
using System.Security.Cryptography;
using System.Text;

namespace Restaurante_Web
{
    public partial class WebPrincipal : System.Web.UI.Page
    {
        //Se va a crear la cadena de conexion a la BD
        //SqlConnection con = new SqlConnection(@"Data Source= MSI;Initial Catalog= WebVisual;Integrated Security=true");
        CN_Usuario objCN = new CN_Usuario();
        CN_Platos objCNP = new CN_Platos();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnEliminar.Enabled = false;
                listarUsuarios();
                listarPlatos();
                //txtFecha.Text = DateTime.Now.ToString();
            }
        }

        //metodo para traer la infromación 

        private void listarUsuarios()
        {
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
            //SqlDataAdapter sda = new SqlDataAdapter("MostrarContacto",con);
            //sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            //DataTable dtb = new DataTable();
            //sda.Fill(dtb);
            //con.Close();
            //grvContacto.DataSource = dtb;
            //grvContacto.DataBind();
            //CD_ConexionDataContext conect = new CD_ConexionDataContext();
            var res = objCN.MostrarUsuarios();

            grvUsuarios.DataSource = res;
            grvUsuarios.DataBind();
        }

        private void listarPlatos()
        {
            var res = objCNP.MostrarPlatos();

            grvPlatos.DataSource = res;
            grvPlatos.DataBind();
        }

        private void Limpiar()
        {
            hdf.Value = hdf1.Value = "";
            txtUsu.Text = txtPass.Text = txtTipo.Text = txtNomPlato.Text = txtPrecPlato.Text = txtTipoPlato.Text = "";
            lblMensaje.Text = lblError.Text = lblMensaje1.Text = lblError1.Text ="";
            //lblMensaje.Visible = lblError.Visible = lblMensaje1.Visible = lblError1.Visible = false;
            btnGuardar.Text = btnGuardarPlato.Text = "Guardar";
            btnEliminar.Enabled = btnEliminarPlato.Enabled = false;
        }

        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Se realiza el guardado de datos a travez de un PA en elcaso de que el hf sea 0 
            //sera una inserción o actualización
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("CreaEditaContacto", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@Contactoid",(hdf.Value == "" ? 0: Convert.ToInt32(hdf.Value)));
            //    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
            //    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
            //    cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text.Trim());
            //    cmd.Parameters.AddWithValue("@Fecha", txtFecha.Text.Trim());
            //    cmd.ExecuteNonQuery();
            //    con.Close();

            //    string contactoID = hdf.Value;

            //    if (contactoID == "")
            //    {
            //        lblMensaje.Text = "Guardado con éxito";
            //    }
            //    else
            //    {
            //        lblMensaje.Text = "Datos actualizados con éxito";
            //    }
            //}

            String password = txtPass.Text;
            //Get the encrypt the password by using the class  
            string pass = encryption(password);

            string usuID = hdf.Value;

            if (usuID == "")
            {
                objCN.InsetarUsuarios(txtUsu.Text, pass, txtTipo.Text);
                lblMensaje.Text = "Usuario Guardado con Exito";

                listarUsuarios(); 
            }
            else
            {
                objCN.EditarUsuarios(txtUsu.Text, txtPass.Text, txtTipo.Text, hdf.Value);
                lblMensaje.Text = "Usuario Actualizado con Exito";

                listarUsuarios();               
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
            //SqlCommand scm = new SqlCommand("EliminarContacto",con);
            //scm.CommandType = CommandType.StoredProcedure;
            //scm.Parameters.AddWithValue("@ContactoId",Convert.ToInt32(hdf.Value));
            //scm.ExecuteNonQuery();

            //Limpiar();
            //listarUsuarios();

            //lblMensaje.Text = "Datos Borrados";

            string usuID = hdf.Value;

            if (usuID == "")
            {               
                lblMensaje.Text = "Por favor Seleccione un Registro";

                listarUsuarios();
            }
            else
            {
                objCN.EliminarUsuarios(hdf.Value);
                lblMensaje.Text = "Usuario Eliminado con Exito";

                listarUsuarios();               
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //protected void btnSeleccionar_Click(object sender, EventArgs e)
        //{
        //    int contactoID = Convert.ToInt32((sender as Button).CommandArgument);

        //    if (con.State == ConnectionState.Closed)
        //    {
        //        con.Open();
        //    }
        //    SqlDataAdapter sda1 = new SqlDataAdapter("BuscarContacto", con);
        //    sda1.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    sda1.SelectCommand.Parameters.AddWithValue("@Contactoid", contactoID);
        //    DataTable dtb1 = new DataTable();
        //    sda1.Fill(dtb1);
        //    con.Close();

        //    var res = objCN.MostrarUsuariosid(hdf.Value);

        //    hdf.Value = contactoID.ToString();

        //    txtUsu.Text = grvContacto.Rows[0].Cells[1].Text;
        //    txtPass.Text = dtb1.Rows[0]["con_telefono"].ToString();
        //    txtTipo.Text = dtb1.Rows[0]["con_direccion"].ToString();

        //    btnGuardar.Text = "Actualizar";
        //    btnEliminar.Enabled = true;
        //}

        protected void grvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {

                int usuID = Convert.ToInt32(e.CommandArgument);
                
                GridViewRow row = grvUsuarios.Rows[usuID];

                hdf.Value = row.Cells[0].Text;
                txtUsu.Text = row.Cells[1].Text;
                txtPass.Text = row.Cells[2].Text;
                txtTipo.Text = row.Cells[3].Text;

                btnGuardar.Text = "Actualizar";
                btnEliminar.Enabled = true;
            }
        }

        protected void btnGuardarPlato_Click(object sender, EventArgs e)
        {
            string plaID = hdf1.Value;

            if (plaID == "")
            {
                objCNP.InsetarPlatos(txtNomPlato.Text, txtPrecPlato.Text, txtTipoPlato.Text);
                lblMensaje1.Text = "Plato Guardado con Exito";

                listarPlatos();
            }
            else
            {
                objCNP.EditarPlatos(txtNomPlato.Text, txtPrecPlato.Text, txtTipoPlato.Text, hdf1.Value);
                lblMensaje1.Text = "Plato Actualizado con Exito";

                listarPlatos();
            }
        }

        protected void btnEliminarPlato_Click(object sender, EventArgs e)
        {
            string plaID = hdf1.Value;

            if (plaID == "")
            {
                lblMensaje1.Text = "Por favor Seleccione un Registro";

                listarPlatos();
            }
            else
            {
                objCNP.EliminarPlatos(hdf1.Value);
                lblMensaje1.Text = "Plato Eliminado con Exito";

                listarPlatos();
            }
        }

        protected void btnLimpiarPlato_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void grvPlatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {

                int usuID = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = grvPlatos.Rows[usuID];

                hdf1.Value = row.Cells[0].Text;
                txtNomPlato.Text = row.Cells[1].Text;
                txtPrecPlato.Text = row.Cells[2].Text;
                txtTipoPlato.Text = row.Cells[3].Text;

                btnGuardarPlato.Text = "Actualizar";
                btnEliminarPlato.Enabled = true;
            }
        }
    }
}