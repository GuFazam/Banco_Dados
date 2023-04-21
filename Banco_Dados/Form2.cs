using MySql.Data.MySqlClient;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=universidade;password=;");
            MySqlCommand cmd = new MySqlCommand("INSERT INTO alunos (nome, uf) VALUES (@Nome, @Uf)", conn);

            cmd.Parameters.AddWithValue("@Nome", textBoxNome.Text);
            cmd.Parameters.AddWithValue("@Uf", textBoxUf.Text);

            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0 )
            {
                MessageBox.Show("Dados inseridos com sucesso!");
            }
            else
            {
                MessageBox.Show("Falha ao inserir dados.");
            }
        }
    }
}
