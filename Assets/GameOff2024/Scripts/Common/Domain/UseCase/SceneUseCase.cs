using FastEnumUtility;
using UnityEngine.SceneManagement;

namespace GameOff2024.Common.Domain.UseCase
{
    public sealed class SceneUseCase
    {
        public void Load(SceneName name)
        {
            SceneManager.LoadScene(name.FastToString());
        }
    }
}