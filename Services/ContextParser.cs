using System.Security.Claims;

namespace QuesFight.Services
{
    public class ContextParser
    {
        public static string? GetEmail(HttpContext httpContext)
        {
            foreach (Claim claim in httpContext.User.Claims)
                if (claim.Type == ClaimTypes.NameIdentifier)
                    return claim.Value;
            return null;
        }
    }
}
