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

            GameObject dropLootGameObject = Object.Instantiate(_staticData.DropLootPointPrefab, _sceneData.LootDropSpawnPoint.position, Quaternion.identity);

            ref DropLootPoint dropLootPoint = ref dropLootPointEntity.Get<DropLootPoint>();
            dropLootPoint.DropLootPointView = dropLootGameObject.GetComponent<DropLootPointView>();
            dropLootPoint.DropLootTransform = dropLootGameObject.transform;
            dropLootPoint.DropLootPointView.SetCount(dropLootPoint.StackCount);
            
            dropLootPoint.DropLootPointView.Trigger(() =>
            {
                dropLootPointEntity.Get<DropLoot>();
            });
        }
    }
}