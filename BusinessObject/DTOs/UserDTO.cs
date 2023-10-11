using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class UserDTO
    {
        public string UserId { get; set; } = null!;
        public string RoleId { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public string? UserName { get; set; }
        public string? WardId { get; set; }

        public string? DistrictId { get; set; }
        public string? Pass { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? UserAddress { get; set; }
        public string Email { get; set; } = null!;
        public bool? UserStatus { get; set; }
    }
}
