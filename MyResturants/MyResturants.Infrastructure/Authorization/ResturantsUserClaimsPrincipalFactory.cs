using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MyResturants.Domain.Entities;
using System.Security.Claims;

namespace MyResturants.Infrastructure.Authorization;

public class ResturantsUserClaimsPrincipalFactory(UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager,
    IOptions<IdentityOptions> options)
    : UserClaimsPrincipalFactory<User, IdentityRole>(userManager, roleManager, options)
{
    public async override Task<ClaimsPrincipal> CreateAsync(User user)
    {
        var id = await GenerateClaimsAsync(user);

        if (user.Nationality is not null)
            id.AddClaim(new Claim(AppClaimTypes.Nationality, user.Nationality));

        if (user.DateOfBirth is not null)
            id.AddClaim(new Claim(AppClaimTypes.DateOfBirth, user.DateOfBirth.Value.ToString("yyyy-MM-dd")));

        return new ClaimsPrincipal(id);
    }
}