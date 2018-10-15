using MyAPI.DataAccess.Entities;
using MyAPI.DomainModel.Authorization;
using MyAPI.DomainModel.Entities;
using Rdcs.Attributes;
using Rdcs.Authorization;
using Rdcs.BaseEntities;
using Rdcs.Utils;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MyAPI.DataAccess.Authorization;

namespace MyAPI.Services.Entities
{
    public class AuthorizationCheckService : RdcsAuthorizationCheckService
    {
        //[Autowired]
        //private UserDataAccess userDataAccess;

        [Autowired]
        private PermissionDataAccess permissionDataAccess;

        public override bool HasPermission(long userId, RdcsPermission requiredPermission)
        {
            //User user = userDataAccess.GetById(userId);
            List<Permission> permissionList = permissionDataAccess.GetByUserId(userId).ToList();
            return permissionList.Any(p =>
                p.Type == requiredPermission.Type &&
                (int)p.Level >= (int)requiredPermission.Level);
        }

        public override void UpdatePermissionsSchema()
        {
            List<int> typeList = EnumHelper.AsListInt<PermissionType>();
            List<int> levelList = EnumHelper.AsListInt<PermissionLevel>();
            List<Permission> permissionList = permissionDataAccess.List().ToList();
            List<Permission> permissionListToAdd = new List<Permission>();

            typeList.ForEach(type =>
            {
                levelList.ForEach(level =>
                {
                    if(!permissionList.Any(x => x.Level == (PermissionLevel)level && x.Type == type))
                    {
                        permissionListToAdd.Add(new Permission(type, (PermissionLevel)level));
                    }
                });
            });
            permissionDataAccess.Save(permissionListToAdd);
        }
    }
}
