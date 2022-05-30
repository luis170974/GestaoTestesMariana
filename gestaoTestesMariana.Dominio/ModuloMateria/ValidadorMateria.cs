using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTestesMariana.Dominio.ModuloMateria
{
    public class ValidadorMateria :  AbstractValidator<Materia>
    {
        public ValidadorMateria()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty().WithMessage("O nome da materia nao pode ser vazio");

            RuleFor(x => x.Disciplina)
                .NotNull()
                .NotEmpty().WithMessage("A disciplina nao pode ser vazia");


        }
    }
}
