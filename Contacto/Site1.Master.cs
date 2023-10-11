using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contacto
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO Table_1(nombre,apellido,domicilio,cp,localidad,provincia,prefijo,celular,email,horario,motivo,mensaje) values (@nombre,@apellido,@domicilio,@cp,@localidad,@provincia,@prefijo,@celular,@email,@horario,@motivo,@mensaje)", con);
                cmd.Parameters.AddWithValue("@nombre", MainContent_txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@apellido", MainContent_txtApellido.Text.Trim());
                cmd.Parameters.AddWithValue("@domicilio", MainContent_txtDomicilio.Text.Trim());
                cmd.Parameters.AddWithValue("@cp", MainContent_txtCP.Text.Trim());
                cmd.Parameters.AddWithValue("@localidad", MainContent_ddlLocalidad.Text.Trim());
                cmd.Parameters.AddWithValue("@provincia", MainContent_txtProvincia.Text.Trim());
                cmd.Parameters.AddWithValue("@prefijo", MainContent_txtPrefijo.Text.Trim());
                cmd.Parameters.AddWithValue("@celular", MainContent_txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@email", MainContent_txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@horario", MainContent_ddlHorario.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@motivo", MainContent_ddlMotivo.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@mensaje", txtConsulta.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Consulta Enviada! Nos mantendremos en contacto, muchas gracias :)'); location.href='https://megatone.net/'</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://megatone.net/");
        }

        

    }
}