using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ferreteria
{
    public partial class Registrar : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Ferreteria;Integrated Security=True");
        public Registrar()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void cargartu()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select tusu_id, tusu_nombre from Tbl_Usuario where tusu_estado= 'A'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dt.Columns.Add("tusu_id", typeof(int));
            dt.Columns.Add("tusu_nombre", typeof(string));
           
            sda.Fill(dt);
            con.Close();
            



        }
        private void registro()
        {
            try
            {
                con.Open();
                string query = "insert into Tbl_Usuario values(@usu_nombre, @usu_cedula,@usu_nickname,@usu_password, 'A')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@usu_nombre", txt_nombreu.Text.Trim());
                cmd.Parameters.AddWithValue("@usu_cedula", txt_cedulau.Text.Trim());
                cmd.Parameters.AddWithValue("@usu_nickname", txt_nicku.Text.Trim());
                cmd.Parameters.AddWithValue("@usu_password", txt_passu.Text.Trim());
       
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuario registrado con éxito");
                Limpiar();
            }
            catch (Exception)
            {
                MessageBox.Show("Error, no se pudo registrar el usuario");
                throw;
            }
        }
        private void Limpiar()
        {
            txt_nombreu.Text = txt_cedulau.Text = txt_nicku.Text = txt_passu.Text = "";
            
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_nombreu.Text) || string.IsNullOrEmpty(txt_passu.Text) || string.IsNullOrEmpty(txt_cedulau.Text) || string.IsNullOrEmpty(txt_nicku.Text) || string.IsNullOrEmpty(txt_passu.Text))
            {
                MessageBox.Show("Ingresar todos los datos");
                Limpiar();

            }
            else
            {
                registro();
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }
        
        private void Registrar_Load(object sender, EventArgs e)
        {
            /*cargartu();*/
        }

        private void btn_bguardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_nombreu.Text) || string.IsNullOrEmpty(txt_passu.Text) || string.IsNullOrEmpty(txt_cedulau.Text) || string.IsNullOrEmpty(txt_nicku.Text) || string.IsNullOrEmpty(txt_passu.Text))
            {
                MessageBox.Show("Ingresar todos los datos");
                Limpiar();

            }
            else
            {
                registro();
            }
        }

        private void btn_bcancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }
    }
}
