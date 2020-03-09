using avianoise.Data;
using avianoise.Web.Tests.InMemory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTested.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Tests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.ReplaceScoped<IAviaNoiseDbContext, MockAvianoiseDbContext>();
            // Replace only your own custom services. The ASP.NET Core ones 
            // are already replaced by MyTested.AspNetCore.Mvc. 
            //services.ReplaceScoped<IRoleBL, MockRoleBL>();
        }
    }
}
