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
        private static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                id= Convert.ToInt32(Request.QueryString["Aluno"]);
                pnlDadosPessoais.Visible = false;
                if (id >0) 
                {
                    carregarDadosDetalhados();
                }
                
                CarregarListaDeAlunos();
            }
            
        }

        protected void grvAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarDadosDetalhados();
        }

        private void carregarDadosDetalhados()
        {
            CarregarListaDeAlunos();
            Aluno aluno = new Aluno();
            if (grvAluno.SelectedDataKey != null && Convert.ToInt32(grvAluno.SelectedDataKey.Values[0]) > 0)
            {
                aluno.IdPessoa = Convert.ToInt32(grvAluno.SelectedDataKey.Values[0]);
            }
            else 
            {
                aluno.IdPessoa = id;
            }
            List<Aluno> detalhes = SvcAluno.BuscarPorNomeEId(aluno);
            foreach (var item in detalhes)
            {
                lblNome.Text = item.Nome;
                lblNascimento.Text = item.Nascimento.ToShortDateString();
                lblIdade.Text = $"{item.Idade.ToString()} Anos";
                lblSexo.Text = item.Descricao;
                lblCpf.Text = item.Cpf;
                lblWhatsApp.Text = item.WhatsApp;
                lblEmail.Text = item.Email;
                lblTelefone.Text = item.Telefone;
                id = item.IdPessoa;
            }
            pnlDadosPessoais.Visible=true;
            LimparSearch();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            CarregarListaDeAlunos();
        }
        protected void CarregarListaDeAlunos() 
        {
            Aluno aluno = new Aluno();
            aluno.Nome = txtSearch.Text;
            var nome = SvcAluno.BuscarAluno(aluno);
            grvAluno.DataSource = nome;
            grvAluno.DataBind();
            grvAluno.ShowHeader = false;
        }
        protected void lnkEditarAluno_Onclick(object sender, EventArgs e)
        {
            Response.Redirect($"cadastrarAluno?Aluno={id}");
        }
        protected void lnkPagmentos_Onclick(object sender, EventArgs e) 
        {
            Response.Redirect($"PagamentosAluno?Aluno={id}");
        }
        protected void lnkTreinos_Onclick(object sender, EventArgs e) 
        {
            
        }
        protected void LimparSearch() 
        {
            txtSearch.Text = null;
        }

    }
}