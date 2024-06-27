using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF3Data.Application.Dtos
{
    public class PostDetailDto
    {
        public string BlogUrl { get; set; }
        public bool BlogIsPublic { get; set; }
        public string BlogTypeName { get; set; }
        public string PostTypeName { get; set; }
        public string PostContent { get; set; }
    }
}
