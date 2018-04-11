using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audiomixer;

    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("volume", volume);
        
    }

    public AudioMixer audiomixer2;
    public void Music(float volume)
    {
        audiomixer2.SetFloat("music", volume);
    }
}
