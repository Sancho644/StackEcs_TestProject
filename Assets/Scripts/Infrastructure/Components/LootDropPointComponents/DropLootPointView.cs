using System;
using TMPro;
using UnityEngine;

namespace Infrastructure.Components.LootDropPointComponents
{
    public class DropLootPointView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _stackValue;

        private int _stackCount;

        private Action OnTrigger;

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
            OnTrigger?.Invoke();
        }

        public void Trigger(Action callback)
        {
            OnTrigger = callback;
        }
    }
}