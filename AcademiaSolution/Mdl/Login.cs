using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CryptSharp;


namespace AcademiaAtlas.Mdl
{
    public class Login
    {
        public int IdLogin { get; set; }
        private string senha; 
        public string Usuario { get; set; }
        public string Senha { get; set;}
    }

}
