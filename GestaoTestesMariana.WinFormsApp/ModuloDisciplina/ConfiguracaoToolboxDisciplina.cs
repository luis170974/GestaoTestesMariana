using gestaoTestesMariana.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;

namespace gestaoTestesMariana.WinFormsApp.ModuloDisciplina
{
    internal class ConfiguracaoToolboxDisciplina : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Disciplina";

        public override string TooltipInserir { get { return "Inserir uma nova disciplina contato"; } }

        public override string TooltipEditar { get { return "Editar uma disciplina existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma disciplina existente"; } }
    }
}
