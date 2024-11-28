using GameOff2024.Common.Domain.UseCase;
using GameOff2024.Common.Presentation.View.Modal;
using R3;
using VContainer.Unity;

namespace GameOff2024.Common.Presentation.Presenter
{
    public sealed class LoadPresenter : IPostInitializable
    {
        private readonly LoadUseCase _loadUseCase;
        private readonly LoadModalView _loadModalView;

        public LoadPresenter(LoadUseCase loadUseCase, LoadModalView loadModalView)
        {
            _loadUseCase = loadUseCase;
            _loadModalView = loadModalView;
        }

        public void PostInitialize()
        {
            _loadUseCase.isLoad
                .Subscribe(x =>
                {
                    if (x)
                    {
                        _loadModalView.Show(ModalConfig.DURATION);
                    }
                    else
                    {
                        _loadModalView.Hide(ModalConfig.DURATION);
                    }
                })
                .AddTo(_loadModalView);

            _loadModalView.Init();
        }
    }
}