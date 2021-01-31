using eshop.Application.Interfaces.Contexts;
using eshop.Application.Interfaces.FacadPatterns;
using eshop.Application.Services.Commands.AddNewCategory;
using eshop.Application.Services.Products.Commands.AddNewProduct;
using eshop.Application.Services.Products.Queries.GetAllCategories;
using eshop.Application.Services.Products.Queries.GetCategories;
using eshop.Application.Services.Products.Queries.GetProductDetailForAdmin;
using eshop.Application.Services.Products.Queries.GetProductDetailForSite;
using eshop.Application.Services.Products.Queries.GetProductForAdmin;
using eshop.Application.Services.Products.Queries.GetProductForSite;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Application.Services.Products.FacadPattern
{
    public class ProductFacad: IProductFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public  ProductFacad(IDataBaseContext context,IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private IAddNewCategoryService _addNewCategory;
        public IAddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
            }
        }

        private IGetCategoriesService _getCategoriesService;
        public IGetCategoriesService GetCategoriesService
        {
            get
            {
                return _getCategoriesService = _getCategoriesService ?? new GetCategoriesService(_context);
            }
        }

        private IAddNewProductService _addNewProductService;
        public IAddNewProductService AddNewProductService
        {
            get
            {
                return _addNewProductService = _addNewProductService ?? new AddNewProductService(_context, _environment);
            }
        }

        private IGetAllCategoriesService _getAllCategoriesService;

        public IGetAllCategoriesService GetAllCategoriesService
        {
            get 
            {
                return _getAllCategoriesService = _getAllCategoriesService ?? new GetAllCategoriesService(_context);
            }
        }

        private IGetProductForAdminService _getProductForAdminService;
        public IGetProductForAdminService GetProductForAdminService
        {
            get
            {
                return _getProductForAdminService = _getProductForAdminService ?? new GetProductForAdminService(_context);
            }
        }

        private IGetProductDetailForAdminService _getProductDetailForAdminService;
        public IGetProductDetailForAdminService GetProductDetailForAdminService
        {
            get 
            {
                return _getProductDetailForAdminService = _getProductDetailForAdminService ?? new GetProductDetailForAdminService(_context);
            }
        }


        private IGetProductForSiteService _getProductForSiteService;
        public IGetProductForSiteService GetProductForSiteService
        {
            get
            {
                return _getProductForSiteService = _getProductForSiteService ?? new GetProductForSiteService(_context);
            }
        }

        private IGetProductDetailForSiteService _getProductDetailForSiteService;
        public IGetProductDetailForSiteService GetProductDetailForSiteService
        {
            get
            {
                return _getProductDetailForSiteService = _getProductDetailForSiteService ?? new GetProductDetailForSiteService(_context);
            }
        }

    }
}
