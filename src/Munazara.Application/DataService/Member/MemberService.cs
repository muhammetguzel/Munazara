using Munazara.Application.DataService.Member.Request;
using Munazara.Application.DataService.Member.Response;
using Munazara.Data.Repository;
using System.Linq;

namespace Munazara.Application.DataService.Member
{
    public class MemberService : IMemberService
    {
        private IUnitOfWork uow;

        public MemberService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public bool IsUserNameUsed(string userName)
        {
            string[] reservedNAmes = new string[] { "admin", "administration", "administrator" };
            if (reservedNAmes.Contains(userName.ToLower()))
            {
                return true;
            }
            return uow.Repository<Domain.Model.Member>().All().Any(x => x.UserName == userName);
        }

        public LoginResponse Login(LoginRequest request)
        {
            var member = uow.Repository<Domain.Model.Member>().GetActiveMembers().Where(x => x.UserName.ToLower() == request.UserName.ToLower() && x.Password == request.Password).FirstOrDefault();
            if (member == null)
            {
                return null;
            }
            else
            {
                return new LoginResponse
                {
                    Avatar = member.Avatar,
                    Id = member.Id,
                    UserName = member.UserName
                };
            }
        }

        public LoginResponse Register(RegisterRequest request)
        {
            var member = uow.Repository<Domain.Model.Member>().GetBy(x => x.UserName == request.UserName.ToLower() || x.Email.ToLower() == request.Email.ToLower()).FirstOrDefault();
            if (member == null)
            {
                var newMember = new Domain.Model.Member
                {
                    Avatar = "",
                    Email = request.Email,
                    Password = request.Password,
                    IsActive = true,
                    UserName = request.UserName
                };
                uow.Repository<Domain.Model.Member>().Add(newMember);
                uow.SaveChanges();
                return new LoginResponse
                {
                    Avatar = newMember.Avatar,
                    Id = newMember.Id,
                    UserName = newMember.UserName
                };
            }
            else
            {
                return null;
            }
        }
    }
}