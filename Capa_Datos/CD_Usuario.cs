using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
    public class CD_Usuario
    {

        private CD_Conexion cn = new CD_Conexion();
        //propiedades de sql
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand cmd = new SqlCommand();
        //mostrar datos
       public DataTable mostrar_usuario()
        {
            //proc.almacenados
            cmd.Connection = cn.abrir_conexion();
            cmd.CommandText = "MostrarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            cn.cerrar_conexion();

            return tabla;

        }
        /*public DataTable insertar(string nombre, string cedula, string nick, string passw, string dire, string correo)
        {
            cmd.Connection = cn.abrir_conexion();
            cmd.CommandText = "InsertarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("",);
            cmd.Parameters.AddWithValue("",);
            cmd.Parameters.AddWithValue("",);
            cmd.Parameters.AddWithValue("",);
            cmd.Parameters.AddWithValue("",);
            cmd.Parameters.AddWithValue("",);
            cmd.Parameters.AddWithValue("",);

        }*/
    }
}
