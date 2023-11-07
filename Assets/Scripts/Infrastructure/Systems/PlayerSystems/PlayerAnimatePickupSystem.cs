using Infrastructure.Components.PlayerComponents;
using Leopotam.Ecs;

namespace Infrastructure.Systems.PlayerSystems
{
    public class PlayerAnimatePickupSystem : IEcsRunSystem
    {
        private const string PickupAnimationKey = "WeaponType_int";

        private EcsFilter<Player, PlayerPickupLoot> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref EcsEntity playerEntity = ref _filter.GetEntity(i);
                ref Player player = ref _filter.Get1(i);

                player.PlayerAnimator.SetInteger(PickupAnimationKey, 1);
                player.PlayerTransform.GetComponent<PlayerView>().LootPickup();

                playerEntity.Del<PlayerPickupLoot>();
            }
        }
    }
}