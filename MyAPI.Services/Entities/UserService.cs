using Rdcs.Attributes;
using MyAPI.DataAccess.Entities;
using System;
using MyAPI.DomainModel.Entities;
using Rdcs.Authorization;


namespace MyAPI.Services.Entities
{
    public class UserService : BaseService
    {
        [Autowired]
        private UserDataAccess userDataAccess;

        public User Register(string name, string username)
        {
            User user = new User { Name = name, Username = username };
            userDataAccess.Save(user);
            return user;
        }

        public AuthorizationToken Authenticate(string username)  
        {            
            User user = userDataAccess.GetByUsername(username);

            if(user == null)
            {
                throw new Exception("Usuário Inválido");
            }         

            if (string.IsNullOrEmpty(user.AccessKey))
            {
                return AuthorizationConfigurer.GenerateToken(user.Id);
            }
            else
            {
                return new AuthorizationToken("Falha ao autenticar");      
            }
        }
      
    }
}
