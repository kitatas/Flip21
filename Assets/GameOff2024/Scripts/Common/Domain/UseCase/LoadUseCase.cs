using R3;

namespace GameOff2024.Common.Domain.UseCase
{
    public sealed class LoadUseCase
    {
        private readonly ReactiveProperty<bool> _isLoad;

        public LoadUseCase()
        {
            _isLoad = new ReactiveProperty<bool>(false);
        }

        public Observable<bool> isLoad => _isLoad;

        public void Set(bool value) => _isLoad.Value = value;
    }
}