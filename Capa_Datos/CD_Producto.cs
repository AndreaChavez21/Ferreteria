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
        SqlCommand cmdp = new SqlCommand();

        public DataTable mostrar_producto()
        {
            //proc.almacenados
            cmdp.Connection = cn.abrir_conexion();
            cmdp.CommandText = "MostrarProducto";
            cmdp.CommandType = CommandType.StoredProcedure;
            leer = cmdp.ExecuteReader();
            tabla.Load(leer);
            cn.cerrar_conexion();

            return tabla;

        }

        public DataTable Insertar_producto(string nombre, string codigo, string cantidad, string precio, DateTime fecha, PictureBox image)
        {
            cmdp.Connection = cn.abrir_conexion();
            cmdp.CommandText = "InsertarProducto";
            cmdp.CommandType = CommandType.StoredProcedure;
            cmdp.Parameters.AddWithValue("pro_nombre", nombre);
            cmdp.Parameters.AddWithValue("pro_codigo", codigo);
            cmdp.Parameters.AddWithValue("pro_cantidad", cantidad);
            cmdp.Parameters.AddWithValue("pro_precio", precio);
            cmdp.Parameters.AddWithValue("pro_fecha", fecha);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            cmdp.ExecuteNonQuery();
            cmdp.Parameters.Clear();
            cn.cerrar_conexion();

            return tabla;



        }
    }
    
}
