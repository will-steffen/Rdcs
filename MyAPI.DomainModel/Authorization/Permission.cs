using Rdcs.Authorization;
using Rdcs.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyAPI.DomainModel.Authorization
{
    [Table("t_permission")]
    public class Permission : RdcsPermission
    {
        public Permission() { }

        public Permission(int type, PermissionLevel level)
        {
            Type = type;
            Level = level;
        }
    }
}
