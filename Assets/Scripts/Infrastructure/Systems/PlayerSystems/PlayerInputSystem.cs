using Data;
using Infrastructure.Components.PlayerComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Infrastructure.Systems.PlayerSystems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        
        private EcsFilter<Player, PlayerInputData> _filter;

        private SceneData _sceneData;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref Player player = ref _filter.Get1(i);
                ref PlayerInputData input = ref _filter.Get2(i);

                input.MoveInput = GetMovementVector(player);
            }
        }

        private Vector3 GetMovementVector(Player player)
        {
            Vector2 inputVector = new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));

            Vector3 movementVector = Vector3.zero;

            if (inputVector.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _sceneData.MainCamera.transform.TransformDirection(inputVector);
                movementVector.y = 0;
                movementVector.Normalize();

                player.PlayerTransform.forward = movementVector;
            }

            return movementVector;
        }
    }
}