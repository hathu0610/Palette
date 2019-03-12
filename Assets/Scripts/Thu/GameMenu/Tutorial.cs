using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public AudioClip cliptogglesoundtutorial;

    public void OnMouseDown()
    {
        // load a new scene
        AudioSource.PlayClipAtPoint(cliptogglesoundtutorial, new Vector3(5, 1, 2));
        PlayerPrefs.SetInt("firstTimePlayer", 1);
        SceneManager.LoadScene("Tutorial");
    }
}