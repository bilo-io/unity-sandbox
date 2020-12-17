using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VirtualMuseum
{
  public class MenuController : MonoBehaviour
  {
    public AudioSource menuMusic;
    public AudioSource swoosh;

    [Header("Core Objects")]
    public Camera camera;
    public MenuItem[] items;
    public int index = 0;


    [Header("Animation")]
    public float rotationSpeed = 6f;
    public float duration = 0f;
    public float transitionDuration = 1f;
    public bool isTransitioning = false;

    public Transform startTransform;
    public Transform endTransform;

    // Start is called before the first frame update
    void Awake ()
    {
      camera = Camera.main;
      camera.transform.position = items[0].transform.position;
      camera.transform.rotation = items[0].transform.rotation;

      menuMusic.Play();
    }

    // Update is called once per frame
    void Update ()
    {
      if(Input.GetKeyDown(KeyCode.LeftArrow)) {
        PreviousItem();
      }

      if(Input.GetKeyDown(KeyCode.RightArrow)) {
        NextItem();
      }

      if(Input.GetKeyDown(KeyCode.Return)) {
        var sceneName = items[index].SceneName;
        Debug.Log($"Opening Menu Item: {sceneName}");

        if(sceneName.Equals("Exit"))
        {
          Application.Quit();
        }
        else
        {
          SceneSystem.instance.LoadScene(sceneName, true);
        }
      }

      Animate();
    }

    void NextItem ()
    {
      if(isTransitioning) {
        return;
      }

      swoosh.Play();

      duration = 0;
      isTransitioning = true;
      items[index].SetActiveText(false);

      index += 1;
      if(index >= items.Length) index = 0;

      var nextItem = items[index];
      nextItem.SetActiveText(true);
      startTransform = camera.transform;
      endTransform = nextItem.transform;

      Debug.Log("<color=cyan>MainMenu.NEXT_ITEM</color>");
    }

    void PreviousItem ()
    {
      if(isTransitioning) {
        return;
      }

      swoosh.Play();

      duration = 0;
      isTransitioning = true;
      items[index].SetActiveText(false);

      index -= 1;
      if(index < 0) index = items.Length -1;

      var nextItem = items[index];
      nextItem.SetActiveText(true);
      startTransform = camera.transform;
      endTransform = nextItem.transform;

      Debug.Log("<color=orange>MainMenu.PREV_ITEM</color>");
    }

    void Animate()
    {
      if(isTransitioning) {

        duration += Time.deltaTime;
        if(duration < transitionDuration)
        {
          camera.transform.position = Vector3.Lerp(startTransform.position, endTransform.position, duration);
          camera.transform.rotation = Quaternion.Slerp(startTransform.rotation, endTransform.rotation, duration);
        }
        else
        {
          duration = 0;
          isTransitioning = false;
        }
      }
    }
  }
}
