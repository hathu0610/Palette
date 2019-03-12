using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSlider : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //.GetComponent<AudioSource>();
        audioSrc = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
    }
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
