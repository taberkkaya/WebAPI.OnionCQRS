﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQueryResponse
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
