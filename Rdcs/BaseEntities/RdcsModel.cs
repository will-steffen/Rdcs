using System.ComponentModel.DataAnnotations.Schema;

namespace Rdcs.BaseEntities
{
    public class RdcsModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }
    }
}
