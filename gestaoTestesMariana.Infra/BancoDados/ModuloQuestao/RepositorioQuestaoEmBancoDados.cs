using FluentValidation.Results;
using gestaoTestesMariana.Dominio.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTestesMariana.Infra.BancoDados.ModuloQuestao
{
    public class RepositorioQuestaoEmBancoDados : IRepositorioQuestao
    {
        public ValidationResult Editar(Questao registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Questao registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Inserir(Questao novoRegistro)
        {
            throw new NotImplementedException();
        }

        public Questao SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Questao> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
