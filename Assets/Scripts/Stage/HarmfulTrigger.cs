using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Gameplay
{
    public class HarmfulTrigger : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            TryKillPlayer(collider.gameObject);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            TryKillPlayer(collision.gameObject);
        }

        static void TryKillPlayer(GameObject hitObject)
        {
            if (hitObject.GetComponent<PlayerController>() != null)
                Simulation.Schedule<PlayerDeath>(0);
        }
    }
}
