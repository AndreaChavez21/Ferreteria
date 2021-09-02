using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Datos;
using System.Windows.Forms;

namespace Capa_Negocio
{
    public class CN_Producto
    {
        private CD_Producto objetopCD = new CD_Producto();
        public DataTable trae_producto()
        {
            DataTable tabla = new DataTable();
            tabla = objetopCD.mostrar_producto();
            return tabla;

        }

        public void insertarP(string nombre, string codigo, string cantidad, string precio ,  string fecha, PictureBox imagen)
        {
            objetopCD.Insertar_producto(nombre,codigo, cantidad, precio, Convert.ToDateTime(fecha),imagen);

        }
    }
}
