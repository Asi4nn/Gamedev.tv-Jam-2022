using UnityEngine;
using UnityEngine.Events;

namespace Game.LevelBuilding
{
    public class Switch : MonoBehaviour
    {
        public ObjectType type;

        public UnityEvent activate;
    }
}
