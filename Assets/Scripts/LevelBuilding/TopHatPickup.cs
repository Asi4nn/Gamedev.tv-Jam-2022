using Game.Core;
using UnityEngine;

namespace Game.LevelBuilding
{
    public class TopHatPickup : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            if (other.GetComponent<PlayerStatusController>().EquipTopHat())
            {
                Destroy(gameObject);
            }
        }
    }
}
