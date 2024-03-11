
using FluentValidation.Results;

namespace TicketManagement.Application.Exceptions
{
    public class ValidationException: Exception
    {
        public List<string> ValidationErrors { get; set; }

        public ValidationException(ValidationResult validationResult) 
        {
            ValidationErrors = new List<string>();

            foreach (var validateionError in validationResult.Errors)
            {
                ValidationErrors.Add(validateionError.ErrorMessage);
            }
        }
    }
}
