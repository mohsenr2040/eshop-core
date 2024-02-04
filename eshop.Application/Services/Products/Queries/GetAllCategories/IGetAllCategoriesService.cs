
using eshop.Common.Dto;
using System.Collections.Generic;

namespace eshop.Application.Services.Products.Queries.GetAllCategories
{
    public interface IGetAllCategoriesService
    {
        ResultDto<List<AllCategoryDto>> Execute();
    }

   

    public class AllCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
