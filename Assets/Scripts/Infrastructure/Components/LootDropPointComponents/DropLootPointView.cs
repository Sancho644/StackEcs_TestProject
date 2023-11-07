using Leopotam.Ecs;
using TMPro;
using UnityEngine;

namespace Infrastructure.Components.LootDropPointComponents
{
    public class DropLootPointView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _stackValue;

        public EcsEntity DropLootEntity;

        private int _stackCount;

        public void SetCount(int value)
        {
            _stackCount = value;
            _stackValue.text = _stackCount.ToString();
        }

        public void AddStack(int value)
        {
            _stackCount += value;
            _stackValue.text = _stackCount.ToString();
        }

        private void OnTriggerEnter(Collider other)
        {
            DropLootEntity.Get<DropLoot>();
        }
    }
}