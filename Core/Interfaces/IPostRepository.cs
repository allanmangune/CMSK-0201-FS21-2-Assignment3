using EF3Data.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPostsWithDetailsAsync();
    }
}
