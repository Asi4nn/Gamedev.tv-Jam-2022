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
        PlayerState state;

        Rigidbody rb;

        readonly string PlayerLayerName = "Alive";
        readonly string GhostLayerName = "Ghost";

        private void Awake()
        {
            state = new PlayerState(true);

            rb = GetComponent<Rigidbody>();
            gameObject.layer = LayerMask.NameToLayer(PlayerLayerName);
        }

        void Update()
        {
            foreach (PlayerKeys key in Enum.GetValues(typeof(PlayerKeys)))
            {
                if (key != PlayerKeys.Interact)
                {
                    if (Bindings.Instance.GetPlayerKey(playerNumber, key))
                    {
                        Movement(key);
                    }
                }
                else
                {
                    if (Bindings.Instance.GetPlayerKey(playerNumber, key))
                    {
                        Interact();
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

        public void TriggerDeath()
        {
            if (!state.isAlive) return;

            state.isAlive = false;
            aliveModel.SetActive(false);
            ghostModel.SetActive(true);
            gameObject.layer = LayerMask.NameToLayer(GhostLayerName);
        }

        public void TriggerRevive()
        {
            if (state.isAlive) return;

            state.isAlive = true;
            aliveModel.SetActive(true);
            ghostModel.SetActive(false);
            gameObject.layer = LayerMask.NameToLayer(PlayerLayerName);
        }
    }
}
