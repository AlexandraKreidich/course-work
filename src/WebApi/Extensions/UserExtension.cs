using System;
using System.Security.Claims;
using JetBrains.Annotations;

namespace WebApi.Extensions
{
    public static class UserExtension
    {
        public static int GetUserId([NotNull] this ClaimsPrincipal user)
        {
            Claim userClaim = user.FindFirst(ClaimTypes.NameIdentifier);

            if (userClaim == null)
            {
                throw new ArgumentException("Claim principal doesn't contain name identifier");
            }

            if (!int.TryParse(userClaim.Value, out int userId))
            {
                throw new ArgumentException("Invalid user identifier");
            }

            return userId;
        }
    }
}
