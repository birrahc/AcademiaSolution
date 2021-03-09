using AcademiaAtlas.Mdl;
using AcademiaSolution.Dao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaSolution.Svc
{
    public class SvcTreino
    {
        public static void CadastrarTreino(Treino pTreino)
        {

            VerificaDados(pTreino);

            ConectDb conexao = new ConectDb();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"INSERT INTO treino (fktipo, descricao) VALUES (@fktipo, @descricao)";

            cmd.Parameters.AddWithValue("@fktipo", pTreino.FkTipo);
            cmd.Parameters.AddWithValue("@descricao", pTreino.Decricao);

            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }

        public static List<Treino> BuscarTreino()
        {
            List<Treino> treinos = new List<Treino>();

            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"SELECT * FROM treino";

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                
                Treino pTreino = new Treino();
                pTreino.IdTreino = (int)reader["id_treino"];
                pTreino.FkTipo = (int)reader["fktipo"];
                pTreino.Decricao = reader["descricao"].ToString();

                treinos.Add(pTreino);
            }

            return treinos;

            conexao.Dispose();

        }

        public static void AtualizarTreino(Treino pTreino)
        {
            if (pTreino.IdTreino == null)
            {
                throw new ArgumentException("A chave da tabela  esta nula");
            }
            VerificaDados(pTreino);

            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"UPDATE treino SET fktipo=@fktipo, descricao=@descricao WHERE id_treino=@id";

            cmd.Parameters.AddWithValue("@fktipo", pTreino.FkTipo);
            cmd.Parameters.AddWithValue("@descricao", pTreino.Decricao);
            cmd.Parameters.AddWithValue("@id", pTreino.IdTreino);

            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }

        public static void DeletarTreino(Treino pTreino)
        {
            if (pTreino == null)
            {
                throw new ArgumentException(nameof(pTreino));
            }

            if (pTreino.IdTreino == null)
            {
                throw new ArgumentException("A chave da tabela  esta nula");
            }
            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"DELETE FROM Treino WHERE id_treino=@id";

            cmd.Parameters.AddWithValue("@id", pTreino.IdTreino);

            cmd.ExecuteNonQuery();

            conexao.Dispose();
        }

        internal static void VerificaDados(Treino pTreino)
        {
            if (pTreino == null)
            {
                throw new ArgumentException(nameof(pTreino));
            }
            if (pTreino.FkTipo == null)
            {
                throw new ArgumentException("O Campo Nome não pode estar vazio");

                if (pTreino.Decricao == null || pTreino.Decricao == "")
                {
                    throw new ArgumentException("O Campo Nascimento pode ficar vazio");
                }
            }
        }
    }
}
