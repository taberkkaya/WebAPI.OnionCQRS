using WebAPI.Application.Bases;

namespace WebAPI.Application.Features.Auth.Exceptions
{
    public class EmailAddressShouldBeValidException : BaseException
    {
        public EmailAddressShouldBeValidException() : base("Email adresi bulunamadı.") { }
    }

}
