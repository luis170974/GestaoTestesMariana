using FluentValidation.Results;
using gestaoTestesMariana.Dominio.ModuloDisciplina;
using gestaoTestesMariana.Infra.Arquivos.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTestesMariana.Infra.BancoDados.ModuloDisciplina
{
    public class RepositorioDisciplinaEmBancoDados : IRepositorioDisciplina
    {
        private const string enderecoBanco =
        "Data Source=(LocalDB)\\MSSqlLocalDB;" +
        "Initial Catalog=gestaoDeTesteDb;" +
        "Integrated Security=True;" +
        "Pooling=False";

        private const string sqlInserir =
        @"INSERT INTO [TBDISCIPLINA]
                (
                    [NOME]                 
                )
            VALUES
                (
                    @NOME,

                ); 
        SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
        @"UPDATE [TBDISCIPLINA]
                SET
                    [NOME]  = @NOME;                

                 WHERE [NUMERO] = @NUMERO";

        private const string sqlExcluir =
        @"DELETE FROM [TBDISCIPLINA]
                 WHERE [NUMERO] = @NUMERO";

        private const string sqlSelecionarTodos =
        @"SELECT 
		            [NUMERO], 
		            [NOME] 

	            FROM 
		            [TBDISCIPLINA]";

        private const string sqlSelecionarPorNumero =
        @"SELECT 
		            [NUMERO], 
		            [NOME] 

	            FROM 
		            [TBDISCIPLINA]
		        WHERE
                    [NUMERO] = @NUMERO";

        public ValidationResult Inserir(Disciplina novoRegistro)
        {
            var validador = new ValidadorDisciplina();

            var resultadoValidacao = validador.Validate(novoRegistro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosDisciplina(novoRegistro, comandoInsercao);

            conexaoComBanco.Open();

            var id = comandoInsercao.ExecuteScalar();

            novoRegistro.Numero = Convert.ToInt32(id);


            conexaoComBanco.Close();

            return resultadoValidacao;
        }



        public ValidationResult Editar(Disciplina registro)
        {
            var validador = new ValidadorDisciplina();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosDisciplina(registro, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Disciplina registro)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", registro.Numero);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public List<Disciplina> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorContato = comandoSelecao.ExecuteReader();

            List<Disciplina> disciplinas = new List<Disciplina>();

            while (leitorContato.Read())
            {
                Disciplina disciplina = ConverterParaDisciplina(leitorContato);

                disciplinas.Add(disciplina);
            }

            conexaoComBanco.Close();

            return disciplinas;
        }

        public Disciplina SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorContato = comandoSelecao.ExecuteReader();

            Disciplina disciplina = null;
            if (leitorContato.Read())
                disciplina = ConverterParaDisciplina(leitorContato);

            conexaoComBanco.Close();

            return disciplina;
        }

        private static Disciplina ConverterParaDisciplina(SqlDataReader leitorContato)
        {
            int numero = Convert.ToInt32(leitorContato["NUMERO"]);
            string nome = Convert.ToString(leitorContato["NOME"]);

            var disciplina = new Disciplina
            {
                Numero = numero,
                Nome = nome,
            };

            return disciplina;
        }

        private static void ConfigurarParametrosDisciplina(Disciplina novaDisciplina, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", novaDisciplina.Numero);
            comando.Parameters.AddWithValue("NOME", novaDisciplina.Nome);
        }
    }
}
