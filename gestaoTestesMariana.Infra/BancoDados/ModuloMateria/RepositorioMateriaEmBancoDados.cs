using FluentValidation.Results;
using gestaoTestesMariana.Dominio.ModuloDisciplina;
using gestaoTestesMariana.Dominio.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTestesMariana.Infra.BancoDados.ModuloMateria
{

    public class RepositorioMateriaEmBancoDados : IRepositorioMateria
    {
        private const string enderecoBanco =
        "Data Source=(LocalDB)\\MSSqlLocalDB;" +
        "Initial Catalog=gestaoDeTesteDb;" +
        "Integrated Security=True;" +
        "Pooling=False";

        private const string sqlInserir =
        @"INSERT INTO [TBMATERIA] 
                (
                    [NOME_MATERIA],   
                    [DISCIPLINA_NUMERO]
                )
            VALUES
                (
                    @NOME_MATERIA,
                    @DISCIPLINA_NUMERO
                ); 
        SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
        @"UPDATE TBMATERIA
                SET
                    [NOME_MATERIA]  = @NOME_MATERIA,
                    [DISCIPLINA_NUMERO] = @DISCIPLINA_NUMERO
                    

                 WHERE 
                    [NUMERO] = @NUMERO";

        private const string sqlExcluir =
        @"DELETE FROM TBMATERIA
                 WHERE NUMERO = @NUMERO";

        private const string sqlSelecionarTodos =
        @"SELECT 
		            MAT.NUMERO, 
		            MAT.NOME_MATERIA,
                    MAT.DISCIPLINA_NUMERO


	            FROM

		            [TBMATERIA] AS MAT 
                    INNER JOIN
                    [TBDISCIPLINA] AS DISC

                ON 
                     MAT.DISCIPLINA_NUMERO = DISC.NUMERO";

        private const string sqlSelecionarPorNumero =
        @"SELECT 
		            MAT.NUMERO, 
		            MAT.NOME_MATERIA, 
                    MAT.DISCIPLINA_NUMERO

                    

	            FROM 
		            [TBMATERIA] AS MAT

		        WHERE
                    MAT.NUMERO = @NUMERO";


        public ValidationResult Inserir(Materia novoRegistro)
        {
            var validador = new ValidadorMateria();

            var resultadoValidacao = validador.Validate(novoRegistro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosMateria(novoRegistro, comandoInsercao);

            conexaoComBanco.Open();

            var id = comandoInsercao.ExecuteScalar();

            novoRegistro.Numero = Convert.ToInt32(id);


            conexaoComBanco.Close();

            return resultadoValidacao;

        }



        public ValidationResult Editar(Materia registro)
        {
            var validador = new ValidadorMateria();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosMateria(registro, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Materia registro)
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


        public Materia SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorContato = comandoSelecao.ExecuteReader();

            Materia materia = null;
            if (leitorContato.Read())
                materia = ConverterParaMateria(leitorContato);

            conexaoComBanco.Close();

            return materia;
        }

        public List<Materia> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            List<Materia> materias = new List<Materia>();

            while (leitorMateria.Read())
            {
                Materia materia = ConverterParaMateria(leitorMateria);

                materias.Add(materia);
            }

            conexaoComBanco.Close();

            return materias;
        }



        private void ConfigurarParametrosMateria(Materia novoRegistro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NOME_MATERIA", novoRegistro.Nome);
            comando.Parameters.AddWithValue("DISCIPLINA_NUMERO", novoRegistro.Disciplina.Numero);
        }

        private Materia ConverterParaMateria(SqlDataReader leitorMateria)
        {
            string nome = Convert.ToString(leitorMateria["NOME_MATERIA"]);
            int disciplinaNumero = Convert.ToInt32(leitorMateria["DISCIPLINA_NUMERO"]);

            Materia materia = new Materia();


            materia.Nome = nome;    
        
          if(leitorMateria["DISCIPLINA_NUMERO"] != DBNull.Value)
            {
                var numeroDisciplina = Convert.ToInt32(leitorMateria["DISCIPLINA_NUMERO"]);
                var nomeDisciplina = Convert.ToString(leitorMateria["NOME_DISCIPLINA"]);

                materia.Disciplina = new Disciplina
                {
                    Numero = numeroDisciplina,
                    Nome = nomeDisciplina,
                };
            }


            return materia;

        }

    }
}


