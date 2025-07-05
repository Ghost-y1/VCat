using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLanguage : MonoBehaviour
{
    void Start()
    {
        int savedLang = PlayerPrefs.GetInt("language", 0);
        LocalizationManager.Instance.LoadLanguage((Language)savedLang);
    }
}
