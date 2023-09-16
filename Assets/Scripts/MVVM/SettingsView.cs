using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsView : MonoBehaviour, INotifyPropertyChanged
{
    [Header("Sliders")] 
    [SerializeField] private Slider musicSlider;

    [SerializeField] private Slider soundSlider;

    [SerializeField] private TMP_Dropdown languageChoice;
    private SettingsViewModel _viewModel;
    private GameManager _gameManager;
    private AudioManager _audioManager;
    public event PropertyChangedEventHandler PropertyChanged;

    private void Awake()
    {
        _gameManager =  GameManager.Instance();
        _viewModel = new SettingsViewModel(_gameManager);
        _audioManager = AudioManager.Instance();
    }

    private void Start()
    {
        musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        soundSlider.onValueChanged.AddListener(OnSoundVolumeChanged);
        languageChoice.onValueChanged.AddListener(OnLanguageValueChanged);
    }

    private void OnSoundVolumeChanged(float arg0)
    {
       //_audioManager.SetSFXVolume(arg0);
    }

    private void OnMusicVolumeChanged(float arg0)
    {
       //_audioManager.SetMusicVolume(arg0);
    }

    private void OnLanguageValueChanged(int arg0)
    {
        if (languageChoice.value == 0)
        {
            _viewModel.Language = "en";
            _gameManager.SetLocalization(languageChoice.value);
        }
        else if (languageChoice.value == 1)
        {
            _viewModel.Language = "ru";
            _gameManager.SetLocalization(languageChoice.value);

        }
    }
}
