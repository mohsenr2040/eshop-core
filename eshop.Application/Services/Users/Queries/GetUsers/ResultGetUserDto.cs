using System.Collections.Generic;

namespace eshop.Application.Services.Queries.GetUsers
{
    public class ResultGetUserDto
    {
        public List<GetUserDto> Users { get; set; }
        public int Rows { get; set; }
    }
}
