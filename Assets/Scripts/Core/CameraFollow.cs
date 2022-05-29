using UnityEngine;

namespace Game.Core
{
    [ExecuteInEditMode]
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] Vector3 offset;

        [SerializeField] GameObject player1;
        [SerializeField] GameObject player2;

        void FixedUpdate()
        {
            Vector3 pos = UpdatePlayersCenter();
            transform.LookAt(pos);
            transform.position = pos + offset;
        }

        private Vector3 UpdatePlayersCenter()
        {
            return (player1.transform.position + player2.transform.position) / 2;
        }
    }
}
