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
using Capa_Negocio;

namespace Ferreteria
{
    public partial class Login : Form
    {
        //CN_Usuario objetoCN = new CN_Usuario();
        int contador = 0;
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Ferreteria;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            
        }

        private void Limpiar1()
        {
            txt_nombre.Text = txt_pass.Text = "";

        }
        private void logear(string nombre, string pass)
        {
            contador += 1;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Tbl_Usuario where usu_nomlogin = @nom and usu_estado = 'A'", con);
                cmd.Parameters.AddWithValue("nom", nombre);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 1)
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("select usu_nombre, tusu_id from Tbl_Usuario where usu_nomlogin = @nom and usu_password = @pass and usu_estado = 'A'", con);
                    cmd1.Parameters.AddWithValue("nom", nombre);
                    cmd1.Parameters.AddWithValue("pass", pass);
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    con.Close();

                    if (dt1.Rows.Count == 1)
                    {
                        this.Hide();
                        if (dt1.Rows[0][1].ToString() == "1")
                        {

                            new Admin().ShowDialog();

                        }
                        else if (dt1.Rows[0][1].ToString() == "2")
                        {
                            new Usuario().ShowDialog();
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Datos Incorrectos");
                        if (contador > 2)
                        {
                            con.Open();
                            SqlCommand cmd2 = new SqlCommand("select * from Tbl_Usuario where usu_nomlogin = @nom and usu_estado = 'A'", con);
                            cmd2.Parameters.AddWithValue("nom", nombre);
                            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                            DataTable dt2 = new DataTable();
                            sda2.Fill(dt2);
                            con.Close();
                            if (dt2.Rows.Count == 1)
                            {
                                con.Open();
                                SqlCommand cmd3 = new SqlCommand("UPDATE Tbl_Usuario SET usu_estado = 'B' WHERE usu_nomlogin = @nom", con);
                                cmd3.Parameters.AddWithValue("nom", nombre);
                                SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);
                                DataTable dt3 = new DataTable();
                                sda3.Fill(dt3);
                                con.Close();

                            }
                            MessageBox.Show("Usted ha excedido el número de intentos");
                            MessageBox.Show("USUARIO BLOQUEADO.");
                            Application.Exit();
                        }


                        Limpiar1();

                    }

                }
                else
                {
                    MessageBox.Show("Usuario no encontrado");
                    contador += 1;
                }
                if (contador > 2)
                {
                    MessageBox.Show("Se excedieron el número de intentos");
                    Application.Exit();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void lnk_registrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Registrar().ShowDialog();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bnt_bingresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_pass.Text))
            {
                MessageBox.Show("Por favor ingrese todos los datos");

            }
            else
            {
                logear(txt_nombre.Text, txt_pass.Text);
            }
        }
    }
    }

