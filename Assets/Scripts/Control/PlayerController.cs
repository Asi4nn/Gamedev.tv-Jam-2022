using Game.Core;
using System;
using UnityEngine;

namespace Game.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] int playerNumber;
        [SerializeField] float speed;
        [SerializeField] float maxSpeed;
        public Vector3 direction;
        PlayerState state;

        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            direction = Vector3.zero;
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
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction.normalized);
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
    }
}
