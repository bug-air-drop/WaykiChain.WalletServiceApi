using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WalletServiceApi.Models
{
    public class ErrorActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                BaseRsp<string> result = new BaseRsp<string>() { success = false, error = 1001 };

                foreach (var item in context.ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        result.msg += error.ErrorMessage + "|";
                    }
                }

                context.Result = new JsonResult(result);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
