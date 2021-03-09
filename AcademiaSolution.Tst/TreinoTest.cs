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
    public class TreinoTest
    {
        [TestMethod]
        public void TesCadastroTreino()
        {
            Treino pTreino = new Treino();
            pTreino.FkTipo = 1;
            pTreino.Decricao = "Biceps Com Corda";
            SvcTreino.CadastrarTreino(pTreino);
        }


        [TestMethod]
        public void TesBuscaTreino()
        {
            var x = SvcTreino.BuscarTreino();
        }


        [TestMethod]
        public void TesAtualizaTreino()
        {
            Treino pTreino = new Treino();
            pTreino.FkTipo = 2;
            pTreino.Decricao = "Triceps com barra";
            pTreino.IdTreino = 1;
            SvcTreino.AtualizarTreino(pTreino);
        }


        [TestMethod]
        public void TesDeleteAluno()
        {
            Treino pTreino = new Treino();
            pTreino.IdTreino = 1;
            SvcTreino.DeletarTreino(pTreino);
        }
    }
}
