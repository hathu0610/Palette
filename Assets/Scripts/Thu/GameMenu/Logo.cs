using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    void OnMouseDown()
    {
        // load a new scene
        SceneManager.LoadScene("game");
    }
}