using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Rdcs.Core.Context;

namespace Rdcs.Core.Base
{
    public class BaseRepository
    {
        protected readonly ApplicationContext Context;
    }
}