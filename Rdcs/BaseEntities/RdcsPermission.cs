using Rdcs.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rdcs.BaseEntities
{
    public class RdcsPermission : RdcsModel
    {
        [Column("num_type")]
        public int Type { get; set; }

        [Column("cd_level")]
        public PermissionLevel Level { get; set; }
        
    }
}
