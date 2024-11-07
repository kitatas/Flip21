using GameOff2024.Game.Data.Entity;
using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.Presenter;
using GameOff2024.Game.Presentation.State;
using VContainer;
using VContainer.Unity;

namespace GameOff2024.Game.Installer
{
    public sealed class GameInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Entity
            builder.Register<EnemyHandEntity>(Lifetime.Scoped);
            builder.Register<DeckEntity>(Lifetime.Scoped);
            builder.Register<PlayerHandEntity>(Lifetime.Scoped);

            // UseCase
            builder.Register<DealUseCase>(Lifetime.Scoped);
            builder.Register<StateUseCase>(Lifetime.Scoped);

            // Presenter
            builder.UseEntryPoints(Lifetime.Scoped, entryPoints =>
            {
                entryPoints.Add<StatePresenter>();
            });

            // State
            builder.Register<BaseState, InitState>(Lifetime.Scoped);
        }
    }
}