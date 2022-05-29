using Game.Core;
using UnityEngine;
using UnityEngine.Events;

namespace Game.LevelBuilding
{
    public class LevelGoal : MonoBehaviour
    {
        [SerializeField] UnityEvent<int> LevelCompleted;

        public int levelNum = 0;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            if (!other.gameObject.GetComponent<PlayerStatusController>().isAlive) return;

            LevelCompleted.Invoke(levelNum);
        }
    }
}
