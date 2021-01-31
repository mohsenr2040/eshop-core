using eshop.Common.Dto;
using System.Text;

namespace eshop.Application.Services.Products.Commands.AddNewProduct
{
    public interface IAddNewProductService
    {
        ResultDto Execute(RequestAddNewProductDto request);
    }
}



