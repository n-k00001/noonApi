using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using noon.Domain.Models.Identity;

namespace noon.Application.Services.UserService
{
    public class TokenService
    {
        //  private readonly IConfiguration configuration;

        // public TokenService(IConfiguration configuration)
        // {
        //     this.configuration = configuration;
        // }
        // public async Task<string> CreateToken(AppUser user, UserManager<AppUser> userManager)
        // {
        //     var authClaims = new List<Claim>()
        //     {
        //         new Claim(ClaimTypes.Email, user.Email),
        //         new Claim(ClaimTypes.GivenName, user.DisplayName),
        //     }; // Private Claims (UserDefined)

        //     var userRoles = await userManager.GetRolesAsync(user);

        //     foreach (var role in userRoles)
        //         authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));


        //     var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));

        //     var token = new JwtSecurityToken(

        //         issuer: configuration["JWT:ValidIssuer"],
        //         audience: configuration["JWT:ValidAudience"],
        //         expires: DateTime.Now.AddDays(double.Parse(configuration["JWT:DurationInDays"])),
        //         claims: authClaims,
        //         signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
        //         );

        //     return new JwtSecurityTokenHandler().WriteToken(token);
      //  }
    }
}