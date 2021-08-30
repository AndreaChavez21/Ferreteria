using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
    class CD_Conexion
    {
        //Cadena de conexión
        private SqlConnection Conexion = new SqlConnection("Data Source=localhost;Initial Catalog=LogFerr;Integrated Security=True");
        //métodos para abrir y cerrar  conexion

        public SqlConnection abrir_conexion()
        {
            if(Conexion.State==ConnectionState.Closed)
            {
                Conexion.Open();
            }
            return Conexion;
        }
        public SqlConnection cerrar_conexion()
        {
            if(Conexion.State==ConnectionState.Open)
            {
                Conexion.Close();
            }
            return Conexion;
        }
    }
}
