using Game.Core;
using System;
using UnityEngine;

namespace Game.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] GameObject aliveModel;
        [SerializeField] GameObject ghostModel;
        [SerializeField] Animator anim;

        [SerializeField] int playerNumber;
        [SerializeField] float rotationSpeed;
        [SerializeField] float movementSpeed;
        public Vector3 direction;

        Rigidbody rb;
        PlayerStatusController playerStatusController;

        readonly string PlayerLayerName = "Alive";
        readonly string GhostLayerName = "Ghost";

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            playerStatusController = GetComponent<PlayerStatusController>();
            gameObject.layer = LayerMask.NameToLayer(PlayerLayerName);
        }

        void Update()
        {
            foreach (PlayerKeys key in Enum.GetValues(typeof(PlayerKeys)))
            {
                if (Bindings.Instance.GetPlayerKey(playerNumber, key))
                {
                    // Check if movement key
                    if ((int)key <= 3)
                    {
                        Movement(key);
                    }
                    else if (key == PlayerKeys.Interact && Bindings.Instance.GetPlayerKeyDown(playerNumber, key))
                    {
                        Interact();
                    }
                    else if (key == PlayerKeys.TopHat && Bindings.Instance.GetPlayerKeyDown(playerNumber, key))
                    {
                        ActivateTopHat();
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                TriggerDeath();
            }

            // Set animator params
            anim.SetFloat("speed", direction.sqrMagnitude);
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime * direction.normalized);

            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                rb.MoveRotation(Quaternion.Lerp(rb.rotation, lookRotation, rotationSpeed * Time.fixedDeltaTime));
                direction = Vector3.zero;
            }
        }

        public void TriggerDeath()
        {
            aliveModel.SetActive(false);
            ghostModel.SetActive(true);

            playerStatusController.isAlive = false;
            playerStatusController.UpdateTopHat();
            gameObject.layer = LayerMask.NameToLayer(GhostLayerName);
        }

        public void TriggerRevive()
        {
            aliveModel.SetActive(true);
            ghostModel.SetActive(false);

            playerStatusController.isAlive = true;
            playerStatusController.UpdateTopHat();
            gameObject.layer = LayerMask.NameToLayer(PlayerLayerName);
        }

        private void Interact()
        {
            throw new NotImplementedException();
        }

        void Movement(PlayerKeys key)
        {
            switch (key)
            {
                case PlayerKeys.Forward:
                    direction.z = 1;
                    break;
                case PlayerKeys.Backward:
                    direction.z = -1;
                    break;
                case PlayerKeys.Left:
                    direction.x = -1;
                    break;
                case PlayerKeys.Right:
                    direction.x = 1;
                    break;
            }
        }

        void ActivateTopHat()
        {
            if (!playerStatusController.UnEquipTopHat()) return;

            if (playerStatusController.isAlive)
            {
                TriggerDeath();
            }
            else
            {
                TriggerRevive();
            }
            playerStatusController.isAlive = !playerStatusController.isAlive;
        }
    }
}
