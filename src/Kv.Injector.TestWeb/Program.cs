using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Kv.Injector.TestWeb {

    public class Program {

        public static void Main(string[] args) {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hc, config) => config.AddJsonFile("secrets/appsettings.secrets.json", optional: true))
                //.ConfigureAppConfiguration((hc, config) => config.AddJsonFile("appsettings.keyvault.json", optional: true))
                .UseStartup<Startup>();
    }
}
