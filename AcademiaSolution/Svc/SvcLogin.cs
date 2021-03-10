using AcademiaAtlas.Mdl;
using AcademiaSolution.Dao;
using CryptSharp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaSolution.Svc
{
    public class SvcLogin
    {
        public static void CadastrarLogin(Login pLogin)
        {

           VerificaDados(pLogin);

            ConectDb conexao = new ConectDb();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"INSERT INTO login (login, senha) VALUES (@login, @senha)";

            cmd.Parameters.AddWithValue("@login", pLogin.Usuario);
            cmd.Parameters.AddWithValue("@senha", SenhaMd5(pLogin));

            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }

        public static List<Login> BuscarUsuariosSistema()
        {
            List<Login> usuarios = new List<Login>();

            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"SELECT * FROM login";

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Login pLogin = new Login();
                pLogin.IdLogin = (int)reader["id_login"];
                pLogin.Usuario = (string)reader["login"];
                pLogin.Senha = reader["senha"].ToString();

                usuarios.Add(pLogin);
            }

            return usuarios;

            conexao.Dispose();

        }

        public static void AtualizarDadosLoginUsuario(Login pLogin)
        {
            if (pLogin.IdLogin == null)
            {
                throw new ArgumentException("A chave da tabela  esta nula");
            }
            VerificaDados(pLogin);

            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"UPDATE login  SET login=@login senha=@senha WHERE id_login=@id";

            cmd.Parameters.AddWithValue("@id", pLogin.IdLogin);
            cmd.Parameters.AddWithValue("@login", pLogin.Usuario);
            cmd.Parameters.AddWithValue("@senha", SenhaMd5(pLogin));

            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }

        public static void DeletarUsuarioDoSistema(Login pLogin)
        {
            if (pLogin == null)
            {
                throw new ArgumentException(nameof(pLogin));
            }

            if (pLogin.IdLogin == null)
            {
                throw new ArgumentException("A chave da tabela  esta nula");
            }
            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"DELETE FROM login WHERE id_login=@id";

            cmd.Parameters.AddWithValue("@id", pLogin.IdLogin);

            cmd.ExecuteNonQuery();

            conexao.Dispose();
        }

        private static string SenhaMd5(Login pSenha) 
        {
            return Crypter.MD5.Crypt(pSenha.Senha);
        }

        internal static void VerificaDados(Login pLogin)
        {
            if (pLogin == null)
            {
                throw new ArgumentException(nameof(pLogin));
            }
            if (pLogin.Usuario == null)
            {
                throw new ArgumentException("O Campo Usuario não pode estar vazio");
            }
            if (String.IsNullOrEmpty(pLogin.Senha)) 
            {
                throw new ArgumentException("O Campo Usuario não pode estar vazio");
            }
        }
    }
}
