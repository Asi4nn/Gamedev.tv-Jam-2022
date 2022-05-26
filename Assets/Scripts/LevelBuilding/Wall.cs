using System.Collections;
using UnityEngine;

namespace Game.LevelBuilding
{
    

    public class Wall : MonoBehaviour
    {
        public ObjectType type;

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

        private void Start()
        {
            // StartCoroutine(Move(5f, Quaternion.LookRotation(new Vector3(1, 0, 1), Vector3.up), transform.position + new Vector3(3, 0, 3)));
        }

        /// <summary>
        /// Method to move the wall as necessary
        /// </summary>
        /// <param name="velocity">Velocity of movement</param>
        /// <param name="rotation">Rotation of movement</param>
        /// <param name="destination">World space coords of destination</param>
        public IEnumerator Move (float moveTime, Quaternion rotation, Vector3 destination)
        {
            float currentMoveTime = 0;
            Vector3 originalPosition = transform.position;
            Quaternion originalRotation = transform.rotation;

            yield return new WaitForEndOfFrame();
            while (Vector3.Distance(transform.position, destination) > 0 || transform.rotation != rotation)
            {
                currentMoveTime += Time.deltaTime;
                transform.SetPositionAndRotation(
                    Vector3.Lerp(originalPosition, destination, currentMoveTime / moveTime), 
                    Quaternion.Lerp(originalRotation, rotation, currentMoveTime / moveTime)
                );

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
