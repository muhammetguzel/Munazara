using Munazara.Application.DataService.Member.Request;
using Munazara.Application.DataService.Member.Response;

namespace Munazara.Application.DataService.Member
{
    public interface IMemberService
    {
        LoginResponse Login(LoginRequest request);

        LoginResponse Register(RegisterRequest request);

        bool IsUserNameUsed(string userName);
    }
}