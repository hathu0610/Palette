using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public AudioClip cliptogglesoundsetting;

    public void OnMouseDown()
    {
        // load a new scene
        AudioSource.PlayClipAtPoint(cliptogglesoundsetting, new Vector3(5, 1, 2));
        SceneManager.LoadScene("Setting");
    }
}