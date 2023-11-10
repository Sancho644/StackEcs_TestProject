using System.Collections.Generic;
using Data;
using Infrastructure.Components.LootComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Infrastructure.Systems.LootSystems
{
    public class LootSpawnInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;

        private SceneData _sceneData;

        public void Init()
        {
            EcsEntity lootSpawnerEntity = _ecsWorld.NewEntity();

            lootSpawnerEntity.Get<SpawnLoot>();
            ref LootList lootList = ref lootSpawnerEntity.Get<LootList>();

            lootList.SpawnerPointsList = new List<SpawnerPoint>();

            foreach (Transform lootSpawnerPoint in _sceneData.LootSpawnerPoints)
            {
                lootList.SpawnerPointsList.Add(new SpawnerPoint()
                {
                    SpawnTransform = lootSpawnerPoint
                });
            }
        }
    }
}