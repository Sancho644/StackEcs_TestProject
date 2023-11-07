using UnityEngine;

namespace Infrastructure.Components.PlayerComponents
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private GameObject _lootObject;

        public void LootPickup()
        {
            _lootObject.SetActive(true);
        }

        public void DropLoot()
        {
            _lootObject.SetActive(false);
        }
    }
}