using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Infrastructre.Tokens;

namespace WebAPI.Infrastructre
{
    public static class Registration
    {
        public static void AddInfrastruce(this IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));
        }
    }
}
