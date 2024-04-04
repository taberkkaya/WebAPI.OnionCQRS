using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Bases;
using WebAPI.Application.Features.Auth.Rules;
using WebAPI.Application.Interfaces.AutoMapper;
using WebAPI.Application.Interfaces.Tokens;
using WebAPI.Application.UnitOfWorks;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;
        private readonly ITokenService tokenService;
        private readonly IConfiguration configuration;

        public LoginCommandHandler(UserManager<User> userManager, AuthRules authRules, ITokenService tokenService, IConfiguration configuration,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.authRules = authRules;
            this.tokenService = tokenService;
            this.configuration = configuration;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(request.Email);
            bool checkPassword = await userManager.CheckPasswordAsync(user, request.Password);

            await authRules.EmailOrPasswordShoulNotBeInvalid(user, checkPassword);

            IList<string> roles = await userManager.GetRolesAsync(user);

            JwtSecurityToken token = await tokenService.CreateToken(user,roles);

            string refreshToken = tokenService.GenerateRefreshToken();

            _ = int.TryParse(configuration["JWT:RefrehTokenValidityInDays"], out int refrehTokenValidityInDays);

            user.RefreshToken = refreshToken;

            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refrehTokenValidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            string _token = new JwtSecurityTokenHandler().WriteToken(token);

            await userManager.SetAuthenticationTokenAsync(user, "Default","AccessToken", _token);

            return new()
            {
                Token = _token,
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };

        }
    }
}
