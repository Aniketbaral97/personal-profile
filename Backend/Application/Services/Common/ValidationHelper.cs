using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Exceptions;
using FluentValidation.Results;

namespace Application.Services.Common;

public class ValidationHelper
{
    public static void Validate(ValidationResult validatorResult)
        {
            if (!validatorResult.IsValid)
            {
                var failures = validatorResult.Errors.Where(f => f != null).ToList();
                var data = System.Text.Json.JsonSerializer.Serialize(failures);
                System.Console.WriteLine("failure:" + data);
                throw new ValidationException(failures);
            }
            foreach (var failure in validatorResult.Errors)
            {
                System.Console.WriteLine("Test:", $"Property: {failure.PropertyName} Error Code: {failure.ErrorCode}");
            }

        }
}
