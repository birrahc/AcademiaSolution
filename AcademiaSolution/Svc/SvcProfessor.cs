using AcademiaAtlas.Dao;
using AcademiaAtlas.Mdl;
using AcademiaSolution.Dao;
using Microsoft.Azure.Amqp.Framing;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademiaSolution;
namespace AcademiaAtlas.Svc
{
    public class SvcProfessor
    {
        public static void CadastrarProfessor(Professor pProfesssor)
        {
            VerificaDados(pProfesssor);
            ConectDb conexao = new ConectDb();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"INSERT INTO professor (nome,nascimento, cpf, telefone,whatsapp, email,formacao) VALUES (@nome,@nascimento,@cpf, @telefone, @whatsapp, @email,@formacao)"; 

            cmd.Parameters.AddWithValue("@nome", pProfesssor.Nome);
            cmd.Parameters.AddWithValue("@nascimento", pProfesssor.Nascimento);
            cmd.Parameters.AddWithValue("@cpf", pProfesssor.Cpf);
            cmd.Parameters.AddWithValue("@telefone", pProfesssor.Telefone);
            cmd.Parameters.AddWithValue("@whatsapp", pProfesssor.WhatsApp);
            cmd.Parameters.AddWithValue("@email", pProfesssor.Email);
            cmd.Parameters.AddWithValue("@formacao", pProfesssor.Formacao);

            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }

        public static List<Professor> BuscarProfessor()
        {
            List<Professor> prof = new List<Professor>();

                ConectDb conexao = new ConectDb();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.connection;
                cmd.CommandText = @"SELECT * FROM professor";

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    Professor contato= new Professor();
                    contato.IdPessoa = (int)reader["idprofessor"];
                    contato.Nome = (string)reader["nome"];
                    contato.Nascimento = (DateTime)reader["nascimento"];
                    contato.Cpf = (string)reader["cpf"];
                    contato.Telefone = (string)reader["telefone"];
                    contato.WhatsApp = (string)reader["whatsapp"];
                    contato.Email = (string)reader["Email"];
                    contato.Formacao = (string)reader["formacao"];

                    prof.Add(contato);
                }

                return prof;

            conexao.Dispose();
            
        }

        public static void AtualizarDadosProfessor(Professor professor)
        {
            if (professor.IdPessoa == null)
            {
                throw new ArgumentException("A chave da tabela  esta nula");
            }
            VerificaDados(professor);

            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"UPDATE professor SET nome=@nome, nascimento=@nascimento, cpf=@cpf, telefone=@telefone, whatsapp=@whatsapp, email=@email, formacao=@formacao WHERE Idprofessor=@id";

            cmd.Parameters.AddWithValue("@nome", professor.Nome);
            cmd.Parameters.AddWithValue("@nascimento", professor.Nascimento);
            cmd.Parameters.AddWithValue("@cpf", professor.Cpf);
            cmd.Parameters.AddWithValue("@telefone", professor.Telefone);
            cmd.Parameters.AddWithValue("@whatsapp", professor.WhatsApp);
            cmd.Parameters.AddWithValue("@email", professor.Email);
            cmd.Parameters.AddWithValue("@formacao", professor.Formacao);
            cmd.Parameters.AddWithValue("@id", professor.IdPessoa);

            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }

        public static void DeleteProfessor(Professor professor)
        {
            if (professor==null)
            {
                throw new ArgumentException(nameof(professor));
            }
            
            if (professor.IdPessoa == null) 
            {
                throw new ArgumentException("A chave da tabela  esta nula");
            }
            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"DELETE FROM professor WHERE Idprofessor=@id";

            cmd.Parameters.AddWithValue("@id", professor.IdPessoa);

            cmd.ExecuteNonQuery();

            conexao.Dispose();
        }

        internal static void VerificaDados(Professor professor)
        {
            if (professor == null)
            {
                throw new ArgumentException(nameof(professor));
            }
            if (String.IsNullOrEmpty(professor.Nome))
            {
                throw new ArgumentException("O Campo Nome não pode estar vazio");

                if (professor.Nascimento == null || professor.Nascimento.ToString() == "")
                {
                    throw new ArgumentException("O Campo Nascimento pode ficar vazio");
                }
            }
        }
    }
}
