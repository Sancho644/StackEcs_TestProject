using Infrastructure.Components.PlayerComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Infrastructure.Systems.PlayerSystems
{
    public class PlayerAnimationSystem : IEcsRunSystem
    {
        private const float DampTime = 0.1f;
        
        private static readonly int PlayerSpeed = Animator.StringToHash("Speed_f");

        private EcsFilter<Player> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref Player player = ref _filter.Get1(i);

                player.PlayerAnimator.SetFloat(PlayerSpeed, player.PlayerController.velocity.magnitude, DampTime, Time.deltaTime);
            }
        }
    }
}