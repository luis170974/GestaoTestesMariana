using gestaoTestesMariana.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTestesMariana.WinFormsApp.ModuloMateria
{
    internal class ConfiguracaoToolboxMateria : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Materias";

        public override string TooltipInserir => "Inserir uma nova Materia";

        public override string TooltipEditar => "Editar uma Materia existente";

        public override string TooltipExcluir => "Excluir uma Materia existente";
    }
}
