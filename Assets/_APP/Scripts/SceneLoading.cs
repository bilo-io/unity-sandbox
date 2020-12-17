using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoading : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    [SerializeField]
    private TextMeshPro m_Text;

    // [SerializeField]
    // private TMPText text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        var sceneName = PlayerPrefs.GetString("sceneName");
        yield return new WaitForSeconds(2);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        Debug.Log("Pro :" + asyncOperation.progress);
        m_Text.text = $"Loading progress: {asyncOperation.progress * 100}%";
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            var progress = $"Loading progress: {asyncOperation.progress * 100}%";
            Debug.Log(progress);
            //Output the current progress
            m_Text.text = $"Loading progress: {asyncOperation.progress * 100}%";

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                m_Text.text = "Press the space bar to continue";
                Debug.Log("Press the space bar to continue");
                //Wait to you press the space key to activate the Scene
                if (Input.GetKeyDown(KeyCode.Space))
                    //Activate the Scene
                    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }

        // yield return new WaitForEndOfFrame();
    }
}
