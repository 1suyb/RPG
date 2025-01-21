using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

public class Managers : SingletonBase<Managers>
{
    private SceneManager _sceneManager = new SceneManager();
    private InfoManager _infoManager = new InfoManager();
    public static SceneManager SceneManager => Instance._sceneManager;
    public static InfoManager InfoManager => Instance._infoManager;
    
    private void Awake()
    {
        if(Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    protected override void InitOnCreate()
    {
        _sceneManager.InitOnCreate();
        _infoManager.InitOnCreate();
    }
}
