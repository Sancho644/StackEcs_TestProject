using Leopotam.Ecs;
using UnityEngine;

namespace Infrastructure.Components.LootComponents
{
    public class LootView : MonoBehaviour
    {
        public EcsEntity Entity;
        
        private void OnTriggerEnter(Collider other)
        {
            Entity.Get<HasLoot>().loot.Get<LootPickup>();
            
            Destroy(gameObject);
        }
    }
}