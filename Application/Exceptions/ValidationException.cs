using FluentValidation.Results; 

namespace Application.Exceptions
{
    public class ValidationException(ValidationResult validationResult) : Exception("One or more validation errors occurred.")
    {
        public List<string> ValidationErrors { get; set; } = [.. validationResult.Errors.Select(e => e.ErrorMessage)];
    }
}
