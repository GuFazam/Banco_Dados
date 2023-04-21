﻿using MySql.Data.MySqlClient; //lembrar dessa biblioteca
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_Dados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=universidade;password=;");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM alunos", conn);

            DataTable dt = new DataTable();
            conn.Open();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();

            dataGridView1.DataSource = dt;
        }

        private void textBoxPesquisar_TextChanged(object sender, EventArgs e)
        {
            string pesquisa = textBoxPesquisar.Text;
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=universidade;password=;");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM alunos where nome like '%"+pesquisa+"%'", conn);

            DataTable dt = new DataTable();
            conn.Open();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();

            dataGridView1.DataSource = dt;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Form fcadastro = new Form2();
            fcadastro.Show();
        }
    }
}
