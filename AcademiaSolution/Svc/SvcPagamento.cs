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
    public class SvcPagamento
    {
        public static void CadastrarPagamento(Pagamento pPagamento)
        {
            VerificaDados(pPagamento);
            ConectDb conexao = new ConectDb();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"INSERT INTO Pagamentos (fkaluno_pgt, data_pgt, ref_data_in, ref_data_fi, valor, desconto, observacao) VALUES (@fkaluno_pgt, @data_pgt, @ref_data_in, @ref_data_fi, @valor, @desconto, @observacao)";

            cmd.Parameters.AddWithValue("@fkaluno_pgt", pPagamento.IdPessoa);
            cmd.Parameters.AddWithValue("@data_pgt", pPagamento.DataPagt);
            cmd.Parameters.AddWithValue("@ref_data_in", pPagamento.DataInicio);
            cmd.Parameters.AddWithValue("@ref_data_fi", pPagamento.DataFinal);
            cmd.Parameters.AddWithValue("@valor", pPagamento.Valor);
            cmd.Parameters.AddWithValue("@desconto", pPagamento.Desconto);
            cmd.Parameters.AddWithValue("@observacao", pPagamento.Observacao);

            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }

        public static List<Pagamento> BuscarPagamento()
        {
            List<Pagamento> pagamentos = new List<Pagamento>();

            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"SELECT id_pgt, nome, data_pgt,ref_data_in,ref_data_fi, valor, desconto, observacao FROM academia_lr.pagamentos pg
                                    inner join aluno al on pg.fkaluno_pgt=al.id_aluno";

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Pagamento pPagamento = new Pagamento();
                pPagamento.IdPagamento = (int)reader["id_pgt"];
                pPagamento.Nome = (string)reader["nome"];
                pPagamento.DataPagt = (DateTime)reader["data_pgt"];
                pPagamento.DataInicio = (DateTime)reader["ref_data_in"];
                pPagamento.DataFinal = (DateTime)reader["ref_data_fi"];
                pPagamento.Valor = (double)reader["valor"];
                pPagamento.Desconto = (Double)reader["desconto"];
                pPagamento.Observacao = (string)reader["observacao"];

                pagamentos.Add(pPagamento);
            }

            return pagamentos;

            conexao.Dispose();

        }

        public static List<Pagamento> BuscarPagamentoPorId( Pagamento pgt)
        {
            List<Pagamento> pagamentos = new List<Pagamento>();

            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"SELECT id_pgt, nome, data_pgt,ref_data_in,ref_data_fi, valor, desconto, observacao FROM academia_lr.pagamentos pg
                                    inner join aluno al on pg.fkaluno_pgt=al.id_aluno where id_aluno = @idAluno";
            cmd.Parameters.AddWithValue("@idAluno", pgt.IdPessoa);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Pagamento pPagamento = new Pagamento();
                pPagamento.IdPagamento = (int)reader["id_pgt"];
                pPagamento.Nome = (string)reader["nome"];
                pPagamento.DataPagt = (DateTime)reader["data_pgt"];
                pPagamento.DataInicio = (DateTime)reader["ref_data_in"];
                pPagamento.DataFinal = (DateTime)reader["ref_data_fi"];
                pPagamento.Valor = (double)reader["valor"];
                pPagamento.Desconto = (Double)reader["desconto"];
                pPagamento.Observacao = (string)reader["observacao"];

                pagamentos.Add(pPagamento);
            }

            return pagamentos;

            conexao.Dispose();

        }

        public static List<Pagamento> RelatorioPorPeriodo(DateTime pDataInicial, DateTime pDataFinal)
        {
            if (pDataInicial == null) 
            {
                pDataInicial = DateTime.Now;
            }
            if (pDataFinal == null) 
            {
                pDataFinal = DateTime.Now;
            }
            List<Pagamento> pagamentos = new List<Pagamento>();

            ConectDb conexao = new ConectDb();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"select id_pgt, nome, data_pgt, valor, desconto from pagamentos p
                                inner join aluno a on p.fkaluno_pgt = a.id_aluno
                                WHERE data_pgt BETWEEN @dataInicio AND @dataFinal";

            cmd.Parameters.AddWithValue("@dataInicio", pDataInicial);
            cmd.Parameters.AddWithValue("@dataFinal", pDataFinal);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Pagamento pPagamento = new Pagamento();
                pPagamento.IdPagamento = (int)reader["id_pgt"];
                pPagamento.Nome = (string)reader["nome"];
                pPagamento.DataPagt = (DateTime)reader["data_pgt"];
                pPagamento.Valor = (double)reader["valor"];
                pPagamento.Desconto = (Double)reader["desconto"];
                

                pagamentos.Add(pPagamento);
            }

            return pagamentos;

            conexao.Dispose();

        }

        public static void AtualizarDadosPagamento(Pagamento pPagamento)
        {
            if (pPagamento.IdPagamento == null)
            {
                throw new ArgumentException("A chave da tabela  esta nula");
            }
            VerificaDados(pPagamento);

            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"UPDATE pagamentos SET fkaluno_pgt=@fkaluno_pgt, data_pgt=@data_pgt, ref_data_in=@ref_data_in, ref_data_fi=@ref_data_fi, valor=@valor, desconto=@desconto, observacao=@observacao WHERE id_pgt=@id";
            
            cmd.Parameters.AddWithValue("@fkaluno_pgt", pPagamento.IdPessoa);
            cmd.Parameters.AddWithValue("@data_pgt", pPagamento.DataPagt);
            cmd.Parameters.AddWithValue("@ref_data_in", pPagamento.DataInicio);
            cmd.Parameters.AddWithValue("@ref_data_fi", pPagamento.DataFinal);
            cmd.Parameters.AddWithValue("@valor", pPagamento.Valor);
            cmd.Parameters.AddWithValue("@desconto", pPagamento.Desconto);
            cmd.Parameters.AddWithValue("@observacao", pPagamento.Observacao);
            cmd.Parameters.AddWithValue("@id", pPagamento.IdPagamento);

            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }

        public static void DeletePagamento(Pagamento pPagamento)
        {
            if (pPagamento == null)
            {
                throw new ArgumentException(nameof(pPagamento));
            }

            if (pPagamento.IdPagamento == null)
            {
                throw new ArgumentException("A chave da tabela  esta nula");
            }
            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"DELETE FROM pagamentos WHERE id_pgt=@id";

            cmd.Parameters.AddWithValue("@id", pPagamento.IdPagamento);

            cmd.ExecuteNonQuery();

            conexao.Dispose();
        }
        internal static void VerificaDados(Pagamento pPagamento)
        {
            if (pPagamento == null)
            {
                throw new ArgumentException(nameof(pPagamento));
            }
            if (pPagamento.IdPessoa==null)
            {
                throw new ArgumentException("O Id do Aluno não pode estar vazio");
            }
            if (pPagamento.DataPagt==null && pPagamento.DataInicio == null && pPagamento.DataFinal == null && pPagamento.Valor==null)
            {
                throw new ArgumentException("Os Campos Data, Data Inicio, Data final e Valor não podem ficar vazios");
            }
            
        }
    }
}
