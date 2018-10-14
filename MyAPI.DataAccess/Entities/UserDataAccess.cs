using MyAPI.DomainModel;
using MyAPI.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAPI.DataAccess.Entities
{
    public class UserDataAccess : BaseDataAccess<User>
    {
        public User GetByUsername(string username)
        {
            return ((ApplicationContext)Context).User
                .Where(x => x.Username.Equals(username))
                .FirstOrDefault();
        }
    }
}
