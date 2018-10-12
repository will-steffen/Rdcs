using System.ComponentModel.DataAnnotations.Schema;

namespace Rdcs.Core.Base
{
    public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }
    }
}
