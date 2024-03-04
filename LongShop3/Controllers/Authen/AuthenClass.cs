using LongShop3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace LongShop3.Controllers.Authen
{
    public class AuthenClass : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var httpContext = context.HttpContext;
            var userJson = httpContext.Session.GetString("user");
            var isAuthenticated = httpContext.Session.GetString("Authenticated");
            var url = httpContext.Request.Path;
            if (userJson != null)
            {
                var user = JsonSerializer.Deserialize<User>(userJson);
                if (isAuthenticated == "true")
                {
                    if(checkUrlAccess(user.Username, url))
                    {
                        return;
                    }else
                    {
                        context.Result = new RedirectResult("/accessdenied");
                        return;
                    }
                }
                else
                {

                }
            }
            else
            {
                context.Result = new RedirectResult("/login");
            }
        }

        public bool checkUrlAccess(string usename, string url)
        {
            SHOPLONG5Context ctx = new SHOPLONG5Context();
            var featurelist = (from ga in ctx.GroupAccounts
                               join g in ctx.Groups on ga.GroupId equals g.GroupId
                               join gf in ctx.GroupFeatures on g.GroupId equals gf.GroupId
                               join f in ctx.Features on gf.FeatureId equals f.FeatureId
                               where ga.Username == usename
                               select new Feature
                               {
                                   FeatureId = f.FeatureId,
                                   Url = f.Url
                               }).ToList();

            foreach (var feature in featurelist)
            {
                if (url.Equals(feature.Url))
                {
                    return true;
                }
            }

            return false;

        }
    }
}
