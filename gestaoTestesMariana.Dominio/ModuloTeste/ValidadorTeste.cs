using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTestesMariana.Dominio.ModuloTeste
{
    public class ValidadorTeste : AbstractValidator<Teste>
    {
        public ValidadorTeste()
        {

            RuleFor(x => x.Titulo)
                .NotNull()
                .NotEmpty().WithMessage("O Titulo nao pode ser vazio");

            RuleFor(x => x.Materias)
                .NotNull()
                .NotEmpty().WithMessage("A materia nao pode ser vazia");

            RuleFor(x => x.Disciplinas)
                .NotNull()
                .NotEmpty().WithMessage("A disciplina nao pode ser vazia");

            RuleFor(x => x.QtdQuestoes)
                .NotNull()
                .NotEmpty().WithMessage("A quantidade de questões não pode ser nula");

            RuleFor(x => x.DataTeste)
               .NotNull()
               .NotEmpty()
               .GreaterThanOrEqualTo((x) => DateTime.Now.Date);

        }
    }
}
