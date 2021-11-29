using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Services
{
    public abstract class BaseServices
    {
        protected readonly IConfiguration _configuration;

        public BaseServices(IConfiguration configuration) => 
            (this._configuration) = (configuration);
    }
}
