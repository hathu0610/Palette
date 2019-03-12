using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public AudioClip homesound;
    public void OnMouseDown()
    {
        // load a new scene
        AudioSource.PlayClipAtPoint(homesound, new Vector3(5, 1, 2));

        SceneManager.LoadScene("Menu");
    }
}