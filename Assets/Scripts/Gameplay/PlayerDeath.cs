using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            if (player == null || player.health == null)
                return;

            if (player.health.IsAlive)
            {
                player.health.Die();
                if (model.virtualCamera != null)
                {
                    model.virtualCamera.m_Follow = null;
                    model.virtualCamera.m_LookAt = null;
                }
                // player.collider.enabled = false;
                player.controlEnabled = false;
                player.velocity = Vector2.zero;

                var playerBody = player.GetComponent<Rigidbody2D>();
                if (playerBody != null)
                {
                    playerBody.linearVelocity = Vector2.zero;
                    playerBody.gravityScale = 0;
                }

                if (player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);
                if (player.animator != null)
                {
                    player.animator.SetTrigger("hurt");
                    player.animator.SetBool("dead", true);
                }

                var restartDelay = GetDeathAnimationDuration(player.animator);
                Simulation.Schedule<RestartCurrentScene>(restartDelay);
            }
        }

        static float GetDeathAnimationDuration(Animator animator)
        {
            const float minDelay = 1f;

            if (animator == null || animator.runtimeAnimatorController == null)
                return minDelay;

            var clips = animator.runtimeAnimatorController.animationClips;
            if (clips == null || clips.Length == 0)
                return minDelay;

            float best = 0f;
            for (var i = 0; i < clips.Length; i++)
            {
                var clip = clips[i];
                if (clip == null || string.IsNullOrEmpty(clip.name))
                    continue;

                var lower = clip.name.ToLowerInvariant();
                if (lower.Contains("dead") || lower.Contains("hurt") || lower.Contains("death"))
                    best = Mathf.Max(best, clip.length);
            }

            return Mathf.Max(minDelay, best);
        }
    }
}
