using System.ComponentModel.DataAnnotations;

namespace SubBee.Api.Models.Dtos
{
    public class ChangePasswordDto
    {
        public required string Username { get; set; }

        public required string CurrentPassword { get; set; }

        public required string NewPassword { get; set; }

        [Compare("NewPassword")]
        public required string ConfirmPassword { get; set; }
    }
}
