using UnityEngine;

namespace Game.LevelBuilding
{
    public class LightRotater : MonoBehaviour
    {
        [SerializeField] float rotationSpeed = 0.01f;

        void Update()
        {
            transform.Rotate(0, rotationSpeed, 0, Space.World);
        }
    }
}
