using UnityEngine;

namespace Game.Core
{
    public class PlayerStatusController : MonoBehaviour
    {
        [SerializeField] GameObject aliveEquipTopHatPrefab;
        [SerializeField] GameObject ghostEquipTopHatPrefab;

        public bool isAlive;
        public bool hasTopHat;

        GameObject tophat;

        private void Awake()
        {
            isAlive = true;
            hasTopHat = false;
        }

        public bool EquipTopHat()
        {
            if (hasTopHat) return false;

            hasTopHat = true;

            if (isAlive)
            {
                tophat = Instantiate(aliveEquipTopHatPrefab, gameObject.transform);
            }
            else
            {
                tophat = Instantiate(ghostEquipTopHatPrefab, gameObject.transform);
            }

            return true;
        }

        public bool UnEquipTopHat()
        {
            if (!hasTopHat) return false;

            hasTopHat = false;
            Destroy(tophat);

            return true;
        }

        public bool UpdateTopHat()
        {
            if (!hasTopHat) return false;

            UnEquipTopHat();
            EquipTopHat();

            return true;
        }
    }
}