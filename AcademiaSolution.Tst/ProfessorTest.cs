using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;
using AcademiaSolution.Svc;
using AcademiaAtlas.Mdl;
using AcademiaAtlas.Svc;

namespace AcademiaAtlas.Tst
{
    [TestClass]
    public class ProfessorTest
    {

        [TestMethod]
        public void TestCadastroProfessor()
        {
            Professor professor = new Professor();
            professor.Nome = "Samira Antunes";
            professor.Cpf = "05765118976";
            professor.Nascimento = DateTime.Parse("1984-09-19");
            professor.Telefone = "48991776655";
            professor.WhatsApp = "48991765544";
            professor.Email = "sami@hotmail.com";
            professor.Formacao = "mestre em Educação Fisica";
            
            SvcProfessor.CadastrarProfessor(professor);
            //new DateTime(1978, 11, 7);

        }
        [TestMethod]
        public void TestBuscar()
        {
            var x = SvcProfessor.BuscarProfessor(); 

        }

        [TestMethod]
        public void TestAtualizarProfessor()
        {
            Professor professor = new Professor();
            professor.Nome = "Junior";
            professor.Cpf = "05765118976";
            professor.Nascimento = DateTime.Parse("1984-03-14");
            professor.Telefone = "48991480381";
            professor.WhatsApp = "48991480381";
            professor.Email = "birrahc@hotmail.com";
            professor.Formacao = "Bacharel em Educação Fisica";
            professor.IdPessoa = 1;

            SvcProfessor.AtualizarDadosProfessor(professor);
            //new DateTime(1978, 11, 7);

        }

        [TestMethod]
        public void TestDeleteProfessor()
        {
            Professor professor = new Professor();
            professor.IdPessoa =2;

            SvcProfessor.DeleteProfessor(professor);
            //new DateTime(1978, 11, 7);

        }
    }
}
