using Game.Control;
using Game.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Game.LevelBuilding
{
    [System.Serializable]
    public class SwitchEvent : UnityEvent<GameObject> { }

    public class Switch : MonoBehaviour, IInteractable
    {
        public ObjectType type;

        // Subscribe events to happen to these Unity events in the inspect
        [SerializeField] SwitchEvent activate;
        [SerializeField] SwitchEvent deactivate;


        [SerializeField] TextMeshProUGUI text;
        [SerializeField] Animator anim;

        bool active;
        float activationRadius = 1.5f;

        private void Awake()
        {
            active = false;
            text.gameObject.SetActive(false);
        }

        private void Update()
        {
            text.gameObject.SetActive(false);
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, activationRadius, Vector3.up, 0);
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    bool playerIsAlive = hit.transform.GetComponent<PlayerStatusController>().isAlive;
                    if (type == ObjectType.Hybrid || type == ObjectType.Ghost && !playerIsAlive || type == ObjectType.Normal && playerIsAlive)
                        DrawActivationUI(hit.transform.gameObject);
                }
            }
        }

        public void Interact(GameObject player)
        {
            ToggleSwitch(player);
        }

        void DrawActivationUI(GameObject player)
        {
            // TODO: Modify text to display the activation button

            text.gameObject.SetActive(true);
        }

        private void ToggleSwitch(GameObject player)
        {
            if (active)
            {
                active = false;
                deactivate.Invoke(player);
                anim.SetTrigger("deactivate");
            }
            else
            {
                active = true;
                activate.Invoke(player);
                anim.SetTrigger("activate");

            }
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, activationRadius);
        }
    }
}
