using AcademiaAtlas.Mdl;
using AcademiaSolution.Dao;
using AcademiaSolution.Mdl;
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

            cmd.Parameters.AddWithValue("@fktipo", pTreino.IdTipoTreino);
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
            cmd.CommandText = @"SELECT id_treino,descricao_tipo, descricao FROM academia_lr.treino tn
                                    inner join tipo_treino tt on tt.id_tipo_treino= tn.fktipo";

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                
                Treino pTreino = new Treino();
                pTreino.IdTreino = (int)reader["id_treino"];
                pTreino.DescricaoTreino = reader["descricao_tipo"].ToString();
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

            cmd.Parameters.AddWithValue("@fktipo", pTreino.IdTipoTreino);
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
            cmd.CommandText = @"DELETE FROM treino WHERE id_treino=@id";

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
            if (pTreino.IdTipoTreino == null)
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
