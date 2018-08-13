using System.Windows;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.WpfExtensions.Areas.Initialization;

namespace Mmu.Was.WpfUI
{
    public partial class App
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            var appIcon = WpfUI.Properties.Resources.M;
            var assemblyParameters = AssemblyParameters.CreateFromAssembly(typeof(App).Assembly);

            var appConfig = ApplicationConfiguration.CreateFromIcon("WAS", appIcon);
            await BootstrapService.StartUpAsync(assemblyParameters, appConfig);
        }
    }
}