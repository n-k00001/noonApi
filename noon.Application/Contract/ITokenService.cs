using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using noon.Domain.Models.Identity;

namespace noon.Application.Contract
{
    public interface ITokenService
    {
         Task<string> CreateToken(AppUser user, UserManager<AppUser> userManager);

    }
}