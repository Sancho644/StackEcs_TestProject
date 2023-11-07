using Data;
using Infrastructure.Components.PlayerComponents;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Systems.PlayerSystems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Init()
        {
            EcsEntity playerEntity = _ecsWorld.NewEntity();

            ref Player player = ref playerEntity.Get<Player>();

            playerEntity.Get<PlayerInputData>();

            GameObject playerGameObject = Object.Instantiate(_staticData.PlayerPrefab, _sceneData.PlayerSpawnPoint.position, Quaternion.identity);
            player.PlayerController = playerGameObject.GetComponent<CharacterController>();
            player.PlayerAnimator = playerGameObject.GetComponent<Animator>();
            player.PlayerTransform = playerGameObject.transform;
            player.PlayerSpeed = _staticData.PlayerSpeed;
        }
    }
}