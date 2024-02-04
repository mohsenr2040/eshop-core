using eshop.Application.Interfaces.Contexts;
using eshop.Application.Services.Products.Commands.AddNewProduct;
using eshop.Common.Dto;
using eshop.Domain.Entities.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace eshop.Infrastructure.Services.Products.Commands
{
    public class AddNewProductService : IAddNewProductService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddNewProductService(IDataBaseContext context,IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public ResultDto Execute(RequestAddNewProductDto request)
        {
            try
            {
                Product Product1 = new Product()
                {
                    Brand = request.Brand,
                    CategoryId = request.CategoryId,
                    Description = request.Description,
                    Displayed = request.Displayed,
                    Inventory = request.Inventory,
                    Name = request.Name,
                    Price = request.Price,
                };

                _context.Products.Add(Product1);

                List<ProductImages> Lst_Images = new List<ProductImages>();
                foreach (var item in request.Images)
                {
                    var uploadedResult = UploadFile(item);
                    Lst_Images.Add(new ProductImages()
                    {
                        Product = Product1,
                        Src = uploadedResult.FileNameAddress
                    }
                    );
                }

                _context.ProductImages.AddRange(Lst_Images);

                List<ProductFeatures> Lst_Features = new List<ProductFeatures>();
                foreach (var item in request.Features)
                {
                    Lst_Features.Add(new ProductFeatures
                    {
                        DisplayName = item.DisplayName,
                        Value = item.Value,
                        Product = Product1,
                    });
                }

                _context.ProductFeatures.AddRange(Lst_Features);
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت به محصولات فروشگاه اضافه شد",
                };
            }
            catch (Exception ex)
            {

                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا رخ داد ",
                };
            }


        }

        public UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string Folder = $@"images\ProductImages\";
                var UploadRootFolder = Path.Combine(_environment.WebRootPath, Folder);
                if(!Directory.Exists(UploadRootFolder))
                {
                    Directory.CreateDirectory(UploadRootFolder);
                }

                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = ""
                    };
                }
                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(UploadRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = Folder + fileName,
                    Status = true,
                };
            }
            return null;
        }

        public class UploadDto
        {
            public long Id { get; set; }
            public bool Status { get; set; }
            public string FileNameAddress { get; set; }

        }


    }
}



