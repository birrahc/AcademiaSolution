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
    public class TestLogin
    {
        [TestMethod]
        public void TestCadastrarLogin() 
        {
            Login lg = new Login();
            lg.Usuario = "san";
            lg.Senha = "123456";
            SvcLogin.CadastrarLogin(lg);
        
        }

        [TestMethod]
        public void TestBuscarUsuarios() 
        {
            var usuario = SvcLogin.BuscarUsuariosSistema();
        }

        [TestMethod]
        public void TestAtualizarUsuario() 
        {
            Login lg = new Login();
            lg.Usuario = "Gotardo";
            lg.Senha = "12";
            lg.IdLogin = 1;
            SvcLogin.AtualizarDadosLoginUsuario(lg);
        }
        [TestMethod]
        public void TestDeletarUsuario() 
        {
            Login del = new Login();
            del.IdLogin = 3;
            SvcLogin.DeletarUsuarioDoSistema(del);
        }
    }
}
