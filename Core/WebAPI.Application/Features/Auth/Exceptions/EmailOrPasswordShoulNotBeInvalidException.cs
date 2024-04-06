using WebAPI.Application.Bases;

namespace WebAPI.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShoulNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShoulNotBeInvalidException() : base("Oturum süresi sona ermiştir. Lütfen tekrar giriş yapın.") { }
    }

}
