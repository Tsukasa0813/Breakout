using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFlags : MonoBehaviour
{
    void Start()
    {
     LevelManager.isStart = false;
    }
}
