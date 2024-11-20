using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View;
using ObservableCollections;
using R3;
using VContainer.Unity;

namespace GameOff2024.Game.Presentation.Presenter
{
    public sealed class SkillPresenter : IStartable
    {
        private readonly SkillUseCase _skillUseCase;
        private readonly PickListView _pickListView;

        public SkillPresenter(SkillUseCase skillUseCase, PickListView pickListView)
        {
            _skillUseCase = skillUseCase;
            _pickListView = pickListView;
        }

        public void Start()
        {
            _skillUseCase.pickList
                .ObserveReplace()
                .Subscribe(x => _pickListView.Render(x.Index, x.NewValue))
                .AddTo(_pickListView);
        }
    }
}