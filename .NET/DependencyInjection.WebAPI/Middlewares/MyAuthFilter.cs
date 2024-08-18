using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DependencyInjection.WebAPI.Middlewares;

public class MyAuthFilter : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var response = context.HttpContext.Request.Headers.FirstOrDefault(p => p.Key == "Authorization").Value;

        if (string.IsNullOrEmpty(response))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}


public class MyAtt : Attribute
{
    public MyAtt()
    {

    }
}