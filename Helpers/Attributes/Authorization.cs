using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProiectV1.Models;
using ProiectV1.Models.Enums;

namespace ProiectV1.Helpers.Attributes
{
    public class Authorization : Attribute, IAuthorizationFilter
    {
        //roluri acceptate
        private readonly ICollection<Role> roles;

        public Authorization(params Role[] roles)
        {
            this.roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizedStatusObject = new JsonResult(new { Messaje = "Unauthorized" }){ StatusCode = StatusCodes.Status401Unauthorized};
            //daca nu avem roluri dam eroarea de sus
            if (roles == null)
            {
                context.Result = unauthorizedStatusObject;

            }
            //daca nu gasim userul sau userul gasit nu are rol valid dam din nou eroarea
            var user = (User)context.HttpContext.Items["User"];
            if (user == null || !roles.Contains(user.Role))
                {
                context.Result = unauthorizedStatusObject;
            }
        }
    }
}
