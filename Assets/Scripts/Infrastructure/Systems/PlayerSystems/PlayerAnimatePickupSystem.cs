using Infrastructure.Components.PlayerComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Infrastructure.Systems.PlayerSystems
{
    public class PlayerAnimatePickupSystem : IEcsRunSystem
    {
        private static readonly int PickupAnimationKey = Animator.StringToHash("WeaponType_int");
        
        private const int PickupLoot = 1;

        private EcsFilter<Player, AddToInventory> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref EcsEntity playerEntity = ref _filter.GetEntity(i);
                ref Player player = ref _filter.Get1(i);

                player.PlayerAnimator.SetInteger(PickupAnimationKey, PickupLoot);
                player.PlayerView.LootPickup();

                playerEntity.Del<AddToInventory>();
            }
        }
    }
}