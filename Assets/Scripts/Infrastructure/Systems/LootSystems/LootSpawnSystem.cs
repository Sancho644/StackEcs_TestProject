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
                ref var lootList = ref _filter.Get2(i);

                SpawnLoot(lootList);

                entity.Get<SpawnCooldownDuration>().SpawnCooldown = _staticData.LootSpawnCooldown;
            }
        }

        private void SpawnLoot(LootList lootList)
        {
            foreach (SpawnerPoint spawnerPoint in lootList.SpawnerPointsList)
            {
                if (spawnerPoint.LootGameObject == null)
                {
                    GameObject lootGameObject = Object.Instantiate(_staticData.LootPrefab, spawnerPoint.SpawnTransform.position, Quaternion.identity);

                    spawnerPoint.LootGameObject = lootGameObject;

                    EcsEntity lootEntity = _ecsWorld.NewEntity();

                    lootGameObject.GetComponent<LootView>().Entity = lootEntity;

                    ref HasLoot hasLoot = ref lootEntity.Get<HasLoot>();
                    ref Loot loot = ref lootEntity.Get<Loot>();

                    hasLoot.loot = lootEntity;
                    loot.LootCount = _staticData.LootValue;
                }
                else
                {
                    ref var lootEntity = ref spawnerPoint.LootGameObject.GetComponent<LootView>().Entity;
                    ref var loot = ref lootEntity.Get<Loot>();

                    loot.LootCount += _staticData.LootValue;
                }
            }
        }
    }
}