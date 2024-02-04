
using eshop.Common.Dto;

namespace eshop.Application.Services.Commands.AddNewCategory
{
    public interface IAddNewCategoryService
    {
        ResultDto Execute(int? ParentId, string Name);
    }
 
}
