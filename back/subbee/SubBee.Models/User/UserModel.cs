using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubBee.Models.Authentication
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;

        public string Firstname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string GcashNumber { get; set; } = string.Empty;

        public bool IsVerified { get; set; }

        public string Otp { get; set; } = string.Empty;

        public DateTime OtpDateCreated { get; set; }

        public DateTime OtpDateValidated { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
