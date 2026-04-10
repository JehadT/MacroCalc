using MacroCalc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Diagnostics;

namespace MacroCalc.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var errorModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? context.HttpContext.TraceIdentifier,
                Message = context.Exception.Message
            };

            context.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary<ErrorViewModel>(
                    new EmptyModelMetadataProvider(),
                    context.ModelState)
                {
                    Model = errorModel
                }
            };

            context.ExceptionHandled = true;
        }
    }
}
