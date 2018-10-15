using MyAPI.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyAPI.DomainModel.Authorization
{
    [Table("t_link_perm_group")]
    public class LinkPermissionGroup : BaseModel
    {
        [Column("id_permission_group")]
        public long IdPermissionGroup { get; set; }

        [Column("id_permission")]
        public long IdPermission { get; set; }

        [ForeignKey("IdPermissionGroup")]
        public Group Group { get; set; }

        [ForeignKey("IdPermissionGroup")]
        public Permission Permission { get; set; }
    }
}
