using System.Collections.Generic;
using Demo.Roles.Dto;
using Demo.Users.Dto;

namespace Demo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}