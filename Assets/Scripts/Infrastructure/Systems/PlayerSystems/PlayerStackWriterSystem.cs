using Infrastructure.Components.LootComponents;
using Infrastructure.Components.PlayerComponents;
using Leopotam.Ecs;

namespace Infrastructure.Systems.PlayerSystems
{
    public class PlayerStackWriterSystem : IEcsRunSystem
    {
        private EcsFilter<HasLoot, LootPickup, Loot> _lootFilter;
        private EcsFilter<Player> _playerFilter;

        private int _lootValue;

        public void Run()
        {
            foreach (int i in _lootFilter)
            {
                ref EcsEntity lootEntity = ref _lootFilter.GetEntity(i);
                ref Loot loot = ref _lootFilter.Get3(i);

                _lootValue = loot.LootCount;

                SetPlayerStackCount();

                lootEntity.Del<LootPickup>();
            }
        }

        private void SetPlayerStackCount()
        {
            foreach (int i in _playerFilter)
            {
                ref var playerEntity = ref _playerFilter.GetEntity(i);
                ref Player player = ref _playerFilter.Get1(i);

                player.StackCount += _lootValue;
                playerEntity.Get<PlayerPickupLoot>();

                _lootValue = 0;
            }
        }
    }
}