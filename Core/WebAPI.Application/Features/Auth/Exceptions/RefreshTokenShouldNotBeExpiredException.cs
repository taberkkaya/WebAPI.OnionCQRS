using WebAPI.Application.Bases;

namespace WebAPI.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseException
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Kullanıcı adı veya şifre hatalı.") { }
    }

}
