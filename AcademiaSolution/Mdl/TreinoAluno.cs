using AcademiaAtlas.Mdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaSolution.Mdl
{
    public class TreinoAluno :Treino
    {
        public int IdTreinoAluno { get; set; }
        public Enums.ETipo TipoTreino{ get; set; }
        public Enums.ERepeticoes NumRepeticoes { get; set; }
        public int Quantidade { get; set; }

    }
}
