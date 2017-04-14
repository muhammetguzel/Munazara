using Munazara.Domain.Model;
using System.Linq;

namespace Munazara.Data.Repository
{
    public static class MemberRepositoryExtensions
    {
        public static IQueryable<Member> GetActiveMembers(this IGenericRepository<Member> repository)
        {
            return repository.GetBy(x => x.IsActive == true);
        }
    }
}