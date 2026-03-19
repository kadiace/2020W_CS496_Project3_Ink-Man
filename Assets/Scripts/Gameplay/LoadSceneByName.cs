using Platformer.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{
    public class LoadSceneByName : Simulation.Event<LoadSceneByName>
    {
        public string sceneName;

        public override void Execute()
        {
            if (string.IsNullOrEmpty(sceneName))
                return;

            if (Application.CanStreamedLevelBeLoaded(sceneName))
                SceneManager.LoadScene(sceneName);
        }

        internal override void Cleanup()
        {
            sceneName = null;
        }
    }
}
