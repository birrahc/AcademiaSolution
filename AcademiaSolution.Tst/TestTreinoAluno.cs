using AcademiaSolution.Mdl;
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
    public class TestTreinoAluno
    {
        [TestMethod]
        public void TestCadastrarTreinoAluno() 
        {
            TreinoAluno treinoAluno = new TreinoAluno();
            treinoAluno.TipoTreino = Enums.ETipo.A;
            treinoAluno.IdPessoa = 4;
            treinoAluno.IdTreino = 4;
            treinoAluno.Quantidade = 9;
            treinoAluno.NumRepeticoes = Enums.ERepeticoes._4X;

            SvcTreinoAluno.CadastrarTreinoAluno(treinoAluno);
        }

        [TestMethod]
        public void TestBuscaTreinoAluno()
        {
            var x = SvcTreinoAluno.BuscarTreinoAluno();
        }

        public void TestAtualizaTreinoAluno()
        {
            TreinoAluno treinoAluno = new TreinoAluno();
            treinoAluno.TipoTreino = Enums.ETipo.A;
            treinoAluno.IdPessoa = 4;
            treinoAluno.IdTreino = 2;
            treinoAluno.Quantidade = 9;
            treinoAluno.NumRepeticoes = Enums.ERepeticoes._4X;

            SvcTreinoAluno.CadastrarTreinoAluno(treinoAluno);
        }

        [TestMethod]
        public void TestAtualizarTreinoAluno()
        {
            TreinoAluno treinoAluno = new TreinoAluno();
            treinoAluno.TipoTreino = Enums.ETipo.B;
            treinoAluno.IdPessoa = 4;
            treinoAluno.IdTreino = 4;
            treinoAluno.Quantidade = 13;
            treinoAluno.NumRepeticoes = Enums.ERepeticoes._6X;
            treinoAluno.IdTreinoAluno = 3;

            SvcTreinoAluno.AtualizarTreinoAluno(treinoAluno);
        }

        [TestMethod]
        public void TestDeletarTreinoAluno()
        {
            TreinoAluno treinoAluno = new TreinoAluno();
            treinoAluno.IdTreinoAluno = 3;

            SvcTreinoAluno.DeletarTreinoAluno(treinoAluno);
        }
    }


    
}
