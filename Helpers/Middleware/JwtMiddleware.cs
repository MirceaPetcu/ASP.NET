using ProiectV1.Helpers.JwtUtils;
using ProiectV1.Services.UserServices;

namespace ProiectV1.Helpers.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegate;

        public JwtMiddleware(RequestDelegate nextRequestDelegate)
        {
            _nextRequestDelegate = nextRequestDelegate;
        }

        public async Task Invoke(HttpContext httpContext, IUserService userService, IJwtUtils jwtUtils)
        {
            //extragem tokenul, practic din frontend
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();
            //validam tokenul, daca merge
            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != Guid.Empty)
            {
                //daca a fost validat gasim userul
                httpContext.Items["User"] = userService.GetById(userId);
            }
            await _nextRequestDelegate(httpContext);
        }
    }
}
