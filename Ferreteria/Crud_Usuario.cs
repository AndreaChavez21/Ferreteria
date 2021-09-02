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
    public partial class Crud_Usuario : Form
    {
        CN_Usuario objetoCN = new CN_Usuario();

        private string pro_id = null;
        private bool editar = false;
        public Crud_Usuario()
        {
            InitializeComponent();
        }



        private void btn_salira_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btn_regresara_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin().ShowDialog();
            this.Close();
        }

        private void Crud_Usuario_Load(object sender, EventArgs e)
        {
            mostrar_Usuario();

        }

        private void mostrar_Usuario()
        {
            CN_Usuario objeto = new CN_Usuario();

            dgv_usuario.DataSource = objeto.trae_usuario();
        }

        private void btn_bregresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin().ShowDialog();
            this.Close();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {

        }

        private void btn_bsalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btn_bguardar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_cedula.Text)||string.IsNullOrEmpty(txt_nick.Text) ||string.IsNullOrEmpty(txt_pass.Text) || string.IsNullOrEmpty(txt_dire.Text) || string.IsNullOrEmpty(txt_correo.Text))
            {
                MessageBox.Show("Ingresar todos los datos");
            }
            else
            {
                if(editar==false)
                {
                    try
                    {
                        objetoCN.insertarU(txt_nombre.Text, txt_cedula.Text, txt_nick.Text, txt_pass.Text, txt_dire.Text, txt_correo.Text);

                        MessageBox.Show("Se ingresaron los datos correctamente");
                        mostrar_Usuario();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("No se guardaron los datos" + ex.Message);
                        throw;
                    }
                }
            }
        }
    }
}
