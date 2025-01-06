using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Manager
{
    public class SceneManager : IManager
    {
        private FloatEventListenerSO _sceneLoadingEvent;

        public void Init()
        {
            _sceneLoadingEvent = ResourceManager.Load<FloatEventListenerSO>(ResourcePath.SO.LoadingEvent);
        }

        public void Release()
        {
            _sceneLoadingEvent = null;
        }

        public void LoadScene(Scenes scene, bool loading = true)
        {
            if (loading)
            {
                Managers.Instance.StartCoroutine(LoadSceneAsync(scene));
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
            }
        }
        
        private IEnumerator LoadSceneAsync(Scenes scene)
        {
            string sceneName = scene.ToString();
            // 비동기 씬 로드 시작
            AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
 
            // 로딩 화면을 활성화 (필요 시)
            operation.allowSceneActivation = false;
 
            while (!operation.isDone)
            {
                // 로딩 진행도 업데이트 (0 ~ 0.9까지 반환됨)
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                _sceneLoadingEvent.RaiseEvent(progress);
 
                // 로딩이 완료되었을 때 씬 전환
                if (operation.progress >= 0.9f)
                {
                    operation.allowSceneActivation = true;
                }
                yield return null;
            }
        }
    }
}

/*
 * using UnityEngine;
 using UnityEngine.SceneManagement;
 using UnityEngine.UI;
 using System.Collections;
 using TMPro;
 
 public class LoadingScene : MonoBehaviour
 {
     public Slider progressBar; // 프로그레스 바
     public TMP_Text progressText;  // 프로그레스 퍼센트 텍스트
 
     public void Start()
     {
         StartCoroutine(LoadSceneAsync());
     }
 
     private IEnumerator LoadSceneAsync()
     {
         string sceneName = Managers.SceneLoader.SceneName;
         // 비동기 씬 로드 시작
         AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
 
         // 로딩 화면을 활성화 (필요 시)
         operation.allowSceneActivation = false;
 
         while (!operation.isDone)
         {
             // 로딩 진행도 업데이트 (0 ~ 0.9까지 반환됨)
             float progress = Mathf.Clamp01(operation.progress / 0.9f);
             if (progressBar != null)
                 progressBar.value = progress;
             if (progressText != null)
                 progressText.text = $"{(int)(progress * 100)}%";
 
             // 로딩이 완료되었을 때 씬 전환
             if (operation.progress >= 0.9f)
             {
 
                 // 사용자 입력 대기
                 if (Input.anyKeyDown)
                 {
                     operation.allowSceneActivation = true;
                 }
                 operation.allowSceneActivation = true;
             }
             yield return null;
         }
     }
 }
*/