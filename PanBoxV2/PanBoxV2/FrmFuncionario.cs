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
    public partial class FrmFuncionario : UserControl
    {
        public FrmFuncionario()
        {
            InitializeComponent();
        }

        private void FrmFuncionario_Load(object sender, EventArgs e)
        {
            DesabilitaCampos();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=CRISPPP\CCMSSQL;integrated security=SSPI;initial Catalog=db_livraria");

        SqlCommand cm = new SqlCommand();

        SqlDataReader dt;

        private void DesabilitaCampos()
        {
            LblCodigo.Visible = true;
            LblCod.Visible = false;
            TxtNome.Enabled = false;
            TxtLogin.Enabled = false;
            TxtSenha.Enabled = false;
            BtnSalvar.Enabled = false;
            BtnAlterar.Enabled = false;
            BtnExcluir.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnNovo.Enabled = true;
        }

        private void HabilitaCampos()
        {
           
            TxtNome.Enabled = true;
            TxtLogin.Enabled = true;
            TxtSenha.Enabled = true;
            BtnSalvar.Enabled = true;
            BtnAlterar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnCancelar.Enabled = true;
            TxtNome.Focus();
            BtnNovo.Enabled = false;
            DgvFunc.DataSource = null;
        }

        private void LimparCampos()
        {
            TxtNome.Text = "";
            TxtLogin.Clear();
            TxtSenha.Clear();
            TxtNome.Focus();
            TxtBusca.Clear();
            DgvFunc.DataSource = null;
            RdbAtivo.Checked = true;
            LblCodigo.Visible = false;
            LblCodigo.Visible = false;

        }

        private void ManipularDados()
        {
            LblCodigo.Visible = true;
            LblCod.Visible = true;
            BtnAlterar.Enabled = true;
            BtnCancelar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnNovo.Enabled = false;
            BtnSalvar.Enabled = false;
            TxtNome.Enabled = true;
            TxtLogin.Enabled = true;
            TxtSenha.Enabled = true;
        }


        private void BtnNovo_Click(object sender, EventArgs e)
        {
            HabilitaCampos();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DesabilitaCampos();
            LimparCampos();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if(TxtNome.Text == "")
            {
                MessageBox.Show("Obrigatorio informar o campo nome.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNome.Focus();
            }
            else if(TxtLogin.Text == "")
            {
                MessageBox.Show("Obrigatorio informar o campo Login.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtLogin.Focus();
            }
            else if(TxtSenha.Text == "")
            {
                MessageBox.Show("Obrigatorio informar o campo Senha.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtSenha.Focus();
            }
            else if (TxtSenha.Text.Length < 8)//tamanho do campo for maior que 8
            {
                MessageBox.Show("O campo Senha deve conter no minimo oito digitos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtSenha.Focus();
            }
            else if (RdbInativo.Checked)//tamanho do campo for maior que 8
            {
                MessageBox.Show("Inpossivel cadastrar funcionário com status INATIVO!!", "Erro ao tentar cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string nome = TxtNome.Text;
                    string login = TxtLogin.Text;
                    string senha = TxtSenha.Text;

                    string strql = "insert into tbl_atendente(ds_login,ds_senha,nm_atendente,ds_status)values(@login,@senha,@atendente,1)";

                    cm.CommandText = strql;
                    cm.Connection = cn;
                    

                    cm.Parameters.Add("login", SqlDbType.VarChar).Value = login;
                    cm.Parameters.Add("@senha", SqlDbType.Char).Value = senha;
                    cm.Parameters.Add("@atendente", SqlDbType.VarChar).Value = nome;

                    cn.Open();
                    cm.ExecuteNonQuery();
                    cm.Parameters.Clear();
                    MessageBox.Show("Os dados foram cadastrados com sucesso", "Inserção de dados Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtNome.Focus();
                    LimparCampos();

                }
                catch(Exception erro)
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

        private void TxtBusca_TextChanged(object sender, EventArgs e)
        {
            if(TxtBusca.Text != "")
            {
                try
                {
                    cn.Open();
                    cm.CommandText = "select * from tbl_atendente where nm_atendente like ('" + TxtBusca.Text + "%')";
                    cm.Connection = cn;

                    SqlDataAdapter da = new SqlDataAdapter();//recebe os dados de uma tabela apos a execução de um select
                    DataTable dt = new DataTable();

                    //recebendo os dados da instruç~so select
                    da.SelectCommand = cm;
                    da.Fill(dt); // preenchendo o datatable
                    DgvFunc.DataSource = dt;
                    cn.Close();
                }
                catch(Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
                
            }
            else
            {
                DgvFunc.DataSource = null;
            }
        }

        private void CarregaAtendente()
        {
            LblCodigo.Text = DgvFunc.SelectedRows[0].Cells[0].Value.ToString();
            TxtLogin.Text = DgvFunc.SelectedRows[0].Cells[1].Value.ToString();
            TxtSenha.Text = DgvFunc.SelectedRows[0].Cells[2].Value.ToString();
            TxtNome.Text = DgvFunc.SelectedRows[0].Cells[3].Value.ToString();
            string valor = DgvFunc.SelectedRows[0].Cells[4].Value.ToString();

            if(valor == "True")
            {
                RdbAtivo.Checked = true;
            }
            else
            {
                RdbInativo.Checked = true;
            }

            ManipularDados();
        }

        private void DgvFunc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CarregaAtendente();
            if (RdbAtivo.Checked)
            {
                BtnExcluir.Enabled = true;
            }
            else
            {
                BtnExcluir.Enabled = false;
            }
        }






        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            if (TxtNome.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo nome.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNome.Focus();
            }
            else if (TxtLogin.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo Login.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtLogin.Focus();
            }
            else if (TxtSenha.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo Senha.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtSenha.Focus();
            }
            else if (TxtSenha.Text.Length < 8)//tamanho do campo for maior que 8
            {
                MessageBox.Show("O campo Senha deve conter no minimo oito digitos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtSenha.Focus();
            }

            else if (RdbInativo.Checked)//tamanho do campo for maior que 8
            {
                MessageBox.Show("Para tornar inativo o funcionario é preciso clicar no botão REMOVER", "Erro na operação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string nome = TxtNome.Text;
                    string login = TxtLogin.Text;
                    string senha = TxtSenha.Text;
                    int cd = Convert.ToInt32( LblCodigo.Text );

                    string strql = "update tbl_atendente set ds_login=@login,ds_senha=@senha,nm_atendente=@atendente, ds_status=1  where cd_atendente=@cd";

                    cm.CommandText = strql;
                    cm.Connection = cn;


                    cm.Parameters.Add("login", SqlDbType.VarChar).Value = login;
                    cm.Parameters.Add("@senha", SqlDbType.Char).Value = senha;
                    cm.Parameters.Add("@atendente", SqlDbType.VarChar).Value = nome;
                    cm.Parameters.Add("@cd", SqlDbType.Int).Value = cd;

                    cn.Open();
                    cm.ExecuteNonQuery();
                    cm.Parameters.Clear();
                    MessageBox.Show("Os dados foram alterados com sucesso", "Alteração Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtNome.Focus();
                    LimparCampos();

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

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (TxtNome.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo nome.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNome.Focus();
            }
            else if (TxtLogin.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo Login.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtLogin.Focus();
            }
            else if (TxtSenha.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo Senha.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtSenha.Focus();
            }
            else if (TxtSenha.Text.Length < 8)//tamanho do campo for maior que 8
            {
                MessageBox.Show("O campo Senha deve conter no minimo oito digitos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtSenha.Focus();
            }
            else if (RdbAtivo.Checked)
            {

                MessageBox.Show("Para remover o registro altere o status para INATIVO.", "Erro ao tentar excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtSenha.Focus();
            }
            else
            {
                DialogResult exclusao = MessageBox.Show("Tem certeza que deseja remover este registro?", "Exclusão de registro",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if (exclusao == DialogResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        int cd = Convert.ToInt32(LblCodigo.Text);
                        cn.Open();
                        string strql = "update tbl_atendente set ds_status = 0 where cd_Atendente=@cd";
                        cm.CommandText = strql;
                        cm.Connection = cn;
                        cm.Parameters.Add("@cd", SqlDbType.Int).Value = cd;

                        cm.ExecuteNonQuery();
                        cm.Parameters.Clear();
                        MessageBox.Show("Exclusão feita com sucesso!", "Exclusão Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtNome.Focus();
                        LimparCampos();
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

        }
    }
}
