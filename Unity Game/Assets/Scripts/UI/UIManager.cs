using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager  Instance
    {
        get
        {
            if (_instance == null) { Debug.LogError("UI manager is null"); }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
