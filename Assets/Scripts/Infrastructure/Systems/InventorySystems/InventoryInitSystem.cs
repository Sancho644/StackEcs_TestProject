using Infrastructure.Components.InventoryComponents;
using Leopotam.Ecs;

namespace Infrastructure.Systems.InventorySystems
{
    public class InventoryInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;

        public void Init()
        {
            EcsEntity inventoryEntity = _ecsWorld.NewEntity();
            
            inventoryEntity.Get<Inventory>();
        }
    }
}