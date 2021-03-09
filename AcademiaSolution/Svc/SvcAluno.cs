
using AcademiaAtlas.Mdl;
using AcademiaSolution.Dao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaSolution.Svc
{
    public class SvcAluno
    {
       
        public static void InserirDadosAluno(Aluno pAluno)
        {
            VerificaDados(pAluno);

            ConectDb conexao = new ConectDb();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"INSERT INTO aluno (nome, nascimento, cpf, telefone, whatsapp, email) VALUES (@nome, @nascimento, @cpf, @telefone, @whatsapp, @email)";

            cmd.Parameters.AddWithValue("@nome", pAluno.Nome);
            cmd.Parameters.AddWithValue("@nascimento", pAluno.Nascimento);
            cmd.Parameters.AddWithValue("@cpf", pAluno.Cpf);
            cmd.Parameters.AddWithValue("@telefone", pAluno.Telefone);
            cmd.Parameters.AddWithValue("@whatsapp", pAluno.WhatsApp);
            cmd.Parameters.AddWithValue("@email", pAluno.Email);

            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }

        public static List<Aluno> BuscarAluno()
        {
            List<Aluno> alunos = new List<Aluno>();

            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"SELECT * FROM aluno";

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Aluno contato = new Aluno();
                contato.IdPessoa = (int)reader["id_aluno"];
                contato.Nome = reader["nome"].ToString();
                contato.Nascimento =(DateTime)reader["nascimento"];
                contato.Cpf =reader["cpf"].ToString();
                contato.Telefone = reader["telefone"].ToString();
                contato.WhatsApp = reader["whatsapp"].ToString();
                contato.Email = reader["Email"].ToString();

                alunos.Add(contato);
            }

            return alunos;

            conexao.Dispose();

        }

        public static void AtualizarDadosAluno(Aluno pAluno)
        {
            if (pAluno.IdPessoa == null)
            {
                throw new ArgumentException("A chave da tabela  esta nula");
            }
            VerificaDados(pAluno);

            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"UPDATE aluno SET nome=@nome, nascimento=@nascimento, cpf=@cpf, telefone=@telefone, whatsapp=@whatsapp, email=@email WHERE Id_aluno=@id";

            cmd.Parameters.AddWithValue("@nome", pAluno.Nome);
            cmd.Parameters.AddWithValue("@nascimento", pAluno.Nascimento);
            cmd.Parameters.AddWithValue("@cpf", pAluno.Cpf);
            cmd.Parameters.AddWithValue("@telefone", pAluno.Telefone);
            cmd.Parameters.AddWithValue("@whatsapp", pAluno.WhatsApp);
            cmd.Parameters.AddWithValue("@email", pAluno.Email);
            cmd.Parameters.AddWithValue("@id", pAluno.IdPessoa);

            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }

        public static void DeletarAluno(Aluno pAluno)
        {
            if (pAluno == null)
            {
                throw new ArgumentException(nameof(pAluno));
            }

            if (pAluno.IdPessoa == null)
            {
                throw new ArgumentException("A chave da tabela  esta nula");
            }
            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"DELETE FROM aluno WHERE id_aluno=@id";

            cmd.Parameters.AddWithValue("@id", pAluno.IdPessoa);

            cmd.ExecuteNonQuery();

            conexao.Dispose();
        }

        internal static void VerificaDados(Aluno aluno)
        {
            if (aluno == null)
            {
                throw new ArgumentException(nameof(aluno));
            }
            if (String.IsNullOrEmpty(aluno.Nome))
            {
                throw new ArgumentException("O Campo Nome não pode estar vazio");

                if (aluno.Nascimento == null || aluno.Nascimento.ToString() == "")
                {
                    throw new ArgumentException("O Campo Nascimento pode ficar vazio");
                }
            }
        }
    }
}
