﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria
{
    public partial class Crud_Producto : Form
    {
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
    }
}
