using MyAPI.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyAPI.DomainModel.Authorization
{
    [Table("t_link_group_user")]
    public class LinkGroupUser : BaseModel
    {
        [Column("id_permission_group")]
        public long IdPermissionGroup { get; set; }

        [Column("id_user")]
        public long IdUser { get; set; }

        [ForeignKey("IdPermissionGroup")]
        public Group Group { get; set; }

        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}
