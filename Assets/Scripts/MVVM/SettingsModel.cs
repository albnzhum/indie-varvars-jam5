using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsModel
{
    #region Instance

    private static SettingsModel _instance;

    public static SettingsModel Instance()
    {
        if (_instance == null)
        {
            _instance = new SettingsModel();
        }

        return _instance;
    }

    #endregion
    
    private string language { get; set; }
    private float musicVolume { get; set; }
    private float sfxVolume { get; set; }
    
}
