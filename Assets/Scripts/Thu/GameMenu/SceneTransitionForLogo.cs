using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneTransitionForLogo : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator transitionAnim;
    public Animator transitionAnim2;
    public string sceneName;


    public void OnMouseDown()
    {
        // load a new scene
        StartCoroutine(LoadScene());

    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        transitionAnim2.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);

    }


}
