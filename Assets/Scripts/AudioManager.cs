using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    #region Instance

    private static AudioManager _instance;

    public static AudioManager Instance()
    {
        if (_instance == null)
        {
            _instance = new AudioManager();
        }

        return _instance;
    }

    #endregion
    public AudioMixer audioMixer; // Ссылка на аудио-микшер
    public AudioMixerGroup sfxMixerGroup; // Группа для звуковых эффектов
    public AudioMixerGroup musicMixerGroup; // Группа для музыки
    

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SXFVolume", Mathf.Log10(value) * 20);
    }

    public void SetMusicVolume(float value)
    {
      audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }
}
