using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Control
{
    public class Bindings : MonoBehaviour
    {
        public static Bindings Instance;

        public struct PlayerBinds
        {
            public KeyCode Foward;
            public KeyCode Backward;
            public KeyCode Left;
            public KeyCode Right;
            public KeyCode Interact;
        }

        public PlayerBinds PlayerOne;
        public PlayerBinds PlayerTwo;

        public KeyCode Pause;

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

            PlayerOne.Foward = KeyCode.W;
            PlayerOne.Backward = KeyCode.S;
            PlayerOne.Left = KeyCode.A;
            PlayerOne.Right = KeyCode.D;
            PlayerOne.Interact = KeyCode.Space;

            PlayerTwo.Foward = KeyCode.UpArrow;
            PlayerTwo.Backward = KeyCode.DownArrow;
            PlayerTwo.Left = KeyCode.LeftArrow;
            PlayerTwo.Right = KeyCode.RightArrow;
            PlayerTwo.Interact = KeyCode.Return;

            Pause = KeyCode.Escape;
        }
    }
}
