using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FutureProject.Domain.Entities.DTOs
{
    public class UserDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Login { get; set; }
    }
}
