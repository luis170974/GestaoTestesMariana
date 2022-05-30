using FluentValidation.Results;
using gestaoTestesMariana.Dominio.ModuloTeste;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTestesMariana.Infra.BancoDados.ModuloTeste
{
    public class RepositorioTesteEmBancoDados : IRepositorioTeste
    {
        public ValidationResult Editar(Teste registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Teste registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Inserir(Teste novoRegistro)
        {
            throw new NotImplementedException();
        }

        public Teste SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Teste> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
