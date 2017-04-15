using Munazara.Application.DataService.Category.Reponse;
using Munazara.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Munazara.Application.DataService.Category
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork uow;

        public CategoryService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public List<GetCategoriesResponse> GetCategories()
        {
            return uow.Repository<Domain.Model.Category>().All().Select(x => new GetCategoriesResponse { Id = x.Id, Name = x.Name }).ToList();
        }
    }
}