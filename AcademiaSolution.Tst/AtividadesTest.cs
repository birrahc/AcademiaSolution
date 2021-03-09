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
    public class AtividadesTest
    {
        [TestMethod]
        public void testCadastroAtividade() 
        {
            Atividade atividade = new Atividade();
            atividade.Titulo = "Funcional";
            atividade.Descricao = "Ginastica, Aerobico";
            atividade.DiasSemanaHorario = "Segunda, Quarta e Sexta das 08:00 as 09:00";
            SvcAtividade.CadastrarAtividade(atividade);
        }

        [TestMethod]
        public void testBuscarAtividade()
        {
            
            var atividade = SvcAtividade.BuscarAtividade();
        }

        [TestMethod]
        public void testAtualizarAtividade()
        {
            Atividade atividade = new Atividade();
            atividade.Titulo = "Funcional, Hit";
            atividade.Descricao = "Ginastica, Aerobico, Hit";
            atividade.DiasSemanaHorario = "Segunda, Quarta e Sexta das 08:00 as 09:00 Sabado das 09:00 as 10:00";
            atividade.IdAtividade = 1;
            SvcAtividade.AtualizarAtividade(atividade);
        }

        [TestMethod]
        public void testDeleteAtividade()
        {
            Atividade atividade = new Atividade();
            atividade.IdAtividade = 2;
            SvcAtividade.DeletarAtividade(atividade);
        }
    }
}
