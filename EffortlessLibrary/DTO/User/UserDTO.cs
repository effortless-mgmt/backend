using System.Collections.Generic;
using Newtonsoft.Json;

namespace EffortlessLibrary.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public long AddressId { get; set; }
        public AddressDTO Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        // public virtual IList<string> Privileges
        // {
        //     get 
        //     {
        //         if (UserRoles == null) return null;
        //         return UserRoles.Select(ur => ur.Role).SelectMany(r => r.PrivilegeNames).ToList();
        //     }
        // }
    }
}