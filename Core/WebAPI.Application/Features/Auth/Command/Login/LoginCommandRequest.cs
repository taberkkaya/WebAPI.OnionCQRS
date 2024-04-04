using MediatR;
using System.ComponentModel;

namespace WebAPI.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        [DefaultValue("taberkkaya@gmail.com")]
        public string Email { get; set; }

        [DefaultValue("1234567")]
        public string Password { get; set; }
    }
}
