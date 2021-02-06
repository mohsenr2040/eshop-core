using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Common.Dto
{
    //Result Dto 
    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class ResultDto<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public T Data { get; set; }
    }
}
