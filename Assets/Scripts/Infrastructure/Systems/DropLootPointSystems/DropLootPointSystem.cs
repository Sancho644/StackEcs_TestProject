using Infrastructure.Components.InventoryComponents;
using Infrastructure.Components.LootDropPointComponents;
using Infrastructure.Components.PlayerComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Infrastructure.Systems.DropLootPointSystems
{
    public class DropLootPointSystem : IEcsRunSystem
    {
        private const int DropLoot = 0;
        
        private static readonly int PickupAnimationKey = Animator.StringToHash("WeaponType_int");

        private EcsFilter<DropLootPoint, DropLoot> _dropLootFilter;
        private EcsFilter<Inventory> _inventoryFilter;
        private EcsFilter<Player> _playerFilter;

        public void Run()
        {
            foreach (int i in _dropLootFilter)
            {
                ref EcsEntity dropLootEntity = ref _dropLootFilter.GetEntity(i);
                ref DropLootPoint dropLootPoint = ref _dropLootFilter.Get1(i);

                foreach (int j in _inventoryFilter)
                {
                    ref Inventory inventory = ref _inventoryFilter.Get1(j);

                    dropLootPoint.DropLootTransform.GetComponent<DropLootPointView>().AddStack(inventory.LootStack);

                    PlayerDropAnimation();

                    inventory.LootStack = 0;

                    dropLootEntity.Del<DropLoot>();
                }
            }
        }

        private void PlayerDropAnimation()
        {
            foreach (int i in _playerFilter)
            {
                ref Player player = ref _playerFilter.Get1(i);

                player.PlayerView.DropLoot();
                player.PlayerAnimator.SetInteger(PickupAnimationKey, DropLoot);
            }
        }
    }
}