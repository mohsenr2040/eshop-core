using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using eshop.Domain.Entities.HomePages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eshop.Application.Services.HomePages.AddNewSlider
{
    public interface IAddNewSliderService
    {
        ResultDto Execute(IFormFile file,string link);
    }
    public class AddNewSliderService : IAddNewSliderService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddNewSliderService(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public ResultDto Execute(IFormFile file,string link)
        {
            if (file == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "ابتدا تصویر را انتخاب کنید",
                };
            }
            var ResultUpload = UploadFile(file);

            Slider Slider1 = new Slider()
            {
                Src = ResultUpload.FileNameAddress,
                Link = link,
            };
            _context.Sliders.Add(Slider1);
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = ""
            };
        }

        public UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string Folder = $@"images\HomePages\Slider\";
                var UploadRootFolder = Path.Combine(_environment.WebRootPath, Folder);
                if (!Directory.Exists(UploadRootFolder))
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
