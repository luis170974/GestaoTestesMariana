using gestaoTestesMariana.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTestesMariana.WinFormsApp.ModuloTeste
{
    public class ConfiguracaoToolboxTeste : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Testes";

        public override string TooltipInserir => "Inserir um novo Teste";

        public override string TooltipEditar => "Editar um Teste existente";

        public override string TooltipExcluir => "Excluir um Teste existente";
    }
}
