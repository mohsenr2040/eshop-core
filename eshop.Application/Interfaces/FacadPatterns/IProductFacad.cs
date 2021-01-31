using eshop.Application.Services.Commands.AddNewCategory;
using eshop.Application.Services.Products.Commands.AddNewProduct;
using eshop.Application.Services.Products.Queries.GetAllCategories;
using eshop.Application.Services.Products.Queries.GetCategories;
using eshop.Application.Services.Products.Queries.GetProductDetailForAdmin;
using eshop.Application.Services.Products.Queries.GetProductDetailForSite;
using eshop.Application.Services.Products.Queries.GetProductForAdmin;
using eshop.Application.Services.Products.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        IAddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }
        IAddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
        IGetProductForAdminService GetProductForAdminService { get; }
        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
    }

}
