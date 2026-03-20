using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{

    /// <summary>
    /// This event is triggered when the player character enters a trigger with a VictoryZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredVictoryZone"></typeparam>
    public class PlayerEnteredVictoryZone : Simulation.Event<PlayerEnteredVictoryZone>
    {
        public VictoryZone victoryZone;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            if (player == null)
                return;

            var currentSceneName = SceneManager.GetActiveScene().name;
            StageProgress.MarkClearedForScene(currentSceneName);

            if (player.animator != null)
                player.animator.SetTrigger("victory");

            player.controlEnabled = false;

            var nextSceneName = ResolveNextSceneName(currentSceneName);
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                var loadEvent = Simulation.Schedule<LoadSceneByName>(1.2f);
                loadEvent.sceneName = nextSceneName;
                return;
            }

            if (currentSceneName == "Stage3" || currentSceneName == "Stage_boss")
            {
                Simulation.Schedule<ShowBossClearOverlay>(1.2f);
            }
        }

        static string ResolveNextSceneName(string currentSceneName)
        {
            if (currentSceneName == "Stage1")
                return GetFirstLoadableSceneName("Stage2", null);

            if (currentSceneName == "Stage2")
                return GetFirstLoadableSceneName("Stage3", null);

            return null;
        }

        static string GetFirstLoadableSceneName(string primarySceneName, string fallbackSceneName)
        {
            if (Application.CanStreamedLevelBeLoaded(primarySceneName))
                return primarySceneName;

            if (!string.IsNullOrEmpty(fallbackSceneName) && Application.CanStreamedLevelBeLoaded(fallbackSceneName))
                return fallbackSceneName;

            return null;
        }
    }
}
