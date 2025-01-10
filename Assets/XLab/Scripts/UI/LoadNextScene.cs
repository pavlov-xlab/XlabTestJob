using System;
using System.Collections;
using Unity.Cinemachine.Samples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Debug.Log("LoadScene" + sceneName);

        StartCoroutine(LoadSceneAsync(sceneName));
    }

    

    IEnumerator LoadSceneAsync(string sceneName)
    {
        SceneManager.LoadScene("Empty", LoadSceneMode.Additive);
        var emptyScene = SceneManager.GetSceneByName("Empty");

        var activeScene = SceneManager.GetActiveScene();
        var objects = activeScene.GetRootGameObjects();
        var player = System.Array.Find(objects, (x)=> x.TryGetComponent<SimplePlayerController>(out var player));

        var ao = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!ao.isDone)
        {
            Debug.Log(">>> " + ao.progress);
            yield return null;
        }
        // yield return ao;

        yield return new WaitForSecondsRealtime(3f);

        var scene = SceneManager.GetSceneByName(sceneName);

        yield return new WaitUntil(()=> scene.isLoaded);

        SceneManager.SetActiveScene(scene);

        SceneManager.MoveGameObjectToScene(player.gameObject, scene);
        yield return SceneManager.UnloadSceneAsync(activeScene.name);

        Debug.Log("LoadSceneAsync - complete");

        SceneManager.UnloadSceneAsync(emptyScene.name);
    }

    IEnumerator LoadSceneAsync2(string sceneName)
    {
        SceneManager.LoadScene("Empty", LoadSceneMode.Single);

        yield return new WaitForSecondsRealtime(2f);

        Resources.UnloadUnusedAssets();
        GC.Collect();

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
