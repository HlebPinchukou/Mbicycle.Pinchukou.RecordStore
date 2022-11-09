using ValidationResult = FluentValidation.Results.ValidationResult;

namespace RecordStore.BusinessLogic.Extensions;

public static class ValidationResultExtension
{
    public static IEnumerable<string> GetErrorMessages(this ValidationResult validationResult)
    {
        return validationResult.Errors
            .Select(x => x.ErrorMessage)
            .ToList();
    }
}