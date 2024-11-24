using GameOff2024.Boot.Domain.UseCase;
using GameOff2024.Boot.Presentation.Presenter;
using VContainer;
using VContainer.Unity;

namespace GameOff2024.Boot.Installer
{
    public sealed class BootInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // UseCase
            builder.Register<StateUseCase>(Lifetime.Scoped);

            // Presenter
            builder.UseEntryPoints(Lifetime.Scoped, entryPoints =>
            {
                entryPoints.Add<StatePresenter>();
            });
        }
    }
}