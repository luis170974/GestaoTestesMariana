using gestaoTestesMariana.Dominio.Compartilhado;
using gestaoTestesMariana.Dominio.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTestesMariana.Dominio.ModuloDisciplina
{
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public string Nome { get; set; }

        public List<Materia> materias { get; set; }

        

        public override void Atualizar(Disciplina registro)
        {
            
        }
    }
}
