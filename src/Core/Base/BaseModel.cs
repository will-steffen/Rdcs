using System.ComponentModel.DataAnnotations.Schema;

namespace Rdcs.Core.Base
{
    public class BaseModel
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
