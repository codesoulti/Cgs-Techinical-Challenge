using Cds.Technical.Challenge.Application.Contracts;
using Cgs.Technical.Challenge.Application.Validator;
using FluentValidation;

namespace Cgs.Technical.Challenge.Application.NumberDecompositions.Validators
{
    public class NumberDecompositionDtoValidator : AbstractValidatorCustom<NumberDecompositionDto>
    {
        public NumberDecompositionDtoValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty()
                .WithMessage("Numero não pode ser nulo ou vazio.");
        }
    }
}
