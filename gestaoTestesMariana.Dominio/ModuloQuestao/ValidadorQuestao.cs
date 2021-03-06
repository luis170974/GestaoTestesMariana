using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTestesMariana.Dominio.ModuloQuestao
{
    public class ValidadorQuestao : AbstractValidator<Questao>
    {
        public ValidadorQuestao()
        {
            RuleFor(x => x.Pergunta)
                .NotNull()
                .NotEmpty().WithMessage("A Pergunta nao pode ser vazia");

            RuleFor(x => x.Materia)
                .NotNull()
                .NotEmpty().WithMessage("A materia nao pode ser vazia");

            RuleFor(x => x.Disciplina)
                .NotNull()
                .NotEmpty().WithMessage("A disciplina nao pode ser vazia");

            RuleFor(x => x.Alternativas)
                .NotNull()
                .NotEmpty().WithMessage("As alternativa(s) nao podem ser vazia(s)");


        }
    }
}
