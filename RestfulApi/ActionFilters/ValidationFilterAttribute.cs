using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Newtonsoft.Json;
namespace RestfulApi.Application.Attributes
{
    public class ValidationFilterAttribute : IActionFilter
    {


        public void OnActionExecuted(ActionExecutedContext context)
        {
            Log.Information("Validasyon işlemi başarılı bir şekilde tamamlandi.");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionArguments = context.ActionArguments.Values;
            var dto = actionArguments.FirstOrDefault(arg => arg.GetType().Name.EndsWith("Request"));

            // DTO'nun var olup olmadığını kontrol et
            if (dto == null)
            {
                context.Result = new BadRequestObjectResult("Invalid DTO");
                return;
            }

            var validatorType = typeof(IValidator<>).MakeGenericType(dto.GetType());
            var validator = context.HttpContext.RequestServices.GetService(validatorType) as IValidator;

            // Validatörün var olup olmadığını kontrol et
            if (validator == null)
            {
                context.Result = new BadRequestObjectResult("No validator found for the DTO");
                return;
            }

            var validationContext = new ValidationContext<object>(dto);
            var validationResult = validator.Validate(validationContext);

            // Validasyonun geçerli olup olmadığını kontrol et
            if (!validationResult.IsValid)
            {
                var errorMessage = new
                {
                    Errors = validationResult.Errors,
                    StatusCode = 422
                };
                context.Result = new UnprocessableEntityObjectResult(errorMessage);
            }
        }
    }
}
