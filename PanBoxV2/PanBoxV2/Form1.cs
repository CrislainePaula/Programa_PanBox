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

namespace PanBoxV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //conexão com o banco de dados

        SqlConnection cn = new SqlConnection(@"Data Source=CRISPPP\CCMSSQL;integrated security=SSPI;initial Catalog=db_livraria");

        SqlCommand cm = new SqlCommand();

        SqlDataReader dt;
        

        private void BtnSenha_MouseDown(object sender, MouseEventArgs e)
        {
            TxtSenha.UseSystemPasswordChar = false;
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnSenha_MouseUp(object sender, MouseEventArgs e)
        {
            TxtSenha.UseSystemPasswordChar = true;
        }

        private void BtnAcessar_Click(object sender, EventArgs e)
        {
            if (TxtLogin.Text == "" || TxtSenha.Text == "")
            {
                MessageBox.Show("Informe login e senha!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                try
                {
                    cn.Open();
                    cm.CommandText = "select * from tbl_atendente where ds_Login =('" + TxtLogin.Text + "') and ds_Senha =('" + TxtSenha.Text + "') ";
                    cm.Connection = cn;
                    dt = cm.ExecuteReader();

                    if (dt.HasRows)
                    {
                        FrmMenu menu = new FrmMenu();
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha inválidos", "Ocorreu um erro !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TxtLogin.Clear();
                        TxtSenha.Clear();
                        TxtLogin.Focus();
                    }
                }

                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                    cn.Close();
                }
                finally
                {
                    cn.Close();
                }

            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
