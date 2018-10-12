using Rdcs.Core.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rdcs.Models
{
    [Table("t_todo_item")]
    public class TodoItem : BaseModel
    {
        
        [Column("txt_name")]
        public string Name { get; set; }

        [Column("fl_complete")]
        public bool IsComplete { get; set; } = false;

    }
}
