using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        var sceneName = PlayerPrefs.GetString("sceneName");
        yield return new WaitForSeconds(2);

        AsyncOperation level = SceneManager.LoadSceneAsync(sceneName);
        yield return new WaitForEndOfFrame();
    }
}
