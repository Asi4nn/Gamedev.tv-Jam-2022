using UnityEngine;

namespace Game.Core
{
    [ExecuteInEditMode]
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] Vector3 offset;
        [SerializeField] GameObject player1;
        [SerializeField] GameObject player2;

        [Range(0, 0.5f)]
        [SerializeField] float zoomInViewportThreshold = 0.4f;
        [Range(0, 0.5f)]
        [SerializeField] float zoomOutViewportThreshold = 0.45f;

        [Range(0, 1)]
        [SerializeField] float zoomInSpeedFactor = 0.01f;
        [SerializeField] float zoomOutSpeedFactor = 0.05f;

        Vector3 zoomOffset = Vector3.zero;

        void FixedUpdate()
        {
            Vector3 pos = UpdatePlayersCenter();
            OffsetCameraByPlayer(pos);

            transform.LookAt(pos);
            transform.position = pos + offset;
            transform.position += (pos + offset + zoomOffset) - transform.position;
        }

        private void OffsetCameraByPlayer(Vector3 pos)
        {
            Camera main = Camera.main;
            Vector3 player1Viewport = main.WorldToViewportPoint(player1.transform.position) - new Vector3(0.5f, 0.5f);
            Vector3 player2Viewport = main.WorldToViewportPoint(player2.transform.position) - new Vector3(0.5f, 0.5f);

            if (!PlayersInViewport(player1Viewport, player2Viewport))
            {
                zoomOffset -= Vector3.Normalize(pos - main.transform.position) * zoomOutSpeedFactor;
            }
            else if (PlayersCloseToCenter(player1Viewport, player2Viewport))
            {
                zoomOffset *= (1 - zoomInSpeedFactor);
            }
        }

        private bool PlayersInViewport(Vector3 player1Viewport, Vector3 player2Viewport)
        {
            return Mathf.Abs(player1Viewport.x) <= zoomOutViewportThreshold && Mathf.Abs(player1Viewport.y) <= zoomOutViewportThreshold &&
                Mathf.Abs(player2Viewport.x) <= zoomOutViewportThreshold && Mathf.Abs(player2Viewport.y) <= zoomOutViewportThreshold;
        }

        private bool PlayersCloseToCenter(Vector3 player1Viewport, Vector3 player2Viewport)
        {
            return Mathf.Abs(player1Viewport.x) <= zoomInViewportThreshold && Mathf.Abs(player1Viewport.y) <= zoomInViewportThreshold &&
                Mathf.Abs(player2Viewport.x) <= zoomInViewportThreshold && Mathf.Abs(player2Viewport.y) <= zoomInViewportThreshold;
        }

        private Vector3 UpdatePlayersCenter()
        {
            return (player1.transform.position + player2.transform.position) / 2;
        }
    }
}
