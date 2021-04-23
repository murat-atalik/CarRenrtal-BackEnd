using FluentValidation.Results;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Extensions
{
    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}