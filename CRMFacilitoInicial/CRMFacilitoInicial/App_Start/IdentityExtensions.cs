using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace App.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetNombreCompleto(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("NombreCompleto");
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}