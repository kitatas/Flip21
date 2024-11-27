using GameOff2024.Common.Data.Entity;
using GameOff2024.Common.Domain.Repository;
using GameOff2024.Common.Domain.UseCase;
using VContainer;
using VContainer.Unity;

namespace GameOff2024.Common.Installer
{
    public sealed class CommonInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Entity
            builder.Register<UserEntity>(Lifetime.Singleton);

            // Repository
            builder.Register<PlayFabRepository>(Lifetime.Singleton);
            builder.Register<SaveRepository>(Lifetime.Singleton);

            // UseCase
            builder.Register<SceneUseCase>(Lifetime.Singleton);
        }
    }
}