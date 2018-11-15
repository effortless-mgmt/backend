using Newtonsoft.Json;

namespace EffortlessApi.Core.Models 
{
    public class UserRole
    {
        [JsonIgnore]
        public long UserId { get; set; }
        [JsonIgnore]
        public long RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
