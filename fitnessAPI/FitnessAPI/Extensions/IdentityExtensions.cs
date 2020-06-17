using System.Security.Claims;
using System.Security.Principal;

namespace FitnessAPI.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetLanguage(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Language");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}