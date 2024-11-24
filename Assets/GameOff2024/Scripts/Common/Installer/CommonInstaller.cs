using GameOff2024.Common.Data.Entity;
using GameOff2024.Common.Domain.Repository;
using VContainer;
using VContainer.Unity;

namespace GameOff2024.Common.Installer
{
    public sealed class CommonInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Entity
            builder.Register<UserEntity>(Lifetime.Scoped);

            // Repository
            builder.Register<PlayFabRepository>(Lifetime.Scoped);
            builder.Register<SaveRepository>(Lifetime.Scoped);
        }
    }
}