using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaAtlas.Mdl
{
    class Pagamento
    {
        public int IdPagamento { get; set; }
        public int FkAluno { get; set; }
        public DateTime DataPagt { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public double Valor { get; set; }
        public double Desconto { get; set; }
        public string Observacao { get; set; }
    }
}
