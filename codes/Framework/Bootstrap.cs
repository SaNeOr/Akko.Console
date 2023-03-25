using System.Threading.Tasks;
using Akko.API.AssetServer;
using Akko.Framework.API.Logger;
using Akko.Framework.Impl.Logger;
using Akko.Impl.AssetServer;
using Godot;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Akko
{
    public static class App
    {
        public static ServiceProvider Provider { get; set; }
    }

    public partial class Bootstrap : Node
    {
        public override async void _Ready()
        {
            GD.Print("Bootstrap");
            await BuildServer();
        }
        
        
        async Task BuildServer()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddGrpc();       // Add this line(Grpc.AspNetCore)
            builder.Services.AddMagicOnion(); // Add this line(MagicOnion.Server)
            
            ConfigureSingletonServices(builder.Services);
            App.Provider = builder.Services.BuildServiceProvider();
            var app = builder.Build();

            app.MapMagicOnionService(); // Add this line
            await app.RunAsync();
        }

        public void ConfigureSingletonServices(IServiceCollection services)
        {
            // services.Add(new ServiceDescriptor(typeof(ILog), new MyConsoleLogger()));    // singleton
            // services.Add(new ServiceDescriptor(typeof(ILog), typeof(MyConsoleLogger), ServiceLifetime.Transient)); // Transient
            // services.Add(new ServiceDescriptor(typeof(ILog), typeof(MyConsoleLogger), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ILogger), new Logger()));
            services.Add(new ServiceDescriptor(typeof(IAssetServer), new AssetServer()));
        }

    }
}