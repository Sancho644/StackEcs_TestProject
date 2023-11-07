using Data;
using Infrastructure.Systems.Camera;
using Infrastructure.Systems.DropLootPointSystems;
using Infrastructure.Systems.LootSystems;
using Infrastructure.Systems.PlayerSystems;
using Leopotam.Ecs;
using UnityEngine;

namespace Infrastructure
{
    public class EcsStartup : MonoBehaviour
    {
        [SerializeField] private StaticData _staticData;
        [SerializeField] private SceneData _sceneData;

        private EcsWorld _ecsWorld;
        private EcsSystems _updateSystems;

        private void Start()
        {
            _ecsWorld = new EcsWorld();
            _updateSystems = new EcsSystems(_ecsWorld);

            _updateSystems
                .Add(new SpawnCooldownSystem())
                .Add(new PlayerInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new PlayerMoveSystem())
                .Add(new PlayerAnimationSystem())
                .Add(new PlayerStackWriterSystem())
                .Add(new PlayerAnimatePickupSystem())
                .Add(new CameraFollowSystem())
                .Add(new LootSpawnInitSystem())
                .Add(new LootSpawnSystem())
                .Add(new DropLootPointInitSystem())
                .Add(new DropLootPointSystem())
                .Inject(_staticData)
                .Inject(_sceneData)
                .Init();
        }

        private void Update()
        {
            _updateSystems.Run();
        }

        private void OnDestroy()
        {
            _updateSystems?.Destroy();
            _updateSystems = null;
            _ecsWorld?.Destroy();
            _ecsWorld = null;
        }
    }
}