using AcademiaAtlas.Mdl;
using AcademiaSolution.Svc;
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_OnClick(object sender, EventArgs e) 
        {
            Aluno aluno = new Aluno();
            aluno.Nome = txbNome.Text;
            aluno.Nascimento = Convert.ToDateTime(txbNascimento.Text);
            aluno.Cpf = txbCpf.Text;
            aluno.WhatsApp = txbWhatsApp.Text ;
            aluno.Telefone = txbTelefone.Text ;
            aluno.Email = txbEmail.Text;
            SvcAluno.InserirDadosAluno(aluno);
            LimparCampos();
            Response.Redirect("DadosPessoaisAluno.aspx");
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