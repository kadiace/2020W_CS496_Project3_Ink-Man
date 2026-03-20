using Platformer.Core;
using Platformer.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{
    public class ShowBossClearOverlay : Simulation.Event<ShowBossClearOverlay>
    {
        public override void Execute()
        {
            var sceneName = SceneManager.GetActiveScene().name;
            if (sceneName != "Stage3" && sceneName != "Stage_boss")
                return;

            Debug.Log("ShowBossClearOverlay.Execute");
            StageProgress.MarkClearedForScene(sceneName);
            BossClearOverlay.Show();
        }
    }
}
