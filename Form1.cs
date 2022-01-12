using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class crud : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = localhost; Initial Catalog = CRUD; Integrated Security = SSPI;");
        
        public crud()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            SqlDataReader dr = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = ("select * from Cliente");
                if (txtId.Text != "")
                {
                    cmd.CommandText += (" where id_cli = @id");
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt16(txtId.Text));
                }
                dr = cmd.ExecuteReader();
                bool isEmpty = true;

                lstResultado.Items.Clear();
                while (dr.Read())
                {
                    isEmpty = false;
                    string[] arr = new string[6];
                    for(int i = 0; i < 6; i++)
                    {
                        arr[i] = Convert.ToString(dr[i]);
                    }

                    ListViewItem item = new ListViewItem(arr);
                    lstResultado.Items.Add(item);
                }
                if (isEmpty)
                {
                    MessageBox.Show("Nenhum resultado encontrado!");
                }
            }
            catch
            {
                MessageBox.Show("Erro na consulta!");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = ("insert into Cliente values (@nome, @endereco, @cidade, @cep, @uf)");
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@cidade", txtCidade.Text);
                cmd.Parameters.AddWithValue("@cep", txtCep.Text);
                cmd.Parameters.AddWithValue("@uf", txtUf.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente inserido com sucesso!");
            }
            catch
            {
                MessageBox.Show("Erro na inserção!");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = ("delete from Cliente where id_cli = @id");
                cmd.Parameters.AddWithValue("@id", Convert.ToInt16(txtId.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente removido com sucesso!");
            }
            catch
            {
                MessageBox.Show("Erro na remoção!");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = ("update Cliente set nome_cli = @nome, endereco_cli = @endereco, cidade_cli = @cidade," +
                    "cep_cli = @cep, uf_cli = @uf where id_cli = @id");
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@cidade", txtCidade.Text);
                cmd.Parameters.AddWithValue("@cep", txtCep.Text);
                cmd.Parameters.AddWithValue("@uf", txtUf.Text);
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente atualizado com sucesso!");
            }
            catch
            {
                MessageBox.Show("Erro ao atualizar cliente!");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void btnTrazerCliente_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Insira o ID do cliente!");
            }
            else
            {
                SqlDataReader dr = null;
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = ("select * from Cliente where id_cli = @id");
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt16(txtId.Text));
                    dr = cmd.ExecuteReader();
                    dr.Read();

                    txtNome.Text = Convert.ToString(dr[1]);
                    txtEndereco.Text = Convert.ToString(dr[2]);
                    txtCidade.Text = Convert.ToString(dr[3]);
                    txtCep.Text = Convert.ToString(dr[4]);
                    txtUf.Text = Convert.ToString(dr[5]);
                }
                catch
                {
                    MessageBox.Show("Erro ao trazer os dados do cliente!");
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCidade.Text = "";
            txtCep.Text = "";
            txtUf.Text = "";
        }
    }
}
