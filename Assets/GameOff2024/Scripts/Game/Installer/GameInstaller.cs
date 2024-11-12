using GameOff2024.Game.Data.Entity;
using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.Presenter;
using GameOff2024.Game.Presentation.State;
using GameOff2024.Game.Presentation.View;
using GameOff2024.Game.Presentation.View.Modal;
using VContainer;
using VContainer.Unity;

namespace GameOff2024.Game.Installer
{
    public sealed class GameInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Entity
            builder.Register<ChipEntity>(Lifetime.Scoped);
            builder.Register<EnemyHandEntity>(Lifetime.Scoped);
            builder.Register<DeckEntity>(Lifetime.Scoped);
            builder.Register<PlayerHandEntity>(Lifetime.Scoped);

            // UseCase
            builder.Register<BetUseCase>(Lifetime.Scoped);
            builder.Register<ChipUseCase>(Lifetime.Scoped);
            builder.Register<DealUseCase>(Lifetime.Scoped);
            builder.Register<HandUseCase>(Lifetime.Scoped);
            builder.Register<ModalUseCase>(Lifetime.Scoped);
            builder.Register<StateUseCase>(Lifetime.Scoped);

            // Presenter
            builder.UseEntryPoints(Lifetime.Scoped, entryPoints =>
            {
                entryPoints.Add<BetPresenter>();
                entryPoints.Add<ChipPresenter>();
                entryPoints.Add<ModalPresenter>();
                entryPoints.Add<StatePresenter>();
            });

            // State
            builder.Register<BaseState, BetState>(Lifetime.Scoped);
            builder.Register<BaseState, DealState>(Lifetime.Scoped);

            // View
            builder.RegisterComponentInHierarchy<BetView>();
            builder.RegisterComponentInHierarchy<ChipView>();

            // Modal
            builder.RegisterComponentInHierarchy<BetModalView>().As<BaseModalView>();
        }
    }
}