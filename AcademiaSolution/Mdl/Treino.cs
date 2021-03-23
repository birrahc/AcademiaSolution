using AcademiaAtlas.Mdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AcademiaSolution.Mdl
{
    public class Treino:Aluno
    {
        public int IdTreino { get; set; }
        public Enums.EClassificacao IdTipoTreino { get; set; }
        public string DescricaoTreino { get; set; }
        public string Decricao { get; set; }
    }
}
