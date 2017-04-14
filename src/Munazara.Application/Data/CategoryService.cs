using Munazara.Application.Data.Reponses;
using Munazara.Data.Repository;
using Munazara.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munazara.Application.Data
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
            return uow.Repository<Category>().All().Select(x => new GetCategoriesResponse { Id = x.Id, Name = x.Name }).ToList();

        }
    }
}
