using System;
using UnityEngine;

namespace Infrastructure.Components.LootComponents
{
    public class LootView : MonoBehaviour
    {
        private Action OnTrigger;

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