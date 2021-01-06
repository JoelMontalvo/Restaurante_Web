using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CapaNegocio;

namespace Restaurante_Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        CN_Orden objCDO = new CN_Orden();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            listarOrdenes();
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = false;
            }
        }

        private void listarOrdenes()
        {
            var res = objCDO.MostrarOrden();

            grvOrden.DataSource = res;
            grvOrden.DataBind();
        }

        protected void btnPlato1_Click(object sender, EventArgs e)
        {
            var val = Convert.ToInt32(txtCantidad1.Text) * 10.49;
            objCDO.InsetarOrden("1", "Warm Spinach Dip & Chips", "10.49", "BREAKFAST", txtCantidad1.Text, val.ToString());
                lblMensaje.Text = "Orden Agregada con Exito";
            hdfPlato1.Value = val.ToString();

            listarOrdenes();
        }

        protected void btnPlato2_Click(object sender, EventArgs e)
        {
            var val = Convert.ToInt32(txtCantidad2.Text) * 11.99;
            objCDO.InsetarOrden("1", "Key Wast Machos", "11.99", "BREAKFAST", txtCantidad2.Text, val.ToString());
            lblMensaje.Text = "Orden Agregada con Exito";
            hdfPlato2.Value = val.ToString();

            listarOrdenes();
        }

        protected void grvOrden_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int usuID = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = grvOrden.Rows[usuID];

                hdf.Value = row.Cells[0].Text;
                txtNombrePlato.Text = row.Cells[2].Text;
                txtPrecioPlato.Text = row.Cells[3].Text;
                txtCantidadNueva.Text = row.Cells[5].Text;
               
                btnEliminar.Enabled = true;
                btnGuardar.Enabled = true;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var val = Convert.ToInt32(txtCantidadNueva.Text) * Convert.ToDouble(txtPrecioPlato.Text);
            objCDO.EditarOrden(txtCantidadNueva.Text, val.ToString(), hdf.Value);
            lblMensaje.Text = "Orden Actualizado con Exito";
            HiddenField1.Value = val.ToString();

            listarOrdenes();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        protected void btnFacturar_Click(object sender, EventArgs e)
        {
            string usuID = HiddenField1.Value;
            if (usuID == "")
            {
                double subtotal = 0, iva, tot;

                subtotal = Convert.ToDouble(hdfPlato1.Value) + Convert.ToDouble(hdfPlato2.Value);

                txtSubtotal.Text = subtotal.ToString();
                iva = (subtotal * 12) / 100;
                txtIVA.Text = iva.ToString();
                tot = subtotal + iva;
                txtTotal.Text = tot.ToString();
            }
            else
            {
                double subtotal = 0, iva, tot;
                hdfPlato1.Value = 20.98.ToString();

                subtotal = Convert.ToDouble(hdfPlato1.Value) + Convert.ToDouble(HiddenField1.Value);

                txtSubtotal.Text = subtotal.ToString();
                iva = (subtotal * 12) / 100;
                txtIVA.Text = iva.ToString();
                tot = subtotal + iva;
                txtTotal.Text = tot.ToString();
            }
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}