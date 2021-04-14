using AcademiaSolution.Svc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcademiaAtlas.Web.Views
{
    public partial class Relatorios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlTotalLiquido.Visible = false;
        }

        protected void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            Relatorio();
        }

        private void Relatorio() 
        {
            if (String.IsNullOrWhiteSpace(txtDaInicio.Text) || 
                String.IsNullOrEmpty(txtDataFim.Text) || 
                String.IsNullOrEmpty(txtDaInicio.Text) &&
                String.IsNullOrEmpty(txtDataFim.Text)) 
            {
                txtDaInicio.Text = DateTime.Now.ToString(); 
                txtDataFim.Text = DateTime.Now.ToString();
            }
            DateTime dataInicial = Convert.ToDateTime(txtDaInicio.Text);
            DateTime dataFinal = Convert.ToDateTime(txtDataFim.Text);
            var relatorioPeriodo = SvcPagamento.RelatorioPorPeriodo(dataInicial, dataFinal);
            grvRelatorio.DataSource = relatorioPeriodo.ToList();
            grvRelatorio.DataBind();
            var totalDescontos = relatorioPeriodo.Sum(d => d.Desconto);
            var total = relatorioPeriodo.Sum(d => d.Valor);
            var totalLiq = total - totalDescontos;
            txtDesconto.Text = totalDescontos.ToString();
            txtTotal.Text = total.ToString();
            txtTotalLiq.Text = totalLiq.ToString();
            pnlTotalLiquido.Visible = true;
        }
    }
}