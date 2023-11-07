using Data;
using Infrastructure.Components.LootDropPointComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Infrastructure.Systems.DropLootPointSystems
{
    public class DropLootPointInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Init()
        {
            EcsEntity dropLootPointEntity = _ecsWorld.NewEntity();

            var dropLootGameObject = Object.Instantiate(_staticData.DropLootPointPrefab, _sceneData.LootDropSpawnPoint.position, Quaternion.identity);

            ref DropLootPoint dropLootPoint = ref dropLootPointEntity.Get<DropLootPoint>();
            DropLootPointView dropLootPointView = dropLootGameObject.GetComponent<DropLootPointView>();

            dropLootPoint.DropLootTransform = dropLootGameObject.transform;

            dropLootPointView.DropLootEntity = dropLootPointEntity;
            dropLootPointView.SetCount(dropLootPoint.StackCount);
        }
    }
}