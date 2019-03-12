using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    public AudioClip cliptogglesound;

    public void OnMouseDown()
    {
        // load a new scene
       
        AudioSource.PlayClipAtPoint(cliptogglesound, new Vector3(5, 1, 2));
        SceneManager.LoadScene("Credit");
       
    }
}