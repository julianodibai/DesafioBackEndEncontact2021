using FluentValidation;
using TesteBackendEnContact.Core.Domain.ContactBook;

namespace TesteBackendEnContact.Core.Validators
{
    public class ContactBookValidator : AbstractValidator<ContactBook>
    {
        public ContactBookValidator()
        {
            RuleFor(x => x)
                    .NotEmpty()
                    .WithMessage("A entidade não pode ser vazia.")

                    .NotNull()
                    .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Id)
                    .NotEmpty()
                    .WithMessage("O Id não pode ser vazio.")  

                    .NotNull()
                    .WithMessage("O Id não pode ser nulo.");    

            RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("O nome não pode ser vazio.")  

                    .NotNull()
                    .WithMessage("O nome não pode ser nulo.")

                    .MinimumLength(2)
                    .WithMessage("O nome pode ter no minimo 2 caracters")

                    .MaximumLength(80)
                    .WithMessage("O nome pode ter no maximo 80 caracters");     
        }
    }
}