using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SettingsViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private readonly GameManager gameManager;
    public SettingsViewModel(GameManager gameManager) => this.gameManager = gameManager;

    public float MusicVolume
    {
        set => gameManager.MusicVolume = value;
    }
    
    public float SoundVolume
    {
        set => gameManager.SoundVolume = value;
    }

    public string Language
    {
        set => gameManager.Language = value;
    }

    protected virtual void OnPropertyChanged(string property)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
