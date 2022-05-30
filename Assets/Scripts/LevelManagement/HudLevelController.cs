using UnityEngine;

namespace Game.LevelManagement
{
    public class HudLevelController : MonoBehaviour
    {
        public void RestartLevel()
        {
            LevelManager.Instance.ReloadScene();
        }

        public void LoadNextLevel()
        {
            LevelManager.Instance.LoadNextLevel();
        }
    }
}
