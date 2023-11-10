using Data;
using Infrastructure.Components.LootComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Infrastructure.Systems.LootSystems
{
    public class LootSpawnSystem : IEcsRunSystem
    {
        private EcsFilter<SpawnLoot, LootList>.Exclude<SpawnCooldownDuration> _filter;

        private EcsWorld _ecsWorld;
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(i);
                ref LootList lootList = ref _filter.Get2(i);

                SpawnLoot(lootList);

                entity.Get<SpawnCooldownDuration>().SpawnCooldown = _staticData.LootSpawnCooldown;
            }
        }

        private void SpawnLoot(LootList lootList)
        {
            foreach (SpawnerPoint spawnerPoint in lootList.SpawnerPointsList)
            {
                if (spawnerPoint.LootEntity.IsNull())
                {
                    GameObject lootGameObject = Object.Instantiate(_staticData.LootPrefab, spawnerPoint.SpawnTransform.position, Quaternion.identity);
                    
                    EcsEntity lootEntity = _ecsWorld.NewEntity();
                    spawnerPoint.LootEntity = lootEntity;

                    ref HasLoot hasLoot = ref lootEntity.Get<HasLoot>();
                    hasLoot.loot = lootEntity;
                    
                    ref Loot loot = ref lootEntity.Get<Loot>();
                    loot.LootView = lootGameObject.GetComponent<LootView>();
                    loot.LootView.Trigger(() =>
                    {
                        lootEntity.Get<HasLoot>().loot.Get<LootPickup>();
                        spawnerPoint.LootEntity = EcsEntity.Null;
                        Object.Destroy(lootGameObject);
                    });
                    
                    loot.LootCount = _staticData.LootValue;
                }
                else
                {
                    ref EcsEntity lootEntity = ref spawnerPoint.LootEntity;
                    ref Loot loot = ref lootEntity.Get<Loot>();

                    loot.LootCount += _staticData.LootValue;
                }
            }
        }
    }
}