using FluentValidation.Results;


namespace Application.Exceptions;

public class ValidationServiceException : Exception
    {
        public  ValidationServiceException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationServiceException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            var failureGroups = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage);

            foreach (var failureGroup in failureGroups)
            {
                var propertyName = failureGroup.Key;
                var propertyFailures = failureGroup.ToArray();

                Errors.Add(propertyName, propertyFailures);
                ErrorMessages.AddRange(propertyFailures);
            }
        }

        public IDictionary<string, string[]> Errors { get; }

        public List<string> ErrorMessages {get; private set;}=new();
    }
