using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Services.PasswordHasher
{
    public class PasswordHash : IPasswordHash
    {
        public string HashPassword(string password)
            => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool VerifyPassword(string hash, string password)
            => BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
    }
}
