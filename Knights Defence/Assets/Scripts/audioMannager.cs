using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioMannager : MonoBehaviour
{
    public AudioMixer Mixer;

    public string masterParam = "Master";
    public string ambienceParam = "Ambience";
    public string musicParam = "Music";
    public string sfxParam = "SFX";

    private void SetVolume(string parameter, float volume)
    {
        float audioVolume = Mathf.Log(volume) * 20;
        Mixer.SetFloat(parameter, audioVolume);
    }

    public void SetMasterVolume(float volume)
    {
        SetVolume(masterParam, volume);
    }

    public void SetSFXVolume(float volume)
    {
        SetVolume(sfxParam, volume);
    }

    public void SetAmbientVolume(float volume)
    {
        SetVolume(ambienceParam, volume);
    }

    public void SetMusicVolume(float volume)
    {
        SetVolume(musicParam, volume);
    }
}
