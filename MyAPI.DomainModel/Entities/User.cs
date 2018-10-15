using MyAPI.DomainModel.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyAPI.DomainModel.Entities
{
    [Table("t_user")]
    public class User : BaseModel
    {
        [Column("txt_name")]
        public string Name { get; set; }

        [Column("txt_access_key")]
        public string AccessKey { get; set; }

        [Column("txt_username")]
        public string Username { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<LinkGroupUser> GroupUserList { get; set; }
    }
}
