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
            dgv_usuario.DataSource = objetoCN.trae_usuario();
        }
    }
}
