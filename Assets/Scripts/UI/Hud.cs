using Game.Control;
using UnityEngine;

namespace Game.UI
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] GameObject pauseMenu;
        [SerializeField] GameObject levelFinishMenu;

        private void Awake()
        {
            pauseMenu.SetActive(false);
            levelFinishMenu.SetActive(false);
        }

        private void Update()
        {
            if (Bindings.Instance.GetPauseKeyDown()){
                TogglePauseMenu();
            }
        }

        private void TogglePauseMenu()
        {
            if (pauseMenu.activeInHierarchy)
            {
                pauseMenu.SetActive(false);
            }
            else
            {
                pauseMenu.SetActive(true);
            }
        }

        public void LevelFinish(int levelNum)
        {
            levelFinishMenu.SetActive(true);
            GetComponent<UIControlRemover>().DisableControl();
        }
    }
}
