using Infrastructure.Components.LootComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Infrastructure.Systems.LootSystems
{
    public class SpawnCooldownSystem : IEcsRunSystem
    {
        private EcsFilter<SpawnCooldownDuration> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(i);
                ref SpawnCooldownDuration cooldown = ref _filter.Get1(i);

                cooldown.SpawnCooldown -= Time.deltaTime;

                if (cooldown.SpawnCooldown <= 0)
                {
                    entity.Del<SpawnCooldownDuration>();
                }
            }
        }
    }
}