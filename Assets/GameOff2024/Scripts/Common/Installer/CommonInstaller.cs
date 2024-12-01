using GameOff2024.Common.Data.DataStore;
using GameOff2024.Common.Data.Entity;
using GameOff2024.Common.Domain.Repository;
using GameOff2024.Common.Domain.UseCase;
using GameOff2024.Common.Presentation.Presenter;
using GameOff2024.Common.Presentation.View;
using GameOff2024.Common.Presentation.View.Modal;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameOff2024.Common.Installer
{
    public sealed class CommonInstaller : LifetimeScope
    {
        [SerializeField] private BgmTable bgmTable = default;
        [SerializeField] private SeTable seTable = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // DataStore
            builder.RegisterInstance<BgmTable>(bgmTable);
            builder.RegisterInstance<SeTable>(seTable);

            // Entity
            builder.Register<UserEntity>(Lifetime.Singleton);

            // Repository
            builder.Register<PlayFabRepository>(Lifetime.Singleton);
            builder.Register<SaveRepository>(Lifetime.Singleton);
            builder.Register<SoundRepository>(Lifetime.Singleton);

            // UseCase
            builder.Register<LoadUseCase>(Lifetime.Singleton);
            builder.Register<SceneUseCase>(Lifetime.Singleton);
            builder.Register<SoundUseCase>(Lifetime.Singleton);

            // Presenter
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<LoadPresenter>();
                entryPoints.Add<SoundPresenter>();
            });

            // View
            builder.RegisterInstance<LoadModalView>(FindFirstObjectByType<LoadModalView>());
            builder.RegisterInstance<SoundView>(FindFirstObjectByType<SoundView>());
        }
    }
}