using Infrastructure.Components.InventoryComponents;
using Infrastructure.Components.LootComponents;
using Infrastructure.Components.PlayerComponents;
using Leopotam.Ecs;

namespace Infrastructure.Systems.InventorySystems
{
    public class InventoryAddLootSystem : IEcsRunSystem
    {
        private EcsFilter<HasLoot, LootPickup, Loot> _lootFilter;
        private EcsFilter<Inventory> _inventoryFilter;
        private EcsFilter<Player> _playerFilter;

        private int _lootValue;

        public void Run()
        {
            foreach (int i in _lootFilter)
            {
                ref EcsEntity lootEntity = ref _lootFilter.GetEntity(i);
                ref Loot loot = ref _lootFilter.Get3(i);

                _lootValue = loot.LootCount;

                AddInventoryStack();

                lootEntity.Del<LootPickup>();
            }
        }

        private void AddInventoryStack()
        {
            foreach (int i in _inventoryFilter)
            {
                ref Inventory inventory = ref _inventoryFilter.Get1(i);

                inventory.LootStack += _lootValue;

                PlayerAddComponent();

                _lootValue = 0;
            }
        }

        private void PlayerAddComponent()
        {
            foreach (int j in _playerFilter)
            {
                ref EcsEntity playerEntity = ref _playerFilter.GetEntity(j);

                playerEntity.Get<AddToInventory>();
            }
        }
    }
}