using System.Collections.Generic;
using Munazara.Application.Data.Reponses;

namespace Munazara.Application.Data
{
    public interface ICategoryService
    {
        List<GetCategoriesResponse> GetCategories();
    }
}