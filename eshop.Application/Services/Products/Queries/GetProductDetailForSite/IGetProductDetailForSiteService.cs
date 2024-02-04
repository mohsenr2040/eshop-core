
using eshop.Common.Dto;
using System.Collections.Generic;

namespace eshop.Application.Services.Products.Queries.GetProductDetailForSite
{
    public interface IGetProductDetailForSiteService
    {
        ResultDto<ProductDetailForeSiteDto> Execute(int Id);
        ResultDto<ProductDetailForeSiteDto> Execute(int ProductId,int? SellerId);
    }

   
    public class ProductDetailForeSiteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int? SellerId { get; set; }
        public string SellerName { get; set; }
        public int SellerPrice { get; set; }
        public string UserName { get; set; }
        public string Category { get; set; }
        public List<string> ImagesSrc { get; set; }
        public List<ProductDetailForeSite_FeaturesDto> Features { get; set; }
        public List<ProdustSellersDto> ProdustSellers { get; set; }
    }

    public class ProductDetailForeSite_FeaturesDto
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
    public class ProdustSellersDto
    {
        public int SellerId { get; set; }
        public int ProductId { get; set; }
        public string SellerName { get; set; }
        public int SellerPrice { get; set; }
        public string UserName { get; set; }
    }
}

