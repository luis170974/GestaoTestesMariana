using gestaoTestesMariana.Dominio.Compartilhado;
using gestaoTestesMariana.Dominio.ModuloDisciplina;
using gestaoTestesMariana.Dominio.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTestesMariana.Dominio.ModuloQuestao
{
    public class Questao : EntidadeBase<Questao>
    {
        public List<Disciplina> Disciplina { get; set; }

        public List<Materia> Materia { get; set; }

        public string Pergunta { get; set; }

        public List<Alternativa> Alternativas { get; set; }

        public override void Atualizar(Questao registro)
        {
            
        }
    }
}
