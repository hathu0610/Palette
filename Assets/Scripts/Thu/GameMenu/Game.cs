using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public void OnMouseDown()
    {
        // load a new scene
        if (PlayerPrefs.GetInt("firstTimePlayer", 0) == 0)
        {
            Debug.Log("First time player");
            SceneManager.LoadScene("TutorialFirstTimePlayer");
            PlayerPrefs.SetInt("firstTimePlayer", 1);
        }
        else
        {
            Debug.Log("Not a first time player");
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("game");

    }
    public void resetPlayerPref(){
        Debug.Log("Reset PlayerPref");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("MusicToggle", 1);
        PlayerPrefs.SetFloat("SoundSlider", 1);
        PlayerPrefs.SetInt("SFXToggle", 1);
    }
}