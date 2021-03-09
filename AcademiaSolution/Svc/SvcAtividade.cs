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
    public class SvcAtividade
    {

        public static void CadastrarAtividade(Atividade pAtividade)
        {
           
            VerificaDados(pAtividade);

            ConectDb conexao = new ConectDb();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"INSERT INTO atividade (titulo, descricao, dias_semana_horario) VALUES (@titulo, @descricao, @dias_semana_horario)";

            cmd.Parameters.AddWithValue("@titulo", pAtividade.Titulo);
            cmd.Parameters.AddWithValue("@descricao", pAtividade.Descricao);
            cmd.Parameters.AddWithValue("@dias_semana_horario", pAtividade.DiasSemanaHorario);

            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }

        public static List<Atividade> BuscarAtividade()
        {
            List<Atividade> atividades = new List<Atividade>();

            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"SELECT * FROM atividade";

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Atividade atividade = new Atividade();
                atividade.IdAtividade = (int)reader["id_atividade"];
                atividade.Titulo = reader["titulo"].ToString();
                atividade.Descricao = reader["descricao"].ToString();
                atividade.DiasSemanaHorario = reader["dias_semana_horario"].ToString();

                atividades.Add(atividade);
            }

            return atividades;

            conexao.Dispose();

        }

        public static void AtualizarAtividade(Atividade pAtividade)
        {
            if (pAtividade.IdAtividade == null)
            {
                throw new ArgumentException("A chave da tabela  esta nula");
            }
            VerificaDados(pAtividade);

            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"UPDATE atividade SET titulo=@titulo, descricao=@descricao, dias_semana_horario=@dias_semana_horario WHERE id_atividade=@id=@id";

            cmd.Parameters.AddWithValue("@titulo", pAtividade.Titulo);
            cmd.Parameters.AddWithValue("@descricao", pAtividade.Descricao);
            cmd.Parameters.AddWithValue("@dias_semana_horario", pAtividade.DiasSemanaHorario);
            cmd.Parameters.AddWithValue("@id", pAtividade.IdAtividade);

            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }

        public static void DeletarAtividade(Atividade pAtividade)
        {
            if (pAtividade == null)
            {
                throw new ArgumentException(nameof(pAtividade));
            }

            if (pAtividade.IdAtividade == null)
            {
                throw new ArgumentException("A chave da tabela  esta nula");
            }
            ConectDb conexao = new ConectDb();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.connection;
            cmd.CommandText = @"DELETE FROM atividade WHERE id_atividade=@id";

            cmd.Parameters.AddWithValue("@id", pAtividade.IdAtividade);

            cmd.ExecuteNonQuery();

            conexao.Dispose();
        }

        internal static void VerificaDados(Atividade atividade)
        {
            if (atividade == null)
            {
                throw new ArgumentException(nameof(atividade));
            }
            if (String.IsNullOrEmpty(atividade.Titulo))
            {
                throw new ArgumentException("O Campo Nome não pode estar vazio");

                if (atividade.Descricao == null || atividade.Descricao == "")
                {
                    throw new ArgumentException("O Campo Nascimento pode ficar vazio");
                }
            }
        }
    }
}
