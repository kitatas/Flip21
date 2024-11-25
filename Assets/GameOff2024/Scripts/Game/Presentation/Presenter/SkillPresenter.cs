using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View;
using GameOff2024.Game.Presentation.View.Modal;
using ObservableCollections;
using R3;
using VContainer.Unity;

namespace GameOff2024.Game.Presentation.Presenter
{
    public sealed class SkillPresenter : IStartable
    {
        private readonly SkillUseCase _skillUseCase;
        private readonly PickModalView _pickModalView;
        private readonly SkillView _skillView;

        public SkillPresenter(SkillUseCase skillUseCase, PickModalView pickModalView, SkillView skillView)
        {
            _skillUseCase = skillUseCase;
            _pickModalView = pickModalView;
            _skillView = skillView;
        }

        public void Start()
        {
            _skillUseCase.pickList
                .ObserveReplace()
                .SubscribeAwait(async (x, token) =>
                {
                    _pickModalView.Render(x.Index, x.NewValue);
                    if (x.Index == PickConfig.MAX_NUM - 1)
                    {
                        await _pickModalView.ShowAsync(ModalConfig.DURATION, token);
                    }
                })
                .AddTo(_pickModalView);

            foreach (var onClick in _pickModalView.OnClicks())
            {
                onClick
                    .SubscribeAwait(async (x, token) =>
                    {
                        _skillUseCase.Select(x);
                        await _pickModalView.HideAsync(ModalConfig.DURATION, token);
                    })
                    .AddTo(_pickModalView);
            }

            _skillUseCase.chipRate
                .Subscribe(_skillView.Render)
                .AddTo(_skillView);

            _pickModalView.Hide(0.0f);
        }
    }
}