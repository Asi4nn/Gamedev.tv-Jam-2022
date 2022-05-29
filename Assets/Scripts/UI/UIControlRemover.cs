using Game.Control;
using UnityEngine;

namespace Game.UI
{
    public class UIControlRemover : MonoBehaviour
    {
        GameObject[] players;

        private void Awake()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }

        public void DisableControl()
        {
            SetPlayerControllerActive(false);
        }

        public void EnableControl()
        {
            SetPlayerControllerActive(true);
        }

        private void SetPlayerControllerActive(bool active)
        {
            foreach (GameObject player in players)
            {
                player.GetComponent<PlayerController>().enabled = active;
            }
        }
    }
}
