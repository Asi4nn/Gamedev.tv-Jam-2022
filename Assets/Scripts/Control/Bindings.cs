using System.Collections.Generic;
using UnityEngine;

namespace Game.Control
{
    public struct PlayerBinds
    {
        public KeyCode Foward;
        public KeyCode Backward;
        public KeyCode Left;
        public KeyCode Right;
        public KeyCode Interact;
    }

    public enum PlayerKeys
    {
        Forward,
        Backward,
        Left,
        Right,
        Interact
    }

    public class Bindings : MonoBehaviour
    {
        public static Bindings Instance;

        public Dictionary<PlayerKeys, KeyCode> PlayerOne;
        public Dictionary<PlayerKeys, KeyCode> PlayerTwo;
        Dictionary<PlayerKeys, KeyCode>[] playerBinds = new Dictionary<PlayerKeys, KeyCode>[2];
        KeyCode Pause;

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
            // Set default keybinds
            PlayerOne = new Dictionary<PlayerKeys, KeyCode>
            {
                { PlayerKeys.Forward, KeyCode.W },
                { PlayerKeys.Backward, KeyCode.S },
                { PlayerKeys.Left, KeyCode.A },
                { PlayerKeys.Right, KeyCode.D },
                { PlayerKeys.Interact, KeyCode.Space }
            };

            PlayerTwo = new Dictionary<PlayerKeys, KeyCode>
            {
                { PlayerKeys.Forward, KeyCode.UpArrow },
                { PlayerKeys.Backward, KeyCode.DownArrow },
                { PlayerKeys.Left, KeyCode.LeftArrow },
                { PlayerKeys.Right, KeyCode.RightArrow },
                { PlayerKeys.Interact, KeyCode.Return }
            };

            Pause = KeyCode.Escape;

            playerBinds[0] = PlayerOne;
            playerBinds[1] = PlayerTwo;
        }

        public bool GetPlayerKeyDown(int playerNum, PlayerKeys key)
        {
            return Input.GetKeyDown(playerBinds[playerNum - 1][key]);
        }

        public bool GetPlayerKey(int playerNum, PlayerKeys key)
        {
            return Input.GetKey(playerBinds[playerNum - 1][key]);
        }

        public bool GetPauseKeyDown()
        {
            return Input.GetKeyDown(Pause);
        }
    }
}
