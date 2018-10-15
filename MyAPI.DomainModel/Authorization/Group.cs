using MyAPI.DomainModel.Entities;
using Rdcs.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyAPI.DomainModel.Authorization
{
    [Table("t_permission_group")]
    public class Group : BaseModel
    {
        [Column("txt_name")]
        public string Name { get; set; }
    }
}
