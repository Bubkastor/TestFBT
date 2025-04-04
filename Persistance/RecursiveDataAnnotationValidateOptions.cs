using Microsoft.Extensions.Options;
using RecursiveDataAnnotationsValidation;
using System.ComponentModel.DataAnnotations;

namespace Persistance
{
    public class RecursiveDataAnnotationValidateOptions<TOptions>(string name, string? rootPath = null) : IValidateOptions<TOptions> where TOptions : class
    {
        private readonly RecursiveDataAnnotationValidator _validator = new();

        public string Name { get; } = name;

        public ValidateOptionsResult Validate(string? name, TOptions options)
        {
            if (name != Name) return ValidateOptionsResult.Skip;

            var results = new List<ValidationResult>();
            if (_validator.TryValidateObjectRecursive(options, results)) return ValidateOptionsResult.Success;

            var stringResults = results.Select(validationResult =>
                $"DataAnnotation validation failed for path (member): \"{(rootPath != null ? rootPath + ":" : "")}{string.Join(":", validationResult.MemberNames)}\" with the error: {validationResult.ErrorMessage}"
            ).ToList();

            return ValidateOptionsResult.Fail(stringResults);
        }
    }
}
