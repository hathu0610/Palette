using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;

    private void Start()
    {
        StartCoroutine(StartScene());
    }
    public void OnMouseDown()
    {
        // load a new scene
        StartCoroutine(LoadScene());

    }

    public void OnMouseDownHome()
    {
        // load a new scene
        StartCoroutine(LoadSceneHome());

    }

    public void OnMouseDownPlay()
    {
        // load a new scene
        StartCoroutine(LoadScenePlay());

    }

    IEnumerator LoadSceneHome()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Menu");

    }

    IEnumerator LoadScenePlay()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("game");

    }

    public void resetPlayerPref()
    {
        Debug.Log("reset player pref");
        PlayerPrefs.DeleteAll();
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);

    }

    // TODO: There is no canvas available
    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(0.8f);
        Canvas myCanvas = this.GetComponent<Canvas>();
        myCanvas.sortingOrder = -2;
    }
}
