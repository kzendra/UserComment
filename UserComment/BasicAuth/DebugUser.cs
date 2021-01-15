using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserComment.BasicAuth
{
    public class DebugUser
    {
        public DebugUser()
        {
            Id = new Guid("551ACEBF-DE35-4F73-9B4B-D85EDFD1D408");
            TenantId = new Guid("E93A3351-9E41-44AA-B2AD-15A83327D6BE");
            DisplayName = "Api User";
            Email = "netosapi@gmail.com";
            UserName = "ApiUser";
            FirstName = "Api";
            LastName = "User";
            Password = "apipassword";
            Culture = "sl-SI";
        }

        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Culture { get; set; }
    }
}
