using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static string loadScene;
    public static string unloadScene;


    static ChangeScene instance;

    private void Awake()
    {
        instance = this;
    }

    public static void LoadScene(string scene)
    {
        loadScene = scene;
        instance.StartCoroutine("Load");
    }

    public static void Unloaded(string scene)
    {
        unloadScene = scene;
        instance.StartCoroutine("UnLoad");
    }

    IEnumerator Load()
    {
        yield return SceneManager.LoadSceneAsync(loadScene, LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(loadScene));
    }

    IEnumerator UnLoad()
    {
        yield return SceneManager.UnloadSceneAsync(unloadScene);
    }
}