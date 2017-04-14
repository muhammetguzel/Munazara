using Munazara.Domain.Model;
using Munazara.Infrastructure.Data.Repository;

using System.Linq;

namespace Munazara.Infrastructure.Data.Repository
{
    public static class MemberRepositoryExtensions
    {
        public static IQueryable<Member> GetActiveMembers(this IGenericRepository<Member> repository)
        {
            return repository.GetBy(x => x.IsActive == true);
        }
    }
}