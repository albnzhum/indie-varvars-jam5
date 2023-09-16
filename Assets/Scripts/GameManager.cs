using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class GameManager : MonoBehaviour
{
    #region Instance

    private static GameManager _instance;

    public static GameManager Instance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }
        return _instance;
    }

    #endregion
    public string Language { get; set; }
    public float MusicVolume { get; set; }
    public float SoundVolume { get; set; }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    IEnumerator SetLocale(int _localeId)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeId];
    }

    public void SetLocalization(int value)
    {
        StartCoroutine(SetLocale(value));
        Debug.Log("Selected language:" + Language);
        LocalizationSettings.SelectedLocale.Identifier = Language;
    }
}
