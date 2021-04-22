using AcademiaAtlas.Mdl;
using AcademiaSolution.Svc;
using AcademiaSolution.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcademiaAtlas.Web.Views
{
    public partial class CadastrarAluno : System.Web.UI.Page
    {
        private static int codigo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                codigo = Convert.ToInt32(Request.QueryString["Aluno"]);
                if (codigo >= 1)
                {
                    PreenherCampos();
                    lblTituloCadUpd.Text = "Editar Dados";
                    btnCadastrar.Text = "Editar";
                }
            }
        }

        protected void btnCadastrar_OnClick(object sender, EventArgs e) 
        {

            if (!Masculino.Checked && !Feminino.Checked)
            {
                lblSexo.CssClass = "labelAlerta";
                lblSexo.Text = "Selecione o sexo";
            }
            else if (txbNascimento == null || txbNascimento.Text == "")
            {
                pnlNascimento.CssClass = "labelAlerta";
                pnlNascimento.Text = "Preencha a data";
            }
            else 
            {
                Aluno aluno = new Aluno();
                aluno.IdPessoa = codigo;
                aluno.Nome = txbNome.Text;
                aluno.Genero = (ESexo)VerificaSexo();
                aluno.Nascimento = Convert.ToDateTime(txbNascimento.Text);
                aluno.Cpf = txbCpf.Text;
                aluno.WhatsApp = txbWhatsApp.Text;
                aluno.Telefone = txbTelefone.Text;
                aluno.Email = txbEmail.Text;
                if (aluno.IdPessoa <= 0)
                {
                    SvcAluno.InserirDadosAluno(aluno);
                    Response.Redirect($"DadosPessoaisAluno.aspx?Aluno={aluno.UltimoRegistroSql}");
                }
                else
                {
                    SvcAluno.AtualizarDadosAluno(aluno);
                    Response.Redirect($"DadosPessoaisAluno.aspx?Aluno={codigo}");
                }
                LimparCampos();
                
            }
        }

        private void PreenherCampos() 
        {
            Aluno aluno = new Aluno();
            aluno.IdPessoa = codigo;
            var dados = SvcAluno.BuscarPorNomeEId(aluno);
           
            foreach (var item in dados)
            {
                txbNome.Text = item.Nome;
                txbNascimento.Text = item.Nascimento.ToString("yyyy-MM-dd");
                if (item.SiglaSexo=="M") 
                {
                    Masculino.Checked = true;
                }
                if (item.SiglaSexo == "F")
                {
                    Feminino.Checked = true;
                }
                txbCpf.Text = item.Cpf;
                txbWhatsApp.Text = item.WhatsApp;
                txbTelefone.Text = item.Telefone;
                txbEmail.Text = item.Email;
            }

        }

        private static void TratarData(string data) 
        {
            var dados = data.Replace("/","-");
            var dataCerta = dados.Reverse();
            //return dataCerta.ToString();
        }
        private int VerificaSexo() 
        {
             var resultado = 0;

            if (Masculino.Checked) 
            {
                resultado = (int)AcademiaSolution.Enums.ESexo.M;
            }
            if (Feminino.Checked) 
            {
                resultado = (int)AcademiaSolution.Enums.ESexo.F;
            }
            return resultado;
        }
        protected void btnLimpar_OnClick(object sender, EventArgs e) 
        {
            LimparCampos();
        }

        protected void btnCancelar_OnClick(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos() 
        {
            txbNome.Text = null;
            txbNascimento.Text = null;
            txbCpf.Text = null;
            txbWhatsApp.Text = null;
            txbTelefone.Text = null;
            txbEmail.Text = null;
        }
    }
}