using GameOff2024.Common.Domain.Repository;
using VContainer;
using VContainer.Unity;

namespace GameOff2024.Common.Installer
{
    public sealed class CommonInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Repository
            builder.Register<SaveRepository>(Lifetime.Scoped);
        }
    }
}