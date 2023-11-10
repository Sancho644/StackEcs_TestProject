using UnityEngine;

namespace Infrastructure.Components.PlayerComponents
{
    public struct Player
    {
        public Transform PlayerTransform;
        public Animator PlayerAnimator;
        public CharacterController PlayerController;
        public PlayerView PlayerView;
        public float PlayerSpeed;
    }
}