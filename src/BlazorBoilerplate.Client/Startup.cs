using BlazorBoilerplate.Client.Services.Contracts;
using BlazorBoilerplate.Client.Services.Implementations;
using BlazorBoilerplate.Client.States;
using MatBlazor.DependencyInjection;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

//using Blazored.LocalStorage;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace BlazorBoilerplate.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<AuthenticationState>();
            services.AddScoped<IAuthorizeApi, AuthorizeApi>();

            //services.AddBlazoredLocalStorage();
            services.AddLoadingBar();

            services.AddMatToaster(config =>
            {
                config.PositionClass = MatBlazor.MatToaster.Helpers.Position.BottomRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 3000;
            });

        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.UseLoadingBar();
            app.AddComponent<App>("app");
        }
    }
}
