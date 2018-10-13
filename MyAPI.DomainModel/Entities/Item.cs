using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAPI.DomainModel.Entities
{
    [Table("t_item")]
    public class Item : BaseModel
    {
        [Column("txt_name")]
        public string Name { get; set; }

        [Column("fl_complete")]
        public bool IsComplete { get; set; } = false;
    }
}
