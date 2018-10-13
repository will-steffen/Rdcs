using MyAPI.DomainModel.Entities;
using Rdcs.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAPI.DataAccess.Entities
{
    public class BaseDataAccess<T> : RdcsDataAccess<T> where T : BaseModel
    {
    }
}
