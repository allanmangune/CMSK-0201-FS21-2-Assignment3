using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF3Data.Application.Dtos
{
    public class UserPostGroupDto
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int PostCount { get; set; }
        public List<PostDetailDto> Posts { get; set; }
    }
}
