using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;

namespace Ferreteria
{
    public partial class Crud_Producto : Form
        
    {
        CN_Producto objetoCN = new CN_Producto();
        private string prod_id = null;
        private bool editar = false;
        public Crud_Producto()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin().ShowDialog();
            this.Close();
        }

        private void btn_bregresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin().ShowDialog();
            this.Close();
        }

        private void btn_bsalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void btn_bguardar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_nombrep.Text)&& string.IsNullOrEmpty(txt_codp.Text) && string.IsNullOrEmpty(txt_cantidad.Text) && string.IsNullOrEmpty(txt_precio.Text))
            {
                MessageBox.Show("Llenar todos los campos");
            }
            else
            {
                if ( editar== false)
                {
                    try
                    {
                        //objetoCN.insertarP(txt_nombrep.Text, txt_codp.Text, txt_cantidad.Text, txt_precio.Text,)
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Crud_Producto_Load(object sender, EventArgs e)
        {
            mostrar_producto();
        }

        private void mostrar_producto()

        {
            CN_Usuario objetop = new CN_Usuario();
            dgv_producto.DataSource = objetop.trae_producto();
        }
    }
}
