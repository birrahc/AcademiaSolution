using AcademiaAtlas.Mdl;
using AcademiaSolution.Svc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaSolution.Tst
{
    [TestClass]
    public class TestPagamento
    {
        [TestMethod]
        public void TestCadastrarPagamento() 
        {
            Pagamento pgt = new Pagamento();
            pgt.IdPessoa = 8;
            pgt.DataPagt =  DateTime.Now;
            pgt.DataInicio = DateTime.Parse("2021-02-09");
            pgt.DataFinal = DateTime.Parse("2021-03-09");
            pgt.Valor = 150;
            pgt.Desconto = 10;
            pgt.Observacao = "Pagamento referente ao mes de fevereiro";
            SvcPagamento.CadastrarPagamento(pgt);
        }
        [TestMethod]
        public void TestBuscarPagamento()
        {
            Aluno aluno= new Aluno();
            aluno.Nome = "Junior";
            var pgt = SvcPagamento.BuscarPagamento();
        }

        [TestMethod]
        public void TestBuscarPagamentoporId()
        {
            Pagamento aluno = new Pagamento();
            aluno.IdPessoa = 6;
            var pgt = SvcPagamento.BuscarPagamentoPorId(aluno);
        }

        [TestMethod]
        public void TestRelatorio() 
        {

            Pagamento pgt = new Pagamento();
            pgt.IdPessoa = 9;
            var dataInicio = DateTime.Parse("2021-02-01");
            var dataFim = DateTime.Parse("2021-02-11");
          
            pgt.Observacao = "Pagamento referente ao mes de Março";
            pgt.IdPagamento = 2;
            var x = SvcPagamento.RelatorioPorPeriodo(dataInicio,dataFim);
        }

        [TestMethod]
        public void TestAtualizarPagamento()
        {

            Pagamento pgt = new Pagamento();
            pgt.IdPessoa = 9;
            pgt.DataPagt = DateTime.Parse("2021-02-09");
            pgt.DataInicio = DateTime.Parse("2021-03-09");
            pgt.DataFinal = DateTime.Parse("2021-04-09");
            pgt.Valor = 180;
            pgt.Desconto = 15;
            pgt.Observacao = "Pagamento referente ao mes de Março";
            pgt.IdPagamento = 2;
            SvcPagamento.AtualizarDadosPagamento(pgt);
        }

        [TestMethod]
        public void TestDeletePagamento() 
        {
            Pagamento pgt = new Pagamento();
            pgt.IdPagamento = 4;
            SvcPagamento.DeletePagamento(pgt);
        }
        
    }
}
