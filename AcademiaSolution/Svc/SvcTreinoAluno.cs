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
    public class SvcTreinoAluno
    {
        public static void CadastrarTreinoAluno(TreinoAluno pTreinoAluno) 
        {
            VerificaDados(pTreinoAluno);

            ConectDb conexao = new ConectDb();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"INSERT INTO treino_aluno (fkclassificacao, fkaluno, fktreino, quantidade, fkrepeticoes) VALUES (@fkclassificacao, @fkaluno, @fktreino, @quantidade, @fkrepeticoes)";
            cmd.Parameters.AddWithValue("@fkclassificacao",pTreinoAluno.TipoTreino);
            cmd.Parameters.AddWithValue("@fkaluno", pTreinoAluno.IdPessoa);
            cmd.Parameters.AddWithValue("@fktreino", pTreinoAluno.IdTreino);
            cmd.Parameters.AddWithValue("@quantidade", pTreinoAluno.Quantidade);
            cmd.Parameters.AddWithValue("@fkrepeticoes", pTreinoAluno.NumRepeticoes);

            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }

        public static List<TreinoAluno> BuscarTreinoAluno() 
        {
            List<TreinoAluno> listaTreinoAluno = new List<TreinoAluno>();

            ConectDb conexao = new ConectDb();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"SELECT id_treino_aluno, fkclassificacao, nome, descricao, quantidade, fkrepeticoes,fktipo FROM treino_aluno ta
                                inner join classificacao c on c.id_classificacao = ta.fkclassificacao
                                    inner join aluno al on al.id_aluno=ta.fkaluno
                                        inner join  treino tr on tr.id_treino = ta.fktreino
                                            inner join tipo_treino tt on tt.id_tipo_treino=tr.fktipo
                                                inner join repeticoestreino rt on rt.id_repeticoestreino = ta.fkrepeticoes";

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) 
            {
                TreinoAluno treinoAluno = new TreinoAluno();

                treinoAluno.IdTreinoAluno = (int)reader["id_treino_aluno"];
                treinoAluno.TipoTreino =(Enums.ETipo)reader["fkclassificacao"];
                treinoAluno.Nome = reader["nome"].ToString();
                treinoAluno.DescricaoTreino = reader["descricao"].ToString();
                treinoAluno.Quantidade =(int) reader["quantidade"];
                treinoAluno.NumRepeticoes = (Enums.ERepeticoes)reader["fkrepeticoes"];
                treinoAluno.IdTipoTreino = (Enums.EClassificacao)reader["fktipo"];
               

                listaTreinoAluno.Add(treinoAluno);
            }
            return listaTreinoAluno;

            conexao.Dispose();

        }

        public static void AtualizarTreinoAluno(TreinoAluno treinoAluno) 
        {

            if (treinoAluno.IdTreinoAluno == null)
            {
                throw new ArgumentException("A chave da tabela  esta nula");
            }
            VerificaDados(treinoAluno);


            ConectDb conexao = new ConectDb();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"UPDATE treino_aluno SET fkclassificacao=@fkclassificacao, fkaluno=@fkaluno, fktreino=@fktreino, quantidade=@quantidade, fkrepeticoes=@fkrepeticoes where id_treino_aluno=@id";

            cmd.Parameters.AddWithValue("@fkclassificacao",treinoAluno.TipoTreino);
            cmd.Parameters.AddWithValue("@fkaluno", treinoAluno.IdPessoa);
            cmd.Parameters.AddWithValue("@fktreino", treinoAluno.IdTreino);
            cmd.Parameters.AddWithValue("@quantidade", treinoAluno.Quantidade);
            cmd.Parameters.AddWithValue("@fkrepeticoes", treinoAluno.NumRepeticoes);
            cmd.Parameters.AddWithValue("@id", treinoAluno.IdTreinoAluno);

            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }

        public static void DeletarTreinoAluno(TreinoAluno treinoAluno) 
        {


            if (treinoAluno.IdTreinoAluno== null)
            {
                throw new ArgumentException("A chave da tabela  esta nula");
            }

            VerificaDados(treinoAluno);

            ConectDb conexao = new ConectDb();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"DELETE FROM treino_aluno WHERE id_treino_aluno = @id_treino_aluno";

            cmd.Parameters.AddWithValue("@id_treino_aluno", treinoAluno.IdTreinoAluno);

            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }

        internal static void VerificaDados(TreinoAluno pAlunoTreino)
        {
            if (pAlunoTreino == null)
            {
                throw new ArgumentException(nameof(pAlunoTreino));
            }
           
            
            if (pAlunoTreino.TipoTreino == null)
            {
                throw new ArgumentException("O Tipo de treino não pode estar vazio");

                if (pAlunoTreino.IdTreino == null )
                {
                    throw new ArgumentException("O Campo Treino não pode ficar vazio");
                }
            }
            if (pAlunoTreino.IdPessoa == null) 
            {
                throw new ArgumentException("O Campo Aluno nao pode ficar vazio");
            }
            if (pAlunoTreino.Quantidade==null) 
            {
                throw new ArgumentException("O Campo qunatidade nao pode ficar vazio");
            }
            if (pAlunoTreino.NumRepeticoes==null) 
            {
                throw new ArgumentException("O Campo Quantidade de repetições nao pode nao pode ficar vazio");
            }
        }
    }
}
