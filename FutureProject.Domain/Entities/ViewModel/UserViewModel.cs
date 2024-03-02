using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FutureProject.Domain.Entities.ViewModel
{
    public class UserViewModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }

        public string Role { get; set; }
       
    
    }
}
