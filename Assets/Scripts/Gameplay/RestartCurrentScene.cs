using Platformer.Core;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{
    public class RestartCurrentScene : Simulation.Event<RestartCurrentScene>
    {
        public override void Execute()
        {
            var sceneName = SceneManager.GetActiveScene().name;
            if (!string.IsNullOrEmpty(sceneName) &&
                UnityEngine.Application.CanStreamedLevelBeLoaded(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
