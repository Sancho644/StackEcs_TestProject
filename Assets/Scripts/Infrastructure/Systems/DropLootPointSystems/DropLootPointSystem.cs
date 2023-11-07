using Infrastructure.Components.LootDropPointComponents;
using Infrastructure.Components.PlayerComponents;
using Leopotam.Ecs;

namespace Infrastructure.Systems.DropLootPointSystems
{
    public class DropLootPointSystem : IEcsRunSystem
    {
        private const string PickupAnimationKey = "WeaponType_int";

        private EcsFilter<DropLootPoint, DropLoot> _dropLootFilter;
        private EcsFilter<Player> _playerFilter;

        public void Run()
        {
            foreach (int i in _dropLootFilter)
            {
                ref var dropLootEntity = ref _dropLootFilter.GetEntity(i);
                ref var dropLootPoint = ref _dropLootFilter.Get1(i);

                foreach (int j in _playerFilter)
                {
                    ref var player = ref _playerFilter.Get1(j);

                    dropLootPoint.DropLootTransform.GetComponent<DropLootPointView>().AddStack(player.StackCount);

                    player.PlayerTransform.GetComponent<PlayerView>().DropLoot();
                    player.PlayerAnimator.SetInteger(PickupAnimationKey, 0);
                    player.StackCount = 0;

                    dropLootEntity.Del<DropLoot>();
                }
            }
        }
    }
}