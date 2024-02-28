using LongShop3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace LongShop3.Controllers.Authen
{
    public class AuthenClass : Attribute, IAuthorizationFilter
    {
        public string url { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var httpContext = context.HttpContext;
            if (httpContext.Session != null)
            {
                var userJson = httpContext.Session.GetString("user");
                // authentication
                if (userJson != null)
                {
                    try
                    {
                        var user = JsonSerializer.Deserialize<User>(userJson);
                        // authorization


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }else
                {
                    context.Result = new RedirectResult("/login");
                }
            }
        }
    }
}
