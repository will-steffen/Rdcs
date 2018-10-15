using MyAPI.DataAccess.Entities;
using MyAPI.DomainModel;
using MyAPI.DomainModel.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAPI.DataAccess.Authorization
{
    public class PermissionDataAccess : BaseDataAccess<Permission>
    {
        public IEnumerable<Permission> GetByUserId(long userId)
        {
            return ((ApplicationContext)Context).LinkGroupUser.Where(lgu => lgu.User.Id == userId)
                .Select(lgu => lgu.Group.PermissionGroupList.Select(pgl => pgl.Permission))
                .SelectMany(l => l);
        }
    }
}
