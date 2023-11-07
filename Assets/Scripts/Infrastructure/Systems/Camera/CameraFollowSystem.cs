using Data;
using Infrastructure.Components.PlayerComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Infrastructure.Systems.Camera
{
    public class CameraFollowSystem : IEcsRunSystem
    {
        private EcsFilter<Player> _filter;

        private StaticData _staticData;
        private SceneData _sceneData;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref var player = ref _filter.Get1(i);

                Quaternion rotation = Quaternion.Euler(_staticData.CameraRotationAngelX, 0, 0);
                Vector3 position = rotation * new Vector3(0, 0, -_staticData.CameraDistance) + FollowingPointPosition(player);

                _sceneData.MainCamera.transform.rotation = rotation;
                _sceneData.MainCamera.transform.position = position;
            }
        }

        private Vector3 FollowingPointPosition(Player player)
        {
            Vector3 followingPosition = player.PlayerTransform.position;
            followingPosition.y += _staticData.CameraOffsetY;

            return followingPosition;
        }
    }
}