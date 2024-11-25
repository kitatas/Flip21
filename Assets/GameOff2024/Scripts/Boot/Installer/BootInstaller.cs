using GameOff2024.Boot.Domain.UseCase;
using GameOff2024.Boot.Presentation.Presenter;
using GameOff2024.Boot.Presentation.State;
using GameOff2024.Boot.Presentation.View;
using VContainer;
using VContainer.Unity;

namespace GameOff2024.Boot.Installer
{
    public sealed class BootInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // UseCase
            builder.Register<LoginUseCase>(Lifetime.Scoped);
            builder.Register<StateUseCase>(Lifetime.Scoped);

            // Presenter
            builder.UseEntryPoints(Lifetime.Scoped, entryPoints =>
            {
                entryPoints.Add<StatePresenter>();
            });

            // State
            builder.Register<BaseState, LoadState>(Lifetime.Scoped);
            builder.Register<BaseState, LoginState>(Lifetime.Scoped);
            
            // View
            builder.RegisterComponentInHierarchy<RegisterView>();
        }
    }
}