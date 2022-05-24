using UnityEngine;

namespace Game.LevelBuilding
{
    public enum WallType
    {
        Normal, // Blocks alive players
        Ghost,  // Blocks dead players
        Hybrid  // Blocks all players
    }

    public class Wall : MonoBehaviour
    {
        public WallType type;

        private void Awake()
        {
            switch (type)
            {
                case WallType.Normal:
                    gameObject.layer = LayerMask.NameToLayer("Alive");
                    break;
                case WallType.Ghost:
                    gameObject.layer = LayerMask.NameToLayer("Ghost");
                    break;
            }
        }

        /// <summary>
        /// Method to move the wall as necessary
        /// </summary>
        /// <param name="velocity">Velocity of movement</param>
        /// <param name="rotation">Rotation of movement</param>
        /// <param name="destination">World space coords of destination</param>
        public void Move (float velocity, Quaternion rotation, Vector3 destination)
        {

        }
    }
}
