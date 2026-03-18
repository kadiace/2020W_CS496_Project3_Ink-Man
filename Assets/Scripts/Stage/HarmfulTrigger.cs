using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Model;
using Platformer.Core;

namespace Platformer.Gameplay
{
    public class HarmfulTrigger : MonoBehaviour
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                var player = model.player;
                if (player.health.IsAlive)
                {
                    player.health.Die();
                    model.virtualCamera.m_Follow = null;
                    model.virtualCamera.m_LookAt = null;
                    // player.collider.enabled = false;
                    player.controlEnabled = false;

                    if (player.audioSource && player.ouchAudio)
                        player.audioSource.PlayOneShot(player.ouchAudio);
                    player.animator.SetTrigger("hurt");
                    player.animator.SetBool("dead", true);
                    Simulation.Schedule<PlayerSpawn>(2);
                }
            }
        }
    }
}
