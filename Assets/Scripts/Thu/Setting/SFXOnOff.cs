using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXOnOff : MonoBehaviour
{
    //private PowerupScript powScript;
    bool m_Play1;
    bool m_ToggleChange1;

    public Toggle sfxtoggle;


    void Start()
    {
        //.GetComponent<AudioSource>();
        m_Play1 = true;
        m_ToggleChange1 = false;
        if (PlayerPrefs.GetInt("SFXToggle") == 1)
        {
            sfxtoggle.isOn = true;
       }
        else
        {
            sfxtoggle.isOn = false;
        }
    }
    public void OnChangeValue1()
    {
        m_ToggleChange1 = true;

    }
    void Update()
    {

        if (m_ToggleChange1 == true && m_Play1 == false)
        {
            //Play the audio you attach to the AudioSource component
           // audioSrc.Play();
            m_ToggleChange1 = false;
            m_Play1 = true;
            PlayerPrefs.SetInt("SFXToggle", 1);
            //Ensure audio doesn’t play more than once
        }
        if (m_ToggleChange1 == true && m_Play1 == true)
        {
            //Stop the audio
          //  audioSrc.Stop();
            m_ToggleChange1 = false;
            m_Play1 = false;
            PlayerPrefs.SetInt("SFXToggle", 0);
        }

    }

}
