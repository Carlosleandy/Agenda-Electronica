using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapasEntidad; // agregado 
using System.Configuration;  // agregado 
using System.Data.SqlClient; // agregado 
using System.Data;  // agregado 

namespace CapaDatos
{
    public class D_Contacto
    {
        SqlConnection cn =  new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);

        public DataTable D_listado()
        {
            SqlCommand cmd = new SqlCommand("SP_Listar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_Buscar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void D_guardar(E_Contacto contacto)
        {
            SqlCommand cmd = new SqlCommand("SP_Guardar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
            cmd.Parameters.AddWithValue("@Fecha", contacto.Fecha);
            cmd.Parameters.AddWithValue("@Hora", contacto.Hora);
            cmd.Parameters.AddWithValue("@Detalles", contacto.Detalles);
            cmd.Parameters.AddWithValue("@Ubicacion", contacto.Ubicacion);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void D_editar(E_Contacto contacto)
        {
            SqlCommand cmd = new SqlCommand("SP_Editar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", contacto.ID);
            cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
            cmd.Parameters.AddWithValue("@Fecha", contacto.Fecha);
            cmd.Parameters.AddWithValue("@Hora", contacto.Hora);
            cmd.Parameters.AddWithValue("@Detalles", contacto.Detalles);
            cmd.Parameters.AddWithValue("@Ubicacion", contacto.Ubicacion);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void D_eliminar(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_Eliminar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
