using gestaoTestesMariana.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTestesMariana.WinFormsApp.ModuloQuestao
{
    public class ConfiguracaoToolboxQuestao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Questões";

        public override string TooltipInserir => "Inserir uma nova Questão";

        public override string TooltipEditar => "Editar uma Questão existente";

        public override string TooltipExcluir => "Excluir uma Questão existente";
    }
}
