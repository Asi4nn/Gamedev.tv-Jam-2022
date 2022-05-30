using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.LevelManagement
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        public int numLevels;
        public bool[] levelStatuses;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            levelStatuses = new bool[numLevels];
        }

        public void SetLevelComplete(int level)
        {
            levelStatuses[level - 1] = true;
        }

        public void LoadScene(int level)
        {
            SceneManager.LoadScene(level);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadNextLevel()
        {
            if (SceneManager.GetActiveScene().buildIndex == numLevels)
            {
                LoadScene(0);
            }
            LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
