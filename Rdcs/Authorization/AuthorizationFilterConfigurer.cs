using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Rdcs.Constants;
using Rdcs.Attributes;

namespace Rdcs.Authorization
{
    public class AuthorizationFilterConfigurer : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {

            foreach(ActionModel action in controller.Actions)
            {
                if (action.Attributes.Any(x => x.GetType().Equals(typeof(RdcsAuthorizeAttribute))))
                {
                    action.Filters.Add(new AuthorizeFilter(Constant.PERMISSION_POLICY_NAME));
                }
            }
        }
    }
}
