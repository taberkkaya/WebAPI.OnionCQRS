using WebAPI.Application.Bases;

namespace WebAPI.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShoulNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShoulNotBeInvalidException() : base("Kullanıcı adı veya şifre hatalı.") { }
    }

}
