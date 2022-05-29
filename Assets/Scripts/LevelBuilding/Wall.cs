using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.LevelBuilding
{
    public class Wall : MonoBehaviour
    {
        public ObjectType type;

        [System.Serializable]
        struct WallMovementInput
        {
            public WallMovementInput(float moveTime, Quaternion rotation, Vector3 destination)
            {
                this.moveTime = moveTime;
                this.rotation = rotation;
                this.destination = destination;
            }

            public float moveTime;
            public Quaternion rotation;
            public Vector3 destination;
        }

        [SerializeField] List<WallMovementInput> wallMovements;
        int wallMovementIndex = 0;

        private void Awake()
        {
            switch (type)
            {
                case ObjectType.Normal:
                    gameObject.layer = LayerMask.NameToLayer("Alive");
                    break;
                case ObjectType.Ghost:
                    gameObject.layer = LayerMask.NameToLayer("Ghost");
                    break;
            }
        }

        /// <summary>
        /// Rotates through the predefined positions and rotation defined in wallMovements
        /// </summary>
        public void Move()
        {
            if (wallMovements.Count == 0) return;

            StartCoroutine(Move(wallMovements[wallMovementIndex]));

            wallMovementIndex++;
            
            if (wallMovementIndex > wallMovements.Count - 1)
            {
                wallMovementIndex = 0;
            }
        }

        /// <summary>
        /// Method to move the wall as necessary
        /// </summary>
        /// <param name="velocity">Velocity of movement</param>
        /// <param name="rotation">Rotation of movement</param>
        /// <param name="destination">World space coords of destination</param>
        private IEnumerator Move (WallMovementInput input)
        {
            float currentMoveTime = 0;
            Vector3 originalPosition = transform.position;
            Quaternion originalRotation = transform.rotation;

            yield return new WaitForEndOfFrame();
            while (Vector3.Distance(transform.position, input.destination) > 0 || transform.rotation != input.rotation)
            {
                currentMoveTime += Time.deltaTime;
                transform.SetPositionAndRotation(
                    Vector3.Lerp(originalPosition, input.destination, currentMoveTime / input.moveTime), 
                    Quaternion.Lerp(originalRotation, input.rotation, currentMoveTime / input.moveTime)
                );

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
