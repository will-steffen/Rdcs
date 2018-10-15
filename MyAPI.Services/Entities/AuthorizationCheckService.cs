using MyAPI.DataAccess.Entities;
using MyAPI.DomainModel.Entities;
using Rdcs.Attributes;
using Rdcs.Authorization;
using Rdcs.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAPI.Services.Entities
{
    public class AuthorizationCheckService : RdcsAuthorizationCheckService
    {
        [Autowired]
        private UserDataAccess userDataAccess;

        public override bool HasPermission(long userId, RdcsPermission requiredPermission)
        {
            User user = userDataAccess.GetById(userId);
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}
