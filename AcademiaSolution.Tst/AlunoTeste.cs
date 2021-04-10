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
    public class AlunoTeste
    {
        [TestMethod]
        public void TesCadastroAluno()
        {
            Aluno aluno = new Aluno();
            aluno.Nome = "Claudinir Santos";
            aluno.Cpf = "05365128976";
            aluno.Nascimento = DateTime.Parse("1990-09-02");
            aluno.Telefone = "48991443211";
            aluno.Email = "clausantos@gmail.com";
            aluno.WhatsApp = "48991483355";
            SvcAluno.InserirDadosAluno(aluno);
        }


        [TestMethod]
        public void TesBuscaAluno() 
        {
            var pNascimento = DateTime.Parse("1980-11-18");
            var anos = SvcAluno.BuscarAluno().GroupBy(a=>a.Nascimento).Where(b=>b.Key.Year==pNascimento.Year && b.Key.Month== pNascimento.Month);
            var mensagem = "";
            if (anos.Any())

            {
                mensagem = anos.First().Key.ToString();
               var x= anos;
                Console.WriteLine("Resultado da pesquisa {0}",mensagem);
            }
            
        }

        [TestMethod]
        public void TesBuscaAlunoDetalhado()
        {
            Aluno aluno = new Aluno();
            aluno.IdPessoa = 4;

            var x = SvcAluno.ListarAlunoPorID(aluno);
           
        }

        [TestMethod]
        public void TesBuscaAlunoDetalhadobuca()
        {
            Aluno aluno = new Aluno();
            aluno.IdPessoa = 4;
            aluno.Nome = "Arlete Santana";

            var x = SvcAluno.BuscarPorNomeEId(aluno);

        }


        [TestMethod]
        public void TesAtualizaAluno() 
        {
            Aluno aluno = new Aluno();
            aluno.Nome = "Arlete Santana";
            aluno.Cpf = "05465118934";
            aluno.Nascimento = DateTime.Parse("1980-11-18");
            aluno.Telefone = "4833696677";
            aluno.Email = "arletesantana@gmail.com";
            aluno.WhatsApp = "48991480381";
            aluno.IdPessoa = 4;
            SvcAluno.AtualizarDadosAluno(aluno);
        }


        [TestMethod]
        public void TesDeleteAluno() 
        {
            Aluno aluno = new Aluno();
            aluno.IdPessoa = 5;
            SvcAluno.DeletarAluno(aluno);
        }


    }
}
