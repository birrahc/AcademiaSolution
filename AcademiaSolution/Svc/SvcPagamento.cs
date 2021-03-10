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
            //VerificaDados(pPagamento);
            ConectDb conexao = new ConectDb();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"INSERT INTO Pagamentos (fkaluno_pgt, data_pgt, ref_data_in, ref_data_fi, valor, desconto, observacao) VALUES (@fkaluno_pgt, @data_pgt, @ref_data_in, @ref_data_fi, @valor, @desconto, @observacao)";

            cmd.Parameters.AddWithValue("@fkaluno_pgt", pPagamento.AlunoId);
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
            cmd.CommandText = @"SELECT * FROM pagamentos";

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Pagamento pPagamento = new Pagamento();
                pPagamento.IdPagamento = (int)reader["id_pgt"];
                pPagamento.AlunoId = (int)reader["fkaluno_pgt"];
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
            
            cmd.Parameters.AddWithValue("@fkaluno_pgt", pPagamento.AlunoId);
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
            if (pPagamento.AlunoId==null)
            {
                throw new ArgumentException("O Campo Nome não pode estar vazio");
            }
            if (pPagamento.DataPagt==null && pPagamento.DataInicio == null && pPagamento.DataFinal == null && pPagamento.Valor==null)
            {
                throw new ArgumentException("Os Campos Data, Data Inicio, Data final e Valor não podem ficar vazios");
            }
            
        }
    }
}
