using Data;
using Infrastructure.Components.PlayerComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Infrastructure.Systems.PlayerSystems
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Player, PlayerInputData> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref Player player = ref _filter.Get1(i);
                ref PlayerInputData input = ref _filter.Get2(i);

                Vector3 movementVector = input.MoveInput + Physics.gravity;

                player.PlayerController.Move(player.PlayerSpeed * movementVector * Time.deltaTime);
            }
        }
    }
}