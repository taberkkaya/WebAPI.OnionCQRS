using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Common;

namespace WebAPI.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {

        }

        public Category(int parentId, string name, int prioriy)
        {
            ParentId = parentId;
            Name = name;
            Priority = prioriy;
        }

        public int ParentId { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}