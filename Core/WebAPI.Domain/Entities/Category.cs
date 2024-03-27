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

        public Category(int paretnId, string name, int prioriy)
        {
            ParentId = paretnId;
            Name = name;
            Priority = prioriy;
        }

        public required int ParentId { get; set; }
        public required string Name { get; set; }
        public required int Priority { get; set; }
        public ICollection<Detail> Details { get; set; }
        ICollection<Brand> Brands { get; set; }
    }
}