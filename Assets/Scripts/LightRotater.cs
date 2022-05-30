using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotater : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0.01f, 0, Space.World);
    }
}
