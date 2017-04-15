using Munazara.Application.DataService.Category.Reponse;
using System.Collections.Generic;

namespace Munazara.Application.DataService.Category
{
    public interface ICategoryService
    {
        List<GetCategoriesResponse> GetCategories();
    }
}