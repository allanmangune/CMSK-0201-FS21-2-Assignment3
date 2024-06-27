using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF3Data.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
