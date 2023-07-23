using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

// Adapted from ScottBrady91.AspNetCore.Identity.BCryptPasswordHasher
// https://github.com/scottbrady91/ScottBrady91.AspNetCore.Identity.BCryptPasswordHasher

namespace noon.Application.Services.UserService
{
//   public class BCryptPasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : class
// {
//     public string HashPassword(TUser user, string password)
//     {
//         return BCrypt.Net.BCrypt.HashPassword(password);
//     }

//     public PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
//     {
//         if (BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword))
//         {
//             return PasswordVerificationResult.Success;
//         }
//         else
//         {
//             return PasswordVerificationResult.Failed;
//         }
//     }
// }
}