using Eticaret.Entities;
using System.Collections.Generic;

namespace Eticaret.Business.Services
{
    public interface ICategoryService
    {
        List<Category> List();
        Category GetCategory(string seoName);
    }
}
