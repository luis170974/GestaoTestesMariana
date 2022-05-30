using gestaoTestesMariana.Dominio.Compartilhado;
using gestaoTestesMariana.Dominio.ModuloDisciplina;
using gestaoTestesMariana.Dominio.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTestesMariana.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public string Titulo { get; set; }
        
        public List<Disciplina> Disciplinas { get; set; }

        public List<Materia> Materias { get; set; }

        public int QtdQuestoes { get; set; }

        public DateTime DataTeste { get; set; }

        public override void Atualizar(Teste registro)
        {
            
        }
    }
}
