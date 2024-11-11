using System.Threading;
using Cysharp.Threading.Tasks;
using R3;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class ModalUseCase
    {
        private readonly Subject<GameModal> _setup;
        private readonly Subject<bool> _complete;

        public ModalUseCase()
        {
            _setup = new Subject<GameModal>();
            _complete = new Subject<bool>();
        }

        public Observable<GameModal> setup => _setup.Where(x => x != GameModal.None);

        public UniTask<bool> IsCompleteAsync(CancellationToken token) =>
            _complete.AnyAsync(cancellationToken: token).AsUniTask();

        public void SetUp(GameModal value) => _setup?.OnNext(value);

        public void Complete(bool value) => _complete?.OnNext(value);
    }
}