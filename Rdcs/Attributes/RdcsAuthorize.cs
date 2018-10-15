using Microsoft.AspNetCore.Authorization;
using Rdcs.Authorization;
using Rdcs.BaseEntities;
using System;

namespace Rdcs.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RdcsAuthorizeAttribute : AuthorizeAttribute
    {
        public RdcsPermission Permission { get; set; }

        public RdcsAuthorizeAttribute(int type, PermissionLevel level = PermissionLevel.Read)
        {
            Permission = new RdcsPermission { Type = type, Level = level };
            Policy = RdcsAuthorizationPolicyProvider.GetPolicyName(Permission);
        }

    }
}