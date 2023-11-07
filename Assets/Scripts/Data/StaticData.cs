using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "StaticData", menuName = "Data/StaticData")]
    public class StaticData : ScriptableObject
    {
        [Header("Player")]
        public GameObject PlayerPrefab;
        public float PlayerSpeed;
        
        [Header("Loot")]
        public GameObject LootPrefab;
        public GameObject DropLootPointPrefab;
        public float LootSpawnCooldown;
        public int LootValue;

        [Header("Camera")]
        public float CameraRotationAngelX;
        public float CameraDistance;
        public float CameraOffsetY;
    }
}