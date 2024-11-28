using GameOff2024.Common.Data.Entity;
using GameOff2024.Common.Domain.Repository;
using GameOff2024.Common.Domain.UseCase;
using GameOff2024.Common.Presentation.Presenter;
using GameOff2024.Common.Presentation.View.Modal;
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
            builder.Register<LoadUseCase>(Lifetime.Singleton);
            builder.Register<SceneUseCase>(Lifetime.Singleton);

            // Presenter
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<LoadPresenter>();
            });

            // View
            builder.RegisterInstance<LoadModalView>(FindFirstObjectByType<LoadModalView>());
        }
    }
}