using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_Producto
    {

        private CD_Conexion cn = new CD_Conexion();
        //propiedades de sql
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public DataTable mostrar_producto()
        {
            //proc.almacenados
            cmd.Connection = cn.abrir_conexion();
            cmd.CommandText = "MostrarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            cn.cerrar_conexion();

            return tabla;

        }

        public DataTable Insertar_producto(string nombre, string codigo, string cantidad, string precio, DateTime fecha, PictureBox image)
        {
            cmd.Connection = cn.abrir_conexion();
            cmd.CommandText = "InsertarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pro_nombre", nombre);
            cmd.Parameters.AddWithValue("pro_codigo", codigo);
            cmd.Parameters.AddWithValue("pro_cantidad", cantidad);
            cmd.Parameters.AddWithValue("pro_precio", precio);
            cmd.Parameters.AddWithValue("pro_fecha", fecha);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            return tabla;



        }
    }
    
}
