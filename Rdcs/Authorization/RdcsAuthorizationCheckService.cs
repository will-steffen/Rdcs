using Rdcs.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rdcs.Authorization
{
    public class RdcsAuthorizationCheckService : RdcsService
    {
        public virtual bool HasPermission(long userId, RdcsPermission requiredPermission)
        {
            return false;
        }
    }
}
