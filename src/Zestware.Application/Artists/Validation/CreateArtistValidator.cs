using FluentValidation;
using Zestware.Application.Artists.Commands;

namespace Zestware.Application.Artists.Validation;

public class CreateArtistValidator : AbstractValidator<CreateArtist.Command>
{
    public CreateArtistValidator()
    {
        RuleFor(cmd => cmd.Name)
            .NotEmpty();
            //.WithMessage("An Artist name cannot be empty");
        
        RuleFor(cmd => cmd.Name)
            .MaximumLength(20);

        RuleFor(cmd => cmd.FormedDate)
            .Must(FormedIsValidDate)
            .WithMessage("formedDate is an invalid date format");
    }

    private static bool FormedIsValidDate(string formedDate)
    {
        if (DateOnly.TryParse(formedDate, out _))
        {
            return true;
        }
        return false;
    }
}