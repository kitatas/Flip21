using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace GameOff2024.Common.Utility
{
    public sealed class UniTaskHelper
    {
        public static UniTask DelayAsync(float duration, CancellationToken token)
        {
            return UniTask.Delay(TimeSpan.FromSeconds(duration), cancellationToken: token);
        }
    }
}