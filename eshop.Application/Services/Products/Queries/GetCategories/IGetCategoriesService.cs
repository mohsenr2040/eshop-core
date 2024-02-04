
using System.Collections.Generic;
using eshop.Common.Dto;

namespace eshop.Application.Services.Products.Queries.GetCategories
{
    public interface IGetCategoriesService
    {
        ResultDto<List<CategoriesDto>> Execute(int? ParentId);
    }



    public class CategoriesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public ParentCategoryDto Parent { get; set; }
    }

    public class ParentCategoryDto
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}
