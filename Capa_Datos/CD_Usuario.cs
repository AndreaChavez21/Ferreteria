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
        //mostrar datos 1
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
        /*public DataTable insertar(string nombre, string cedula, string nick, string pass, string dire, string correo)
        {
            cmd.Connection = cn.abrir_conexion();
            cmd.CommandText = "InsertarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("usu_nombre",nombre);
            cmd.Parameters.AddWithValue("usu_cedula",cedula);
            cmd.Parameters.AddWithValue("usu_nickname",nick);
            cmd.Parameters.AddWithValue("usu_password",pass);
            cmd.Parameters.AddWithValue("usu_direccion",dire);
            cmd.Parameters.AddWithValue("usu_correo",correo);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cn.cerrar_conexion();
            

        }
        */
    }
}
