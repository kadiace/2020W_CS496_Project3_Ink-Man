using Platformer.Core;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This class exposes the the game model in the inspector, and ticks the
    /// simulation.
    /// </summary> 
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        //This model field is public and can be therefore be modified in the 
        //inspector.
        //The reference actually comes from the InstanceRegister, and is shared
        //through the simulation and events. Unity will deserialize over this
        //shared reference when the scene loads, allowing the model to be
        //conveniently configured inside the inspector.
        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        void EnsureModelReferences()
        {
            if (model == null)
                model = Simulation.GetModel<PlatformerModel>();

            if (model.player == null)
            {
                model.player = FindObjectOfType<PlayerController>();
                if (model.player == null)
                    Debug.LogWarning("PlatformerModel.player is not assigned and no PlayerController was found in scene.");
            }
        }

        void OnEnable()
        {
            Instance = this;
            EnsureModelReferences();
        }

        void OnDisable()
        {
            if (Instance == this) Instance = null;
        }

        void Update()
        {
            if (Instance == this)
            {
                if (model == null || model.player == null)
                    EnsureModelReferences();

                Simulation.Tick();
            }
        }
    }
}
