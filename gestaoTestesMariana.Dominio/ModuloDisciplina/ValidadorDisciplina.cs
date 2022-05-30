using gestaoTestesMariana.Dominio.Compartilhado;
using FluentValidation;
using gestaoTestesMariana.Dominio.ModuloDisciplina;

namespace gestaoTestesMariana.Infra.Arquivos.ModuloDisciplina
{
    public class ValidadorDisciplina : AbstractValidator<Disciplina>
    {
        public ValidadorDisciplina()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty().WithMessage("O nome da disciplina nao pode ser vazio");
        }
    }
}