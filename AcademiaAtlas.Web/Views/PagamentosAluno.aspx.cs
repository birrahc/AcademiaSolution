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
    public partial class PagamentosAluno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pagamento pgt = new Pagamento();
            pgt.IdPessoa = 6;
            
            var pagamentos = SvcPagamento.BuscarPagamentoPorId(pgt);
            foreach (var item in pagamentos) 
            {
                pgt.Nome = item.Nome;
            }

            txtNome.Text = pgt.Nome;
            grvPagamentoAluno.DataSource = pagamentos;
            grvPagamentoAluno.DataBind();

        }
      
    }
}