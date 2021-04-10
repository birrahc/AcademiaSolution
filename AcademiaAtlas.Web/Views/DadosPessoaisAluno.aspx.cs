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
    public partial class DadosPessoaisAluno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var nome = SvcAluno.BuscarAluno();
            grvAluno.DataSource = nome;
            grvAluno.DataBind();
            grvAluno.ShowHeader = false;

        }

        protected void grvAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarDadosDetalhados();
        }

        private void carregarDadosDetalhados()
        {
            Aluno aluno = new Aluno();
            aluno.IdPessoa = Convert.ToInt32(grvAluno.SelectedDataKey.Values[0]);
            List<Aluno> detalhes = SvcAluno.BuscarPorNomeEId(aluno);
            foreach (var item in detalhes)
            {
                lblNome.Text = item.Nome;
                lblNascimento.Text = item.Nascimento.ToShortDateString();
                lblCpf.Text = item.Cpf;
                lblWhatsApp.Text = item.WhatsApp;
                lblEmail.Text = item.Email;
                lblTelefone.Text = item.Telefone;
            }
        }
    }
}