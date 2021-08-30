using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Datos;

namespace Capa_Negocio
{
    public class CN_Usuario
    {
        private CD_Usuario objetoCD = new CD_Usuario();
        public DataTable trae_usuario()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.mostrar_usuario();
            return tabla;

        }
    }
}
