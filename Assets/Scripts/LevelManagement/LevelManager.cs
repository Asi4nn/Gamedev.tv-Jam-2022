using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
