using gestaoTestesMariana.Dominio.Compartilhado;
using gestaoTestesMariana.Dominio.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTestesMariana.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public Materia()
        {

        }

        public string Nome { get; set; }

        public Disciplina Disciplina { get; set; }

        public override void Atualizar(Materia registro)
        {
            
        }
    }
}
