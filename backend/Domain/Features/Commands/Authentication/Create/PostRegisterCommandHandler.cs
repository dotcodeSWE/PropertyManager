using Domain.Domain.Authentication;
using Domain.Features.Commands.Authentication.Create;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Domain.Features.Commands.Area;

public class PostRegisterCommandHandler : IRequestHandler<PostRegisterCommand, IdentityResult>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public PostRegisterCommandHandler(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task<IdentityResult> Handle(PostRegisterCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByNameAsync(request.Username);
        if (userExists != null)
        {
            return null;
        }

        IdentityUser user = new()
        {
            Email = request.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = request.Username
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded || result == null)
        {
            return result;
        }
        else
        {
           return await AddRole(request.Role, user);
        }
    }

    private async Task<IdentityResult> AddRole(string role, IdentityUser user)
    {
        if (await _roleManager.RoleExistsAsync(role))
        {
            return await _userManager.AddToRoleAsync(user, role);
        }
        else
        {
            return null;
        }
    }
}