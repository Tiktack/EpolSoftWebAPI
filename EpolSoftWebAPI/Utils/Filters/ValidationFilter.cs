using System.Linq;
using System.Threading.Tasks;
using EpolSoft.WebAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EpolSoft.WebAPI.Utils.Filters
{
    internal class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var response = new Response
                {
                    ErrorMessage = "Validation error",
                    Success = false,
                    ValidationMessages = context.ModelState.ToDictionary(x => x.Key,
                        x => x.Value.Errors.Select(error => error.ErrorMessage))
                };
                context.Result = new BadRequestObjectResult(response);
                return;
            }
            await next();
        }
    }
}
