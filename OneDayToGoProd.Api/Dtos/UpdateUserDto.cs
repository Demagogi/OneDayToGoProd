﻿namespace OneDayToGoProd.Api.Dtos
{
    public class UpdateUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
