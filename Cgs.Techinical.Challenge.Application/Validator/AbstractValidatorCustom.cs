using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace Cgs.Technical.Challenge.Application.Validator
{
    public abstract class AbstractValidatorCustom<T> : AbstractValidator<T>
    {

        public override ValidationResult Validate(ValidationContext<T> context)
        {
            var validationResult = base.Validate(context);

            if (!validationResult.IsValid)
            {
                //RaiseValidationException(context, validationResult);
                throw new BadHttpRequestException(validationResult.Errors[0].ErrorMessage);
            }

            return validationResult;
        }
    }
}
