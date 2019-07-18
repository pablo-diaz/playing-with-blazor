using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Services.Contracts;
using Services.Implementations;
using Utils;

namespace blazor_standalone_sample_01
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(GetConfiguration());
            services.AddSingleton<IInvitationService, InvitationService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }

        private Configuration GetConfiguration()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("config.json"))
            using (var reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();
                return Configuration.CreateFromJSON(content);
            }
        }
    }
}
