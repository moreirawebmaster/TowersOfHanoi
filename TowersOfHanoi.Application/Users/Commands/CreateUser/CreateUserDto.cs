using System;
using System.Collections.Generic;
using System.Text;

namespace TowersOfHanoi.Application.Users.Commands
{
    public class CreateUserRequestDto
    {
        public string Name { get; set; }
    }

    public class CreateUserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
