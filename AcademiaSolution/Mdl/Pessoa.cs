using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaSolution.Mdl
{
    public abstract class Pessoa 
    {
        public int IdPessoa { get; set; }
        public int UltimoRegistroSql { get; set; }
        public string Nome { get; set; }
        public Enums.ESexo Genero { get; set; }
        public string SiglaSexo { get; set; }
        public string Descricao { get; set; }
        public DateTime  Nascimento { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string WhatsApp { get; set; }
        public string Email { get; set; }
    }
}
