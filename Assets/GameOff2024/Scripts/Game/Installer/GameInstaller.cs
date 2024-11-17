using GameOff2024.Game.Data.DataStore;
using GameOff2024.Game.Data.Entity;
using GameOff2024.Game.Domain.Repository;
using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.Presenter;
using GameOff2024.Game.Presentation.State;
using GameOff2024.Game.Presentation.View;
using GameOff2024.Game.Presentation.View.Modal;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameOff2024.Game.Installer
{
    public sealed class GameInstaller : LifetimeScope
    {
        [SerializeField] private SuitTable suitTable = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // DataStore
            builder.RegisterInstance<SuitTable>(suitTable);

            // Entity
            builder.Register<ChipEntity>(Lifetime.Scoped);
            builder.Register<EnemyHandEntity>(Lifetime.Scoped);
            builder.Register<DeckEntity>(Lifetime.Scoped);
            builder.Register<PlayerHandEntity>(Lifetime.Scoped);

            // Repository
            builder.Register<SuitRepository>(Lifetime.Scoped);

            // UseCase
            builder.Register<ActionUseCase>(Lifetime.Scoped);
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
            builder.Register<BaseState, ActionState>(Lifetime.Scoped);
            builder.Register<BaseState, BetState>(Lifetime.Scoped);
            builder.Register<BaseState, DealState>(Lifetime.Scoped);
            builder.Register<BaseState, LoseState>(Lifetime.Scoped);
            builder.Register<BaseState, WinState>(Lifetime.Scoped);

            // View
            builder.RegisterComponentInHierarchy<ActionView>();
            builder.RegisterComponentInHierarchy<BetView>();
            builder.RegisterComponentInHierarchy<ChipView>();
            builder.RegisterComponentInHierarchy<TableView>();

            // Modal
            builder.RegisterComponentInHierarchy<BetModalView>().As<BaseModalView>();
            builder.RegisterComponentInHierarchy<DrawModalView>().As<BaseModalView>();
            builder.RegisterComponentInHierarchy<LoseModalView>().As<BaseModalView>();
            builder.RegisterComponentInHierarchy<WinModalView>().As<BaseModalView>();
        }
    }
}