using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    public class PersistantObject : MonoBehaviour
    {
        public static PersistantObject Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
