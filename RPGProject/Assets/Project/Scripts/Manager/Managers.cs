using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

public class Managers : SingletonBase<Managers>
{
    private SceneManager _sceneManager = new SceneManager();
    public static SceneManager SceneManager => Instance._sceneManager;
    
    private void Awake()
    {
        if(Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        Init();
    }

    private void Init()
    {
        _sceneManager.Init();
    }
}
