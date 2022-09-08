using FluentValidation;
using MediatR;

namespace Zestware.Application.Common.PipelineBehaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(v => v.Errors)
            .Where(e => e is not null)
            .ToList();

        if (failures.Any())
        {
            // TODO: Return Result<T> instead of throwing exception for performance
            throw new ValidationException(failures);
        }
        
        return next();
    }
}