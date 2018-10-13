using MyAPI.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAPI.Services.Entities
{
    public class ItemService : BaseService
    {
        public Item Create(string name)
        {
            return new Item { Name = name };
        }
    }
}
