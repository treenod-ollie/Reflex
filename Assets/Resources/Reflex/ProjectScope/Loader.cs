using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using Reflex.Core;

public class Loader : MonoBehaviour
{
    private void Start()
    {
        // 만약 addressables를 사용하지 않고 씬을 로드하는 경우
        var scene = SceneManager.LoadScene("Greet", new LoadSceneParameters(LoadSceneMode.Single));
        ReflexSceneManager.PreInstallScene(scene, descriptor => descriptor.AddSingleton("beautiful"));
        
        // 만약 addressables를 사용하여 씬을 로드하는 경우
        // Addressables.LoadSceneAsync("Greet", activateOnLoad: false).Completed += handle =>
        // {
        //     // 로드된 씬에 대한 Reflex 의존성 주입 설정
        //     ReflexSceneManager.PreInstallScene(handle.Result.Scene, descriptor => descriptor.AddSingleton("beautiful"));
        //     // 씬 활성화
        //     handle.Result.ActivateAsync();
        // };
    }
}
