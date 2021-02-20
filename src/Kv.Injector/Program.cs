using System;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Kv.Injector {

    public class Program {

        public static void Main(string[] args) {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) => {

                    var builtConfig = config.Build();
                    var keyVaultConfigBuilder = new ConfigurationBuilder();

                    var vaultUrl = builtConfig["KeyVault:VaultUrl"];
                    var clientId = builtConfig["KeyVault:ClientId"];
                    var secret = builtConfig["KeyVault:ClientSecret"];

                    // If we get a clientID and secret, use them. If not, assume that we'll just use the
                    // managed service instance from Azure to get the credentials
                    if (String.IsNullOrEmpty(clientId) == false && String.IsNullOrEmpty(secret) == false) {
                        keyVaultConfigBuilder.AddAzureKeyVault(vaultUrl, clientId, secret);
                    }
                    else {
                        keyVaultConfigBuilder.AddAzureKeyVault(vaultUrl);
                    }

                    // Build and apply the KeyVault configuration
                    var keyVaultConfig = keyVaultConfigBuilder.Build();
                    config.AddConfiguration(keyVaultConfig);
                })
                .UseStartup<Startup>();
    }
}
